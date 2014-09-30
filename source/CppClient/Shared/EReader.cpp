#include "StdAfx.h"
#include "shared_ptr.h"
#include "contract.h"
#include "EDecoder.h"
#include "CriticalSection.h"
#include "EReader.h"
#include "..\src\EPosixClientSocket.h"
#include "EReaderSignal.h"
#include "EMessage.h"
#include "DefaultWrapper.h"

DefaultWrapper defaultWrapper;

EReader::EReader(EPosixClientSocket *clientSocket, EReaderSignal *signal)
    : m_decoder(clientSocket, clientSocket->getWrapper()) {
        m_pClientSocket = clientSocket;
        m_pEReaderSignal = signal;

        m_buf.reserve(8192);
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
    EMessage *msg = readSingleMsg();

    while (msg != 0) {
        m_csMsgQueue.Enter();
        m_msgQueue.push_back(shared_ptr<EMessage>(msg));
        m_csMsgQueue.Leave();
        m_pEReaderSignal->onMsgRecv();
        
        msg = readSingleMsg();
    }

    m_pClientSocket->handleSocketError();
}

EMessage * EReader::readSingleMsg() {
    if (m_pClientSocket->usingV100Plus()) {
        int msgSize;

        m_pClientSocket->receive((char *)&msgSize, sizeof(msgSize));

        if (msgSize <= 0 || msgSize > MAX_MSG_LEN)
            return 0;

        std::vector<char> buf = std::vector<char>(msgSize);

        m_pClientSocket->receive(buf.data(), buf.size());

        return new EMessage(buf);
    }
    else {
        EDecoder tmpDecoder(m_pClientSocket, &defaultWrapper);

        if (m_buf.size() == 0) {             
            m_buf.resize(8192);        

            int nResult = m_pClientSocket->receive( m_buf.data(), m_buf.size());


            if( nResult == 0)
                return 0;

            m_buf.resize(nResult);
        }

        const char *pBegin = m_buf.data();
        const char *pEnd = pBegin + m_buf.size();
        int msgSize = tmpDecoder.parseAndProcessMsg(pBegin, pEnd);

        if (msgSize == 0)
            return 0;

        EMessage * msg = new EMessage(std::vector<char>(m_buf.begin(), m_buf.begin() + msgSize));

        std::copy(m_buf.begin() + msgSize, m_buf.end(), m_buf.begin());
        //m_buf.assign(m_buf.begin() + msgSize, m_buf.end());
        m_buf.resize(m_buf.size() - msgSize);

        return msg;
    }
}

shared_ptr<EMessage> EReader::getMsg(void) {
    m_csMsgQueue.Enter();

    if (m_msgQueue.size() == 0)
        return shared_ptr<EMessage>();

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
