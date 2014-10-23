/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
* and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#pragma once
struct EClientMsgSink
{
    virtual void serverVersion(int value) = 0;
    virtual void serverTime(const char *value) = 0;
    virtual void redirect(const char *host, int port) = 0;
    virtual void connected() = 0;
};

