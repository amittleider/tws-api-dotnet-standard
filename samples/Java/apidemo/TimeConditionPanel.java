package apidemo;

import com.ib.client.TimeCondition;

public class TimeConditionPanel extends OperatorConditionPanel<TimeCondition> {

	TimeConditionPanel(TimeCondition condition) {
		super(condition);

		m_value.setText(condition().time());
		
		add("Operator", m_operator);
		add("Time", m_value);
	}
	
	@Override
	public TimeCondition onOK() {
		super.onOK();	
		condition().time(m_value.getText());
		
		return condition();
	}
}
