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
#define IB_WIN32

#elif defined(__IPHONE_5_0) // If running on (minimum) of iOS 5.0+
#include <pthread.h>
#define IB_POSIX

#elif defined(_POSIX_THREADS)
#include <pthread.h>
#define IB_POSIX

#else
#error "Not supported on this platform"

#endif

#include <string>
#include <deque>
#include <vector>
#include <algorithm>

#ifndef TWSAPIDLLEXP
#define TWSAPIDLLEXP
#endif

