/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.client;

import java.util.Arrays;

public class ContractDescription {
    private Contract m_contract;
    private String[] m_derivativeSecTypes;

    // Get
    public Contract contract() { return m_contract; }
    public String[] derivativeSecTypes() { return m_derivativeSecTypes; }

    // Set
    public void contract(Contract contract) { m_contract = contract; }
    public void derivativeSecTypes(String[] derivativeSecTypes) { m_derivativeSecTypes = derivativeSecTypes; }

    public ContractDescription() {
        m_contract = new Contract();
    }

    public ContractDescription( Contract p_contract, String[] p_derivativeSecTypes) {
        m_contract = p_contract;
        m_derivativeSecTypes = p_derivativeSecTypes;
    }

    @Override public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append( "conid: " + m_contract.conid() + "\n");
        sb.append( "symbol: " + m_contract.symbol() + "\n");
        sb.append( "secType: " + m_contract.secType().toString() + "\n");
        sb.append( "primaryExch: " + m_contract.primaryExch() + "\n");
        sb.append( "currency: " + m_contract.currency() + "\n");
        sb.append( "derivativeSecTypes: " + Arrays.toString(m_derivativeSecTypes) + "\n");
        return sb.toString();
    }
}
