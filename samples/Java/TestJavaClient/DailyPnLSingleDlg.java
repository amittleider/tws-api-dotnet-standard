package TestJavaClient;

import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;


public class DailyPnLSingleDlg extends DailyPnLDlg {

    int m_conId;

    private JTextField m_conIdField = new JTextField();
    
    public DailyPnLSingleDlg(JFrame parent) {
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
