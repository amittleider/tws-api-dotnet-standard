/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#pragma once
#include "ereadersignal.h"

class TWSAPIDLLEXP EReaderOSSignal :
	public EReaderSignal
{
	HANDLE m_evMsgs;
    unsigned long m_waitTimeout;

public:
	EReaderOSSignal(unsigned long waitTimeout = INFINITE) throw (std::runtime_error);
	~EReaderOSSignal(void);

	virtual void issueSignal();
	virtual void waitForSignal();
};

