/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#include "StdAfx.h"
#include "EMutex.h"

EMutex::EMutex()
{
	InitializeCriticalSection(&cs);
}

EMutex::~EMutex(void)
{
	Leave();
	DeleteCriticalSection(&cs);
}

bool EMutex::TryEnter()
{
	return TryEnterCriticalSection(&cs);
}

void EMutex::Enter() {
	EnterCriticalSection(&cs);
}

void EMutex::Leave() {
	LeaveCriticalSection(&cs);
}
