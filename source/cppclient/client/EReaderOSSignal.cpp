/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#include "StdAfx.h"
#include "EReaderOSSignal.h"


EReaderOSSignal::EReaderOSSignal(void)
{
	m_evMsgs = CreateEvent(0, false, false, 0);

	if (NULL == m_evMsgs)
		throw std::runtime_error("Failed to create event");
}


EReaderOSSignal::~EReaderOSSignal(void)
{
	CloseHandle(m_evMsgs);
}


void EReaderOSSignal::onMsgRecv() {
	SetEvent(m_evMsgs);
}

void EReaderOSSignal::waitSignal() {
	WaitForSingleObject(m_evMsgs, INFINITE);
}