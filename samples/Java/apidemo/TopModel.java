/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package apidemo;

import static com.ib.controller.Formats.fmt;
import static com.ib.controller.Formats.fmtPct;
import static com.ib.controller.Formats.fmtTime;

import java.util.ArrayList;

import javax.swing.table.AbstractTableModel;

import com.ib.client.Contract;
import com.ib.client.MarketDataType;
import com.ib.client.TickAttr;
import com.ib.client.TickType;
import com.ib.controller.ApiController.TopMktDataAdapter;
import com.ib.controller.Formats;

class TopModel extends AbstractTableModel {
	private ArrayList<TopRow> m_rows = new ArrayList<TopRow>();

	void addRow( Contract contract) {
		TopRow row = new TopRow( this, contract.description() );
		m_rows.add( row);
		ApiDemo.INSTANCE.controller().reqTopMktData(contract, "", false, row);
		fireTableRowsInserted( m_rows.size() - 1, m_rows.size() - 1);
	}

	void addRow( TopRow row) {
		m_rows.add( row);
		fireTableRowsInserted( m_rows.size() - 1, m_rows.size() - 1);
	}

	void removeSelectedRows() {
		for(int rowIndex = m_rows.size() - 1; rowIndex >= 0; rowIndex--) {
			if(m_rows.get(rowIndex).m_cancel) {
				ApiDemo.INSTANCE.controller().cancelTopMktData( m_rows.get(rowIndex));
				m_rows.remove(rowIndex);
			}
		}		
		fireTableDataChanged();
	}
	
	public void desubscribe() {
		for (TopRow row : m_rows) {
			ApiDemo.INSTANCE.controller().cancelTopMktData( row);
		}
	}

	@Override public Class<?> getColumnClass(int columnIndex) {
		switch (columnIndex) {
		case 12:
			return Boolean.class;
		default:
			return String.class;
		}
	}

	@Override public boolean isCellEditable(int rowIndex, int columnIndex) {
		return columnIndex == 12 ? true : false;
	}

	@Override public int getRowCount() {
		return m_rows.size();
	}

	@Override public int getColumnCount() {
		return 13;
	}

	@Override public String getColumnName(int col) {
		switch( col) {
			case 0: return "Description";
			case 1: return "Bid Size";
			case 2: return "Bid";
			case 3: return "Ask";
			case 4: return "Ask Size";
			case 5: return "Last";
			case 6: return "Time";
			case 7: return "Change";
			case 8: return "Volume";
			case 9: return "Close";
			case 10: return "Open";
			case 11: return "Market Data Type";
			case 12: return "Cancel";
			default: return null;
		}
	}

	@Override public Object getValueAt(int rowIn, int col) {
		TopRow row = m_rows.get( rowIn);
		switch( col) {
			case 0: return row.m_description;
			case 1: return row.m_bidSize;
			case 2: return fmt( row.m_bid);
			case 3: return fmt( row.m_ask);
			case 4: return row.m_askSize;
			case 5: return fmt( row.m_last);
			case 6: return fmtTime( row.m_lastTime);
			case 7: return row.change();
			case 8: return Formats.fmt0( row.m_volume);
			case 9: return fmt( row.m_close);
			case 10: return fmt( row.m_open);
			case 11: return row.m_marketDataType;
			case 12: return row.m_cancel;
			default: return null;
		}
	}

	@Override public void setValueAt(Object aValue, int rowIn, int col) {
		TopRow row = m_rows.get( rowIn);
		switch (col) {
		case 12:
			row.m_cancel = (Boolean) aValue;
			break;
		default:
			break;
		}
	}	

	public void cancel(int i) {
		ApiDemo.INSTANCE.controller().cancelTopMktData( m_rows.get( i) );
	}

	static class TopRow extends TopMktDataAdapter {
		AbstractTableModel m_model;
		String m_description;
		double m_bid;
		double m_ask;
		double m_last;
		long m_lastTime;
		int m_bidSize;
		int m_askSize;
		double m_close;
		int m_volume;
		double m_open;
		boolean m_cancel;
		String m_marketDataType = MarketDataType.getField(MarketDataType.REALTIME);
		
		TopRow( AbstractTableModel model, String description) {
			m_model = model;
			m_description = description;
		}

		public String change() {
			return m_close == 0	? null : fmtPct( (m_last - m_close) / m_close);
		}

		@Override public void tickPrice( TickType tickType, double price, TickAttr attribs) {
			if ( m_marketDataType.equalsIgnoreCase(MarketDataType.getField(MarketDataType.REALTIME)) &&
					(tickType == TickType.DELAYED_BID || 
					tickType == TickType.DELAYED_ASK ||
					tickType == TickType.DELAYED_LAST || 
					tickType == TickType.DELAYED_CLOSE || 
					tickType == TickType.DELAYED_OPEN )) {
				m_marketDataType = MarketDataType.getField(MarketDataType.DELAYED);
			}

			switch( tickType) {
				case BID:
				case DELAYED_BID:
					m_bid = price;
					break;
				case ASK:
				case DELAYED_ASK:
					m_ask = price;
					break;
				case LAST:
				case DELAYED_LAST:
					m_last = price;
					break;
				case CLOSE:
				case DELAYED_CLOSE:
					m_close = price;
					break;
				case OPEN:
				case DELAYED_OPEN:
					m_open = price;
					break;
				default: break;	
			}
			m_model.fireTableDataChanged(); // should use a timer to be more efficient
		}

		@Override public void tickSize( TickType tickType, int size) {
			if ( m_marketDataType.equalsIgnoreCase(MarketDataType.getField(MarketDataType.REALTIME)) &&
					(tickType == TickType.DELAYED_BID_SIZE || 
					tickType == TickType.DELAYED_ASK_SIZE ||
					tickType == TickType.DELAYED_VOLUME)) {
				m_marketDataType = MarketDataType.getField(MarketDataType.DELAYED);
			}
			
			switch( tickType) {
				case BID_SIZE:
				case DELAYED_BID_SIZE:
					m_bidSize = size;
					break;
				case ASK_SIZE:
				case DELAYED_ASK_SIZE:
					m_askSize = size;
					break;
				case VOLUME:
				case DELAYED_VOLUME:
					m_volume = size;
					break;
				default: break; 
			}
			m_model.fireTableDataChanged();
		}

		@Override public void tickString(TickType tickType, String value) {
			switch( tickType) {
				case LAST_TIMESTAMP:
					m_lastTime = Long.parseLong( value) * 1000;
					break;
				default: break; 
			}
		}

		@Override public void marketDataType(int marketDataType) {
			m_marketDataType = MarketDataType.getField(marketDataType);
			m_model.fireTableDataChanged();
		}
	}
}
