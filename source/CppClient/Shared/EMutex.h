#pragma once

class EMutex
{
    CRITICAL_SECTION cs;

public:
    EMutex();
    ~EMutex();
    bool TryEnter();
    void Enter();
    void Leave();
};

