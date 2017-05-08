package apidemo;

import java.util.ArrayList;
import java.util.List;

import javax.swing.table.AbstractTableModel;

public class DailyPnLSingleModel extends AbstractTableModel {

    @Override
    public String getColumnName(int column) {
        switch (column) {
            case 0:
                return "Pos";
            case 1:
                return "Daily PnL";
            case 2:
                return "Value";
            default:
                return super.getColumnName(column);
        }
    }

    class Row {
        int m_pos;
        double m_dailyPnL;
        double m_value;
        
        public Row(int pos, double dailyPnL, double value) {
            this.m_pos = pos;
            this.m_dailyPnL = dailyPnL;
            this.m_value = value;
        }
    }
    
    List<Row> m_rows = new ArrayList<>();       
    
    @Override
    public int getRowCount() {
        return m_rows.size();
    }

    @Override
    public int getColumnCount() {
        return 3;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        Row r = m_rows.get(rowIndex);
        
        switch (columnIndex) {
            case 0:
                return r.m_pos;
            case 1:
                return r.m_dailyPnL;            
            case 2:
                return r.m_value;
            default:
                return null;
        }
    }

    public void addRow(int pos, double dailyPnL, double value) {
        m_rows.add(new Row(pos, dailyPnL, value));
        
        fireTableDataChanged();
    }

}
