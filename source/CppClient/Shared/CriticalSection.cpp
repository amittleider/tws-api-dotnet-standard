#include "StdAfx.h"
#include "CriticalSection.h"

CriticalSection::CriticalSection()
{
    InitializeCriticalSection(&cs);

    locked = false;
}


CriticalSection::~CriticalSection(void)
{
    Leave();
    DeleteCriticalSection(&cs);
}


bool CriticalSection::TryEnter()
{
    return locked ? true : TryEnterCriticalSection(&cs);
}

void CriticalSection::Enter() {
    if (!locked) {
        EnterCriticalSection(&cs);
        locked = true;
    }
}

void CriticalSection::Leave() {
    if (locked) {
        LeaveCriticalSection(&cs);
        locked = false;
    }
}
