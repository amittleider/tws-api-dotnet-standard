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
