/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#pragma once
#ifndef depthmktdatadescription_def
#define depthmktdatadescription_def

struct DepthMktDataDescription
{
	std::string exchange;
	std::string secType;
	bool isL2;
};

#endif // depthmktdatadescription_def
