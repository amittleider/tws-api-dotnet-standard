/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#ifdef _MSC_VER

#ifndef DLLEXP
#define DLLEXP __declspec( dllexport )
#endif

#define assert ASSERT
#define snprintf _snprintf

#else

#define DLLEXP

#endif

