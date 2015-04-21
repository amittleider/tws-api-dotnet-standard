/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.contracts;

import com.ib.client.Contract;
import com.ib.client.Types.SecType;

public class FutContract extends Contract {
    public FutContract(String symbol, String lastTradeDate) {
        symbol(symbol);
        secType(SecType.FUT);
        exchange("ONE");
        currency("USD");
    }

    public FutContract(String symbol, String lastTradeDate, String currency) {
        symbol(symbol);
        secType(SecType.FUT.name());
        currency(currency);
        lastTradeDate(lastTradeDate);
    }
}
