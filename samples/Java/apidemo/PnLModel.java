package apidemo;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.Hashtable;
import java.util.List;

import javax.swing.table.AbstractTableModel;

public class PnLModel extends AbstractTableModel {

    private class PnLItem {
        
        public PnLItem(double dailyPnL, double unrealizedPnL) {
            m_dailyPnL = dailyPnL;
            m_unrealizedPnL = unrealizedPnL;
        }
        
        public double dailyPnL() {
            return m_dailyPnL;
        }

        public double unrealizedPnL() {
            return m_unrealizedPnL;
        }

        private double m_dailyPnL;
        private double m_unrealizedPnL;
        
    }
    
    private List<PnLItem> m_rows = new ArrayList<>();
    private static Dictionary<Integer, String> columnNames = new Hashtable<>();
    
    static {
        columnNames.put(0, "Daily Pnl");
        columnNames.put(1, "Unrealized PnL");
    }
    
    @Override
    public String getColumnName(int column) {
        return columnNames.get(column);
    }
    
    @Override
    public int getRowCount() {
        return m_rows.size();
    }

    @Override
    public int getColumnCount() {
        return 2;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        PnLItem item = m_rows.get(rowIndex);
        
        return columnIndex == 0 ? item.dailyPnL() : item.unrealizedPnL();
    }

    public void addRow(double dailyPnL, double unrealizedPnL) {
        m_rows.add(new PnLItem(dailyPnL, unrealizedPnL));
        
        fireTableDataChanged();
    }

}
