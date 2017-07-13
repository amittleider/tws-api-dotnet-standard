package apidemo;

import java.util.List;

import javax.swing.table.AbstractTableModel;

import com.ib.client.HistoricalTickBidAsk;

class HistoricalTickBidAskModel extends AbstractTableModel {

    private List<HistoricalTickBidAsk> m_rows;

    public HistoricalTickBidAskModel(List<HistoricalTickBidAsk> rows) {
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
        HistoricalTickBidAsk row = m_rows.get(rowIndex);
                
        switch (columnIndex) {
            case 0: return row.time();
            case 1: return row.mask();
            case 2: return row.priceBid();
            case 3: return row.priceAsk();
            case 4: return row.sizeBid();
            case 5: return row.sizeAsk();
        }
        
        return null;
    }

    @Override
    public String getColumnName(int column) {
        switch (column) {
            case 0: return "Time";
            case 1: return "Mask";
            case 2: return "Price Bid";
            case 3: return "Price Ask";
            case 4: return "Size Bid";
            case 5: return "Size Ask";
        }

        return super.getColumnName(column);
    }

}
