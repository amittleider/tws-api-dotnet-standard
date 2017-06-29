package TestJavaClient;

import java.awt.GridBagConstraints;
import java.awt.Window;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

import javax.swing.BorderFactory;
import javax.swing.JCheckBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;

public class HistoricalDataDlg extends JDialogBox {
    private IBGridBagPanel m_panel = new IBGridBagPanel();
    private JTextField  m_BackfillEndTime = new JTextField(22);
    private JTextField  m_BackfillDuration = new JTextField( "1 M");
    private JTextField  m_BarSizeSetting = new JTextField("1 day");
    private JCheckBox  m_UseRTH = new JCheckBox();
    private JTextField  m_FormatDate = new JTextField( "1");
    private JTextField  m_WhatToShow = new JTextField( "TRADES");
    private JCheckBox   m_keepUpToDateCheckBox = new JCheckBox();
    
    private String       m_backfillEndTime;
    private String       m_backfillDuration;
    private String       m_barSizeSetting;
    private boolean          m_useRTH;
    private int          m_formatDate;
    private String       m_whatToShow;
    private boolean      m_keepUpToDate;
    
    public String backfillEndTime() { return m_backfillEndTime; }
    public String backfillDuration() { return m_backfillDuration; }
    public String barSizeSetting() { return m_barSizeSetting; }
    public boolean useRTH() { return m_useRTH; }
    public int formatDate() { return m_formatDate; }
    public String whatToshow() { return m_whatToShow; }
    public boolean keepUpToDate() { return m_keepUpToDate; }
    
    private static final int COL1_WIDTH = 30 ;
    private static final int COL2_WIDTH = 100 - COL1_WIDTH ;
    
    public HistoricalDataDlg(Window parent) {
        super(parent);

        m_panel.setBorder(BorderFactory.createTitledBorder("Historical Data Query"));
        
        GregorianCalendar gc = new GregorianCalendar();
        
        gc.setTimeZone(TimeZone.getTimeZone("GMT"));
        String dateTime = "" +
            gc.get(Calendar.YEAR) +
            pad(gc.get(Calendar.MONTH) + 1) +
            pad(gc.get(Calendar.DAY_OF_MONTH)) + " " +
            pad(gc.get(Calendar.HOUR_OF_DAY)) + ":" +
            pad(gc.get(Calendar.MINUTE)) + ":" +
            pad(gc.get(Calendar.SECOND)) + " " +
            gc.getTimeZone().getDisplayName( false, TimeZone.SHORT);
        
        GridBagConstraints gbc = new java.awt.GridBagConstraints();
        
        gbc.fill = GridBagConstraints.BOTH;
        gbc.anchor = GridBagConstraints.CENTER;
        gbc.weighty = 100;
        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridheight = 1;

        m_BackfillEndTime.setText(dateTime);
        m_panel.addGBComponent(new JLabel( "End Date/Time"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_BackfillEndTime, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER) ;
        m_panel.addGBComponent(new JLabel( "Duration"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_BackfillDuration, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER) ;
        m_panel.addGBComponent(new JLabel( "Bar Size Setting (1 to 11)"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_BarSizeSetting, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER) ;
        m_panel.addGBComponent(new JLabel( "What to Show"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_WhatToShow, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER) ;
        m_panel.addGBComponent(new JLabel( "Regular Trading Hours (1 or 0)"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_UseRTH, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER) ;
        m_panel.addGBComponent(new JLabel( "Date Format Style (1 or 2)"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_FormatDate, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER) ;
        m_panel.addGBComponent(new JLabel( "Keep up to date"), gbc, COL1_WIDTH, GridBagConstraints.RELATIVE) ;
        m_panel.addGBComponent(m_keepUpToDateCheckBox, gbc, COL2_WIDTH, GridBagConstraints.REMAINDER);
        
        getContentPane().add(m_panel);
        pack();
    }
    
    private static String pad(int val) {
        return val < 10 ? "0" + val : "" + val;
    }
    
    @Override
    protected void onOk() {
        m_backfillEndTime = m_BackfillEndTime.getText();
        m_backfillDuration = m_BackfillDuration.getText();
        m_barSizeSetting = m_BarSizeSetting.getText();
        m_useRTH = m_UseRTH.isSelected();
        m_whatToShow = m_WhatToShow.getText();
        m_formatDate = Integer.parseInt( m_FormatDate.getText() );
        m_keepUpToDate = m_keepUpToDateCheckBox.isSelected();
        
        super.onOk();
    }    

}
