/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#include "StdAfx.h"
#include "EReaderOSSignal.h"


EReaderOSSignal::EReaderOSSignal(unsigned long waitTimeout)
{
    m_waitTimeout = waitTimeout;
	m_evMsgs = CreateEvent(0, false, false, 0);

	if (NULL == m_evMsgs)
		throw std::runtime_error("Failed to create event");
}


EReaderOSSignal::~EReaderOSSignal(void)
{
	CloseHandle(m_evMsgs);
}


void EReaderOSSignal::issueSignal() {
	SetEvent(m_evMsgs);
}

void EReaderOSSignal::waitForSignal() {
	WaitForSingleObject(m_evMsgs, m_waitTimeout);
}