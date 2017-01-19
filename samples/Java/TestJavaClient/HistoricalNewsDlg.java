/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package TestJavaClient;

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;


public class HistoricalNewsDlg extends JDialog {

    public boolean m_rc;

    private JTextField 	m_requestId = new JTextField("0");
    private JTextField 	m_conId = new JTextField("8314");
    private JTextField 	m_providerCodes = new JTextField("BZ+FLY");
    private JTextField 	m_startDateTime = new JTextField();
    private JTextField 	m_endDateTime = new JTextField();
    private JTextField 	m_totalResults = new JTextField("10");
    private JButton 	m_ok = new JButton( "OK");
    private JButton 	m_cancel = new JButton( "Cancel");

    int m_retRequestId;
    int m_retConId;
    String m_retProviderCodes;
    String m_retStartDateTime;
    String m_retEndDateTime;
    int m_retTotalResults;

    public HistoricalNewsDlg( JFrame owner) {
        super( owner, true);

        DateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.0");
        Calendar cal = Calendar.getInstance();
        cal.add(Calendar.DATE, -3);
        m_endDateTime.setText(df.format(cal.getTime()));
        cal.add(Calendar.DATE, -1);
        m_startDateTime.setText(df.format(cal.getTime()));

        // create button panel
        JPanel buttonPanel = new JPanel();
        buttonPanel.add( m_ok);
        buttonPanel.add( m_cancel);

        // create action listeners
        m_ok.addActionListener( new ActionListener() {
            public void actionPerformed( ActionEvent e) {
                onOk();
            }
        });
        m_cancel.addActionListener( new ActionListener() {
            public void actionPerformed( ActionEvent e) {
                onCancel();
            }
        });

        // create mid summary panel
        JPanel midPanel = new JPanel( new GridLayout( 0, 1, 5, 5) );
        midPanel.add( new JLabel( "Request Id") );
        midPanel.add( m_requestId);
        midPanel.add( new JLabel( "Con Id") );
        midPanel.add( m_conId);
        midPanel.add( new JLabel( "Provider Codes") );
        midPanel.add( m_providerCodes);
        midPanel.add( new JLabel( "Start Date/Time (yyyy-MM-dd HH:mm:ss.0)") );
        midPanel.add( m_startDateTime);
        midPanel.add( new JLabel( "End Date/Time (yyyy-MM-dd HH:mm:ss.0)") );
        midPanel.add( m_endDateTime);
        midPanel.add( new JLabel( "Total Results") );
        midPanel.add( m_totalResults);

        // create dlg box
        getContentPane().add( midPanel, BorderLayout.CENTER);
        getContentPane().add( buttonPanel, BorderLayout.SOUTH);
        setTitle( "Request Historical News");
        pack();
    }

    void onOk() {
        m_rc = false;

        try {
            m_retRequestId = Integer.parseInt( m_requestId.getText());
            m_retConId = Integer.parseInt( m_conId.getText());
            m_retProviderCodes = m_providerCodes.getText().trim();
            m_retStartDateTime = m_startDateTime.getText().trim();
            m_retEndDateTime = m_endDateTime.getText().trim();
            m_retTotalResults = Integer.parseInt( m_totalResults.getText());
        }
        catch( Exception e) {
            Main.inform( this, "Error - " + e);
            return;
        }

        m_rc = true;
        setVisible( false);
    }

    void onCancel() {
        m_rc = false;
        setVisible( false);
    }
}