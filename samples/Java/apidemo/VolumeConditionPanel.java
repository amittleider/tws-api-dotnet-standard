package apidemo;

import com.ib.client.ContractLookuper;
import com.ib.client.VolumeCondition;

public class VolumeConditionPanel extends ContractConditionPanel<VolumeCondition> {

	VolumeConditionPanel(VolumeCondition condition, ContractLookuper lookuper) {
		super(condition, lookuper);
		
		m_value.setText(condition().volume());
		
		add("Operator", m_operator);
		add("Volume", m_value);
	}

	@Override
	public VolumeCondition onOK() {
		super.onOK();
		
		condition().volume(m_value.getInt());
		
		return condition();
	}
}
