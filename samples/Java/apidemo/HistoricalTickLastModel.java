package apidemo;

import java.util.List;

import javax.swing.table.AbstractTableModel;

import com.ib.client.HistoricalTickLast;

class HistoricalTickLastModel extends AbstractTableModel {

    private List<HistoricalTickLast> m_rows;

    public HistoricalTickLastModel(List<HistoricalTickLast> rows) {
        m_rows = rows;
    }

    @Override
    public int getRowCount() {
        return m_rows.size();
    }

    @Override
    public int getColumnCount() {        
        return 6;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        HistoricalTickLast row = m_rows.get(rowIndex);
        
        switch (columnIndex) {
            case 0: return row.time();
            case 1: return row.mask();
            case 2: return row.price();
            case 3: return row.size();
            case 4: return row.exchange();
            case 5: return row.specialConditions();
        }
        return null;
    }

    @Override
    public String getColumnName(int column) { 
        switch (column) {
            case 0: return "Time";
            case 1: return "Mask";
            case 2: return "Price";
            case 3: return "Size";
            case 4: return "Exchange";
            case 5: return "Special conditions";
        }
        return super.getColumnName(column);
    }

}
