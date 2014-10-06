/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#include "StdAfx.h"
#include "EReaderWMSignal.h"


EReaderWMSignal::EReaderWMSignal(HWND hWnd, int wmUserOffset) {
	m_hWnd = hWnd;
	m_msg = WM_USER + wmUserOffset;
}

void EReaderWMSignal::onMsgRecv() {
	if (IsWindow(m_hWnd))
		PostMessage(m_hWnd, m_msg, 0, 0);
}