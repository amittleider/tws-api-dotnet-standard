package apidemo;

import com.ib.client.ContractLookuper;
import com.ib.client.PercentChangeCondition;

public class PercentConditionPanel extends ContractConditionPanel<PercentChangeCondition> {
	
	PercentConditionPanel(PercentChangeCondition condition, ContractLookuper lookuper) {
		super(condition, lookuper);
		
		m_value.setText(condition().changePercent());
		
		add("Operator", m_operator);
		add("Percentage Change", m_value);
	}
	
	
	public PercentChangeCondition onOK() {
		super.onOK();
		condition().changePercent(m_value.getDouble());
		
		return condition();
	}
}
