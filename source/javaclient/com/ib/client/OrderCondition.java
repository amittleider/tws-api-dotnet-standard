package com.ib.client;

import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectOutput;


public abstract class OrderCondition {
	
	private OrderConditionType m_type;
	private boolean m_isConjunctionConnection;
			
	public void readFrom(ObjectInput in) throws IOException {
		conjunctionConnection(in.readUTF().compareToIgnoreCase("a") == 0);
	}
	
	public void writeTo(ObjectOutput out) throws IOException {
		out.writeUTF(conjunctionConnection() ? "a" : "o");
	}


	@Override
	public String toString() {
		return conjunctionConnection() ? "<AND>" : "<OR>";
	}

	public boolean conjunctionConnection() {
		return m_isConjunctionConnection;
	}

	public void conjunctionConnection(boolean isConjunctionConnection) {
		this.m_isConjunctionConnection = isConjunctionConnection;
	}
	
	public OrderConditionType type() { return m_type; }
	
	public static OrderCondition create(OrderConditionType type) {
		OrderCondition rval = null;
		
		switch (type) {
		case Execution:
			rval = new ExecutionCondition();
			break;
			
		case Margin:
			rval = new MarginCondition();
			break;
			
		case PercentChange:
			rval = new PercentChangeCondition();
			break;
			
		case Price:
			rval = new PriceCondition();
			break;
			
		case Time:
			rval = new TimeCondition();
			break;
			
		case Volume:
			rval = new VolumeCondition();
			break;
		}
		
		if (rval != null)
			rval.m_type = type;
		
		return rval;
	}
	
}