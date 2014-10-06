/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#pragma once
class EMessage
{
    std::vector<char> data;
public:
    EMessage(const std::vector<char> &data);
    const char* begin(void);
    const char* end(void);
};

