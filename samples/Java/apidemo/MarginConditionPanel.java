package apidemo;

import com.ib.client.MarginCondition;

public class MarginConditionPanel extends OperatorConditionPanel<MarginCondition> {
	
	MarginConditionPanel(MarginCondition condition) {
		super(condition);
		
		m_value.setText(condition().percent());
		
		add("Operator", m_operator);
		add("Cushion (%)", m_value);
	}
	
	public MarginCondition onOK() {
		super.onOK();
		condition().percent(m_value.getInt());
		
		return condition();
	}
}
