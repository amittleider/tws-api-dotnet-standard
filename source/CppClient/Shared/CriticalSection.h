#pragma once
#ifdef _MSC_VER
#include <Windows.h>
#endif

class CriticalSection
{
    CRITICAL_SECTION cs;
    bool locked;

public:
    CriticalSection();
    ~CriticalSection();
    bool TryEnter();
    void Enter();
    void Leave();
};

