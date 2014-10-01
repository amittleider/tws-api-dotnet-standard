#include "StdAfx.h"
#include "EReaderOSSignal.h"


EReaderOSSignal::EReaderOSSignal(void)
{
	m_evMsgs = CreateEvent(0, false, false, 0);
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