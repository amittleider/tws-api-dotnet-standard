#pragma once

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

