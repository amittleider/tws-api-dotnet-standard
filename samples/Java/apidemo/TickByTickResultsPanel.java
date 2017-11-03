package apidemo;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JLabel;
import javax.swing.JScrollPane;
import javax.swing.JTable;

import com.ib.client.TickAttr;
import com.ib.client.TickByTick;
import com.ib.client.Types.TickByTickType;
import com.ib.controller.ApiController.ITickByTickDataHandler;

import apidemo.util.NewTabbedPanel.NewTabPanel;
import apidemo.util.VerticalPanel.StackPanel;

class TickByTickResultsPanel extends NewTabPanel implements ITickByTickDataHandler {

    private JTable m_table;
    private final List<TickByTick> m_tickByTickRows = new ArrayList<>(); 
    private final TickByTickModel m_tickModel;

    TickByTickResultsPanel(TickByTickType tickType) {
        m_tickModel = new TickByTickModel(m_tickByTickRows, tickType);
        m_table = new JTable(m_tickModel);
        JScrollPane scroll = new JScrollPane(m_table) {
            public Dimension getPreferredSize() {
                Dimension d = super.getPreferredSize();
                
                d.width = 500;
                
                return d;
            }
        };

        setLayout(new GridLayout());
        StackPanel hTicksPanel = new StackPanel();
        
        hTicksPanel.add(new JLabel("Tick-By-Tick: " + tickType.toString()));
        hTicksPanel.add(scroll, BorderLayout.WEST);
        add(hTicksPanel);
    }

    @Override
    public void tickByTickAllLast(int reqId, int tickType, long time, double price, int size, TickAttr attribs,
            String exchange, String specialConditions) {
        TickByTick tick = new TickByTick(tickType, time, price, size, attribs, exchange, specialConditions);
        m_tickByTickRows.add(tick);

        m_table.setModel(m_tickModel);
        m_tickModel.fireTableDataChanged();
    }

    @Override
    public void tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, int bidSize, int askSize,
            TickAttr attribs) {
        TickByTick tick = new TickByTick(time, bidPrice, bidSize, askPrice, askSize, attribs);
        m_tickByTickRows.add(tick);

        m_table.setModel(m_tickModel);
        m_tickModel.fireTableDataChanged();
	}

    @Override
    public void activated() { }

    @Override
    public void closed() {
        ApiDemo.INSTANCE.controller().cancelTickByTickData( this);
    }
}