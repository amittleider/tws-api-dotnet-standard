package apidemo;

import java.util.ArrayList;
import java.util.List;

import javax.swing.table.AbstractTableModel;

public class DailyPnLModel extends AbstractTableModel {

    List<Double> m_rows = new ArrayList<>();
    
    @Override
    public String getColumnName(int column) {
        return "Daily PnL";
    }
    
    @Override
    public int getRowCount() {
        return m_rows.size();
    }

    @Override
    public int getColumnCount() {
        return 1;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        return m_rows.get(rowIndex);
    }

    public void addRow(double dailyPnL) {
        m_rows.add(dailyPnL);
        
        fireTableDataChanged();
    }

}
