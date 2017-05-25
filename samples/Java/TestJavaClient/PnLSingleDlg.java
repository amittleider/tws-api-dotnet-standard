package TestJavaClient;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;


public class PnLSingleDlg extends PnLDlg {

    int m_conId;

    private JTextField m_conIdField = new JTextField();
    
    public PnLSingleDlg(JFrame parent) {
        super(parent);
        
        m_editsPanel.add(new JLabel("Con Id"));
        m_editsPanel.add(m_conIdField);
        pack();
    }
    
    @Override
    protected void onOk() {
        try {
            m_conId = Integer.parseInt(m_conIdField.getText());
        } finally {        
            super.onOk();
        }
    }

}
