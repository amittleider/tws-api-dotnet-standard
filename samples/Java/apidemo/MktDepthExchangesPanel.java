/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package apidemo;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.util.ArrayList;

import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.table.AbstractTableModel;

import com.ib.client.DepthMktDataDescription;
import com.ib.controller.ApiController.IMktDepthExchangesHandler;

import apidemo.AccountInfoPanel.Table;
import apidemo.util.HtmlButton;
import apidemo.util.NewTabbedPanel.NewTabPanel;
import apidemo.util.VerticalPanel;


public class MktDepthExchangesPanel extends NewTabPanel {
	private MktDepthExchangesModel m_model = new MktDepthExchangesModel();

	MktDepthExchangesPanel() {
		HtmlButton reqMktDepthExchangesButton = new HtmlButton( "Request Market Depth Exchanges") {
			protected void actionPerformed() {
				reqMktDepthExchanges();
			}
		};

		HtmlButton clearMktDepthExchangesButton = new HtmlButton( "Clear MarketDepth Exchanges") {
			protected void actionPerformed() {
				clearMktDepthExchanges();
			}
		};

		JPanel buts = new VerticalPanel();
		buts.add( reqMktDepthExchangesButton);
		buts.add( clearMktDepthExchangesButton);

		JTable table = new Table( m_model, 2);
		JScrollPane scroll = new JScrollPane( table);
		scroll.setPreferredSize(new Dimension(100, 100));
		setLayout( new BorderLayout() );
		add( scroll);
		add( buts, BorderLayout.EAST);
	}

	/** Called when the tab is first visited. */
	@Override public void activated() { /* noop */ }

	/** Called when the tab is closed by clicking the X. */
	@Override public void closed() {
		clearMktDepthExchanges();
	}

	private void reqMktDepthExchanges() {
		ApiDemo.INSTANCE.controller().reqMktDepthExchanges( m_model);
	}

	private void clearMktDepthExchanges() {
		m_model.clear();
	}

	private class MktDepthExchangesModel extends AbstractTableModel implements IMktDepthExchangesHandler {
		ArrayList<DepthMktDataDescriptionRow> m_list = new ArrayList<>();

		@Override public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions) {
			for (DepthMktDataDescription depthMktDataDescription : depthMktDataDescriptions){
				DepthMktDataDescriptionRow row = new DepthMktDataDescriptionRow();
				m_list.add( row);
				row.update(depthMktDataDescription.exchange(), depthMktDataDescription.secType(), depthMktDataDescription.isL2());
			}
			m_model.fireTableDataChanged();
		}

		public void clear() {
			m_list.clear();
			fireTableDataChanged();
		}

		@Override public int getRowCount() {
			return m_list.size();
		}

		@Override public int getColumnCount() {
			return 3;
		}

		@Override public String getColumnName(int col) {
			switch( col) {
				case 0: return "Exchange";
				case 1: return "Security Type";
				case 2: return "Is L2";
				default: return null;
			}
		}

		@Override public Object getValueAt(int rowIn, int col) {
			DepthMktDataDescriptionRow row = m_list.get( rowIn);
			
			switch( col) {
				case 0: return row.m_exchange;
				case 1: return row.m_secType;
				case 2: return row.m_isL2;
				default: return null;
			}
		}
	}

	private static class DepthMktDataDescriptionRow {
		String m_exchange;
		String m_secType;
		boolean m_isL2;

		void update(String exchange, String secType, boolean isL2) {
			m_exchange = exchange;
			m_secType = secType;
			m_isL2 = isL2;
		}
	}
}
