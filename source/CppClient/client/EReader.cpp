/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#include "StdAfx.h"
#include "shared_ptr.h"
#include "contract.h"
#include "EDecoder.h"
#include "EMutex.h"
#include "EReader.h"
#include "EPosixClientSocket.h"
#include "EReaderSignal.h"
#include "EMessage.h"
#include "DefaultWrapper.h"

DefaultWrapper defaultWrapper;

EReader::EReader(EPosixClientSocket *clientSocket, EReaderSignal *signal)
	: m_decoder(clientSocket->serverVersion(), clientSocket->getWrapper())
	, tmpDecoder(clientSocket->serverVersion(), &defaultWrapper) {
		m_pClientSocket = clientSocket;
		m_pEReaderSignal = signal;

		m_buf.reserve(8192);
		start();
}

EReader::~EReader(void) {
}

void EReader::start() {
	CreateThread(0, 0, readToQueueThread, this, 0, 0);
}

DWORD WINAPI EReader::readToQueueThread(LPVOID lpParam) {
	EReader *pThis = reinterpret_cast<EReader *>(lpParam);

	pThis->readToQueue();
	return 0;
}

void EReader::readToQueue() {
	EMessage *msg = 0;

	while (true) {
		if (m_buf.size() == 0 && !processNonBlockingSelect() && m_pClientSocket->isSocketOK())
			continue;

        if (m_pClientSocket->isSocketOK())
		    msg = readSingleMsg();

		if (msg == 0)
			break;

		m_csMsgQueue.Enter();
		m_msgQueue.push_back(shared_ptr<EMessage>(msg));
		m_csMsgQueue.Leave();
		m_pEReaderSignal->onMsgRecv();

        msg = 0;
	}

	m_pClientSocket->handleSocketError();
    m_pEReaderSignal->onMsgRecv(); //letting client know that socket was closed
}

bool EReader::processNonBlockingSelect() {
	fd_set readSet, writeSet, errorSet;
	struct timeval tval;

	tval.tv_usec = 0;
	tval.tv_sec = 0;

	if( m_pClientSocket->fd() >= 0 ) {

		FD_ZERO( &readSet);
		errorSet = writeSet = readSet;

		FD_SET( m_pClientSocket->fd(), &readSet);

		if( !m_pClientSocket->isOutBufferEmpty())
			FD_SET( m_pClientSocket->fd(), &writeSet);

		FD_SET( m_pClientSocket->fd(), &errorSet);

		int ret = select( m_pClientSocket->fd() + 1, &readSet, &writeSet, &errorSet, &tval);

		if( ret == 0) { // timeout
			return false;
		}

		if( ret < 0) {	// error
			m_pClientSocket->eDisconnect();
			return false;
		}

		if( m_pClientSocket->fd() < 0)
			return false;

		if( FD_ISSET( m_pClientSocket->fd(), &errorSet)) {
			// error on socket
			m_pClientSocket->onError();
		}

		if( m_pClientSocket->fd() < 0)
			return false;

		if( FD_ISSET( m_pClientSocket->fd(), &writeSet)) {
			// socket is ready for writing
			m_pClientSocket->onSend();
		}

		if( m_pClientSocket->fd() < 0)
			return false;

		if( FD_ISSET( m_pClientSocket->fd(), &readSet)) {
			// socket is ready for reading
			onReceive();
		}

		return true;
	}

	return false;
}

void EReader::onReceive() {
	int nOffset = m_buf.size();

	m_buf.resize(8192);

	int nRes = m_pClientSocket->receive(m_buf.data() + nOffset, m_buf.size() - nOffset);

	if (nRes <= 0)
		return;

	m_buf.resize(nRes + nOffset);	
}

bool EReader::bufferedRead(char *buf, int size) {
	while (m_buf.size() < size)
		if (!processNonBlockingSelect() && !m_pClientSocket->isSocketOK())
			return false;

	std::copy(m_buf.begin(), m_buf.begin() + size, buf);
	std::copy(m_buf.begin() + size, m_buf.end(), m_buf.begin());
	m_buf.resize(m_buf.size() - size);

	return true;
}

EMessage * EReader::readSingleMsg() {
	if (m_pClientSocket->usingV100Plus()) {
		int msgSize;

		if (!bufferedRead((char *)&msgSize, sizeof(msgSize)))
			return 0;

		msgSize = htonl(msgSize);

		if (msgSize <= 0 || msgSize > MAX_MSG_LEN)
			return 0;

		std::vector<char> buf = std::vector<char>(msgSize);

		if (!bufferedRead(buf.data(), buf.size()))
			return 0;

		return new EMessage(buf);
	}
	else {
		const char *pBegin = m_buf.data();
		const char *pEnd = pBegin + m_buf.size();
		int msgSize = tmpDecoder.parseAndProcessMsg(pBegin, pEnd);

		if (msgSize == 0)
			return 0;

		std::vector<char> msgData(msgSize);

		if (!bufferedRead(msgData.data(), msgSize))
			return 0;

		EMessage * msg = new EMessage(msgData);

		return msg;
	}
}

shared_ptr<EMessage> EReader::getMsg(void) {
	m_csMsgQueue.Enter();

	if (m_msgQueue.size() == 0) {
		m_csMsgQueue.Leave();

		return shared_ptr<EMessage>();
	}

	shared_ptr<EMessage> msg = m_msgQueue.front();

	m_msgQueue.pop_front();
	m_csMsgQueue.Leave();

	return msg;
}


void EReader::processMsgs(void) {
	shared_ptr<EMessage> msg = getMsg();

	if (!msg.get())
		return;

	const char *pBegin = msg->begin();

	while (m_decoder.parseAndProcessMsg(pBegin, msg->end()) > 0) {
		msg = getMsg();

		if (!msg.get())
			break;

		pBegin = msg->begin();
	} 
}
