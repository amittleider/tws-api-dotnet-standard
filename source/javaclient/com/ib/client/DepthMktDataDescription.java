/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.client;

public class DepthMktDataDescription {
    private String 	m_exchange;
    private String 	m_secType;
    private boolean m_isL2;

    // Get
    public String exchange() { return m_exchange; }
    public String secType() { return m_secType; }
    public boolean isL2() { return m_isL2; }

    // Set 
    public void exchange(String exchange) { m_exchange = exchange; }
    public void secType(String secType) { m_secType = secType; }
    public void isL2(boolean isL2) { m_isL2 = isL2; }

    public DepthMktDataDescription() {
    }

    public DepthMktDataDescription(String p_exchange, String p_secType, boolean p_isL2) {
        m_exchange = p_exchange;
        m_secType = p_secType;
        m_isL2 = p_isL2;
    }
}
