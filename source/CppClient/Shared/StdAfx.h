/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#ifdef _MSC_VER

#ifdef TWSAPIDLL
#    define TWSAPIDLLEXP __declspec(dllexport)
#endif

#define assert ASSERT
#define snprintf _snprintf
#include <WinSock2.h>
#include <Windows.h>

#endif

#include <string>
#include <deque>
#include <vector>
#include <algorithm>

#ifndef TWSAPIDLLEXP
#define TWSAPIDLLEXP
#endif

