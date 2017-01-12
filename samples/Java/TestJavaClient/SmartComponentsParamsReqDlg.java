package TestJavaClient;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JTextField;

import apidemo.util.UpperField;
import apidemo.util.VerticalPanel;

public class SmartComponentsParamsReqDlg extends JDialog {

	private int m_id;
	private String m_BBOExchange;
	private boolean m_isOk;
	
	final private UpperField m_idFld = new UpperField("0");
	final private JTextField m_BBOExchangeFld = new JTextField();


	public SmartComponentsParamsReqDlg(SampleFrame owner) {
		super(owner);
		
		VerticalPanel paramsPanel = new VerticalPanel();
		JButton ok = new JButton("OK");
		JButton cancel = new JButton("Cancel");
		
		ok.addActionListener(new ActionListener() { @Override public void actionPerformed(ActionEvent e) { onOK(); } });
		cancel.addActionListener(new ActionListener() { @Override public void actionPerformed(ActionEvent e) { onCancel(); } });
				
		paramsPanel.add("Req Id", m_idFld);			
		paramsPanel.add("BBO Exchange", m_BBOExchangeFld);			
		paramsPanel.add(ok);
		paramsPanel.add(cancel);
		setLayout(new BorderLayout());
		add(paramsPanel, BorderLayout.NORTH);
		pack();
	}

	protected void onCancel() {
		m_isOk = false;
		
		dispose();
	}

	protected void onOK() {
		m_BBOExchange = m_BBOExchangeFld.getText();
		m_id = m_idFld.getInt();
		m_isOk = true;		

		dispose();
	}
	
	public boolean isOK() {
		return m_isOk;
	}
	
	public String BBOExchange() {
		return m_BBOExchange;
	}
	
	public int id() {
		return m_id;
	}
}
