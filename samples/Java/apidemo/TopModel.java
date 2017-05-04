/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package apidemo;

import static com.ib.controller.Formats.fmt;
import static com.ib.controller.Formats.fmtPct;
import static com.ib.controller.Formats.fmtTime;

import java.util.ArrayList;
import java.util.List;

import javax.swing.table.AbstractTableModel;

import com.ib.client.Contract;
import com.ib.client.MarketDataType;
import com.ib.client.TickAttr;
import com.ib.client.TickType;
import com.ib.controller.ApiController.TopMktDataAdapter;
import com.ib.controller.Formats;

class TopModel extends AbstractTableModel {
	private List<TopRow> m_rows = new ArrayList<>();
	private MarketDataPanel m_parentPanel;
	private static final int CANCEL_CHBX_COL_INDEX = 22;

	TopModel(MarketDataPanel parentPanel) {
		m_parentPanel = parentPanel;
	}

	void addRow( Contract contract) {
		TopRow row = new TopRow( this, contract.description(), m_parentPanel );
		m_rows.add( row);
		ApiDemo.INSTANCE.controller().reqTopMktData(contract, "588", false, false, row);
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
	
	void desubscribe() {
		for (TopRow row : m_rows) {
			ApiDemo.INSTANCE.controller().cancelTopMktData( row);
		}
	}		

	@Override public Class<?> getColumnClass(int columnIndex) {
		switch (columnIndex) {
		case CANCEL_CHBX_COL_INDEX:
			return Boolean.class;
		default:
			return String.class;
		}
	}

	@Override public boolean isCellEditable(int rowIndex, int columnIndex) {
		return columnIndex == CANCEL_CHBX_COL_INDEX;
	}

	@Override public int getRowCount() {
		return m_rows.size();
	}
	
	@Override public int getColumnCount() {
		return 22;
	}
	
	@Override public String getColumnName(int col) {
		switch( col) {
			case 0: return "Description";
			case 1: return "Bid Size";
			case 2: return "Bid";
			case 3: return "Bid Mask";
			case 4: return "Bid Can Auto Execute";
			case 5: return "Bid Past Limit";
			case 6: return "Ask";
			case 7: return "Ask Size";
			case 8: return "Ask Mask";
			case 9: return "Ask Can Auto Execute";
			case 10: return "Ask Past Limit";
			case 11: return "Last";
			case 12: return "Time";
			case 13: return "Change";
			case 14: return "Volume";
			case 15: return "Min Tick";
			case 16: return "BBO Exchange";
			case 17: return "Snapshot Permissions";
			case 18: return "Close";
			case 19: return "Open";
			case 20: return "Market Data Type";
			case 21: return "Futures Open Interest";
			case CANCEL_CHBX_COL_INDEX: return "Cancel";

			default: return null;
		}
	}

	@Override public Object getValueAt(int rowIn, int col) {
		TopRow row = m_rows.get( rowIn);
		switch( col) {
			case 0: return row.m_description;
			case 1: return row.m_bidSize;
			case 2: return fmt( row.m_bid);
			case 3: return row.m_bidMask;
			case 4: return row.m_bidCanAutoExecute;
			case 5: return row.m_bidPastLimit;
			case 6: return fmt( row.m_ask);
			case 7: return row.m_askSize;
			case 8: return row.m_askMask;
			case 9: return row.m_askCanAutoExecute;
			case 10: return row.m_askPastLimit;
			case 11: return fmt( row.m_last);
			case 12: return fmtTime( row.m_lastTime);
			case 13: return row.change();
			case 14: return Formats.fmt0( row.m_volume);
			case 15: return row.m_minTick;
			case 16: return row.m_bboExch;
			case 17: return row.m_snapshotPermissions;
			case 18: return fmt( row.m_close);
			case 19: return fmt( row.m_open);
			case 20: return row.m_marketDataType;
			case 21: return row.m_futuresOpenInterest;
			case CANCEL_CHBX_COL_INDEX: return row.m_cancel;
			default: return null;
		}
	}

	@Override public void setValueAt(Object aValue, int rowIn, int col) {
		TopRow row = m_rows.get( rowIn);
		switch (col) {
		case CANCEL_CHBX_COL_INDEX:
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
		MarketDataPanel m_parentPanel;
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
		boolean m_frozen;
		boolean m_bidCanAutoExecute, m_askCanAutoExecute;
		boolean m_bidPastLimit, m_askPastLimit;
		double m_minTick;
		String m_bboExch;
		int m_snapshotPermissions;
		int m_bidMask, m_askMask;
		int m_futuresOpenInterest;
		
		TopRow( AbstractTableModel model, String description, MarketDataPanel parentPanel) {
			m_model = model;
			m_description = description;
			m_parentPanel = parentPanel;
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
					m_bidCanAutoExecute = attribs.canAutoExecute();
					m_bidPastLimit = attribs.pastLimit();
					break;
				case ASK:
				case DELAYED_ASK:
					m_ask = price;
					m_askCanAutoExecute = attribs.canAutoExecute();
					m_askPastLimit = attribs.pastLimit();
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
				case FUTURES_OPEN_INTEREST:
					m_futuresOpenInterest = size;
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

		@Override public void tickReqParams(int tickerId, double minTick, String bboExchange, int snapshotPermissions) {
			m_minTick = minTick;
			m_bboExch = bboExchange;
			m_snapshotPermissions = snapshotPermissions;
			
			m_parentPanel.addBboExch(bboExchange);
			m_model.fireTableDataChanged();
		}
	}
}
