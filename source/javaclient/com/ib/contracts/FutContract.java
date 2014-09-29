/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.contracts;

import com.ib.client.Contract;
import com.ib.controller.Types.SecType;

public class FutContract extends Contract {
    public FutContract(String symbol, String expiry) {
        symbol(symbol);
        secType(SecType.FUT);
        exchange("ONE");
        currency("USD");
    }

    public FutContract(String symbol, String expiry, String currency) {
        symbol(symbol);
        secType(SecType.FUT.name());
        currency(currency);
        expiry(expiry);
    }
}
