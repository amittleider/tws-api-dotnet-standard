/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package apidemo;

import java.awt.BorderLayout;
import java.awt.Desktop;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileWriter;
import java.util.AbstractMap.SimpleEntry;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.JCheckBox;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.SwingUtilities;
import javax.swing.table.AbstractTableModel;
import javax.swing.table.TableCellRenderer;

import com.ib.client.Contract;
import com.ib.client.ContractDescription;
import com.ib.client.ContractDetails;
import com.ib.client.MarketDataType;
import com.ib.client.ScannerSubscription;
import com.ib.client.Types.BarSize;
import com.ib.client.Types.DeepSide;
import com.ib.client.Types.DeepType;
import com.ib.client.Types.DurationUnit;
import com.ib.client.Types.MktDataType;
import com.ib.client.Types.WhatToShow;
import com.ib.controller.ApiController.IDeepMktDataHandler;
import com.ib.controller.ApiController.IHistoricalDataHandler;
import com.ib.controller.ApiController.IRealTimeBarHandler;
import com.ib.controller.ApiController.IScannerHandler;
import com.ib.controller.ApiController.ISecDefOptParamsReqHandler;
import com.ib.controller.ApiController.ISmartComponentsHandler;
import com.ib.controller.ApiController.ISymbolSamplesHandler;
import com.ib.controller.Bar;
import com.ib.controller.Instrument;
import com.ib.controller.ScanCode;

import apidemo.util.HtmlButton;
import apidemo.util.NewTabbedPanel;
import apidemo.util.NewTabbedPanel.NewTabPanel;
import apidemo.util.TCombo;
import apidemo.util.UpperField;
import apidemo.util.VerticalPanel;
import apidemo.util.VerticalPanel.StackPanel;

public class MarketDataPanel extends JPanel {
	private final Contract m_contract = new Contract();
	private final NewTabbedPanel m_requestPanel = new NewTabbedPanel();
	private final NewTabbedPanel m_resultsPanel = new NewTabbedPanel();
	private TopResultsPanel m_topResultPanel;
	private Set<String> m_bboExchanges = new HashSet<>();
	private RequestSmartComponentsPanel m_smartComponentsPanel = new RequestSmartComponentsPanel();
	private SmartComponentsResPanel m_smartComponetnsResPanel = null;
	
	MarketDataPanel() {
		m_requestPanel.addTab( "Top Market Data", new TopRequestPanel(this) );
		m_requestPanel.addTab( "Deep Book", new DeepRequestPanel() );
		m_requestPanel.addTab( "Historical Data", new HistRequestPanel() );
		m_requestPanel.addTab( "Real-time Bars", new RealtimeRequestPanel() );
		m_requestPanel.addTab( "Market Scanner", new ScannerRequestPanel(this) );
		m_requestPanel.addTab("Security defininition optional parameters", new SecDefOptParamsPanel());
		m_requestPanel.addTab( "Matching Symbols", new RequestMatchingSymbolsPanel());
		m_requestPanel.addTab( "Market Depth Exchanges", new MktDepthExchangesPanel() );
		m_requestPanel.addTab("Smart Components", m_smartComponentsPanel);
		
		setLayout( new BorderLayout() );
		add( m_requestPanel, BorderLayout.NORTH);
		add( m_resultsPanel);
	}
	
	public void addBboExch(String exch) {
		m_bboExchanges.add(exch);
		m_smartComponentsPanel.updateBboExchSet(m_bboExchanges);
	}
	
	private class RequestSmartComponentsPanel extends JPanel {
		final TCombo<String> m_BBOExchList = new TCombo<String>(m_bboExchanges.toArray(new String[0]));
		
		public RequestSmartComponentsPanel() {			
            HtmlButton requestSmartComponentsButton = new HtmlButton( "Request Smart Components") {
                @Override protected void actionPerformed() {
                	onRequestSmartComponents();
                }
            };

            VerticalPanel paramsPanel = new VerticalPanel();
            paramsPanel.add( "BBO Exchange", m_BBOExchList, Box.createHorizontalStrut(10), requestSmartComponentsButton);
            setLayout( new BorderLayout() );
            add( paramsPanel, BorderLayout.NORTH);
		}
		
		public void updateBboExchSet(Set<String> m_bboExchanges) {
			m_BBOExchList.removeAllItems();
			
			for (String item : m_bboExchanges) {
				m_BBOExchList.addItem(item);
			}
		}

		protected void onRequestSmartComponents() {
			if (m_smartComponetnsResPanel == null) {
				m_smartComponetnsResPanel = new SmartComponentsResPanel();

				m_resultsPanel.addTab( "Smart Components ", m_smartComponetnsResPanel, true, true);
			}
			
			
			ApiDemo.INSTANCE.controller().reqSmartComponents(m_BBOExchList.getSelectedItem(), m_smartComponetnsResPanel);
		}
	}
	
	private class SmartComponentsResPanel extends NewTabPanel implements ISmartComponentsHandler {
		
        final SmartComponentsModel m_model = new SmartComponentsModel();
        final ArrayList<SmartComponentsRow> m_rows = new ArrayList<>();
        final JTable m_table = new JTable(m_model);

        public SmartComponentsResPanel() {
			JScrollPane scroll = new JScrollPane( m_table);
			
			setLayout(new BorderLayout());
			add(scroll);
		}

        /** Called when the tab is first visited. */
        @Override public void activated() { /* noop */ }

        /** Called when the tab is closed by clicking the X. */
        @Override public void closed() { m_smartComponetnsResPanel = null; }

		@Override
		public void smartComponents(int reqId, Map<Integer, SimpleEntry<String, Character>> theMap) {
            for (Map.Entry<Integer, SimpleEntry<String, Character>> entry : theMap.entrySet()) {
                SmartComponentsRow symbolSamplesRow = new SmartComponentsRow(
                		reqId,
                		entry.getKey(),
                		entry.getValue().getKey(),
                		entry.getValue().getValue()
                        );
                
                m_rows.add( symbolSamplesRow);
            }
            
            SwingUtilities.invokeLater( new Runnable() {
                @Override public void run() {
                    m_model.fireTableRowsInserted( m_rows.size() - 1, m_rows.size() - 1);
                    revalidate();
                    repaint();
                }
           });
        }

        class SmartComponentsModel extends AbstractTableModel {
            @Override public int getRowCount() {
                return m_rows.size();
            }

            @Override public int getColumnCount() {
                return 4;
            }

            @Override public String getColumnName(int col) {
                switch( col) {
                    case 0: return "Req Id";
                    case 1: return "Bit Number";
                    case 2: return "Exchange";
                    case 3: return "Exchange single-letter abbreviation";
                    default: return null;
                }
            }

            @Override public Object getValueAt(int rowIn, int col) {
            	SmartComponentsRow symbolSamplesRow = m_rows.get( rowIn);
                switch( col) {
                    case 0: return symbolSamplesRow.m_reqId;
                    case 1: return symbolSamplesRow.m_bitNum;
                    case 2: return symbolSamplesRow.m_exch;
                    case 3: return symbolSamplesRow.m_exchLetter;
                    default: return null;
                }
            }
        }

        private class SmartComponentsRow {
            int m_reqId;
            int m_bitNum;
            String m_exch;
            char m_exchLetter;

            public SmartComponentsRow(int reqId, int bitNum, String exch, char exchLetter) {
                m_reqId = reqId;
                m_bitNum = bitNum;
                m_exch = exch;
                m_exchLetter = exchLetter;
            }
        }
		
	}

    private class RequestMatchingSymbolsPanel extends JPanel {
        final UpperField m_pattern = new UpperField();

        RequestMatchingSymbolsPanel() {
            m_pattern.setText( "IBM");
            HtmlButton requestMatchingSymbolsButton = new HtmlButton( "Request Matching Symbols") {
                @Override protected void actionPerformed() {
                    onRequestMatchingSymbols();
                }
            };

            VerticalPanel paramsPanel = new VerticalPanel();
            paramsPanel.add( "Pattern", m_pattern, Box.createHorizontalStrut(10), requestMatchingSymbolsButton);
            setLayout( new BorderLayout() );
            add( paramsPanel, BorderLayout.NORTH);
        }

        protected void onRequestMatchingSymbols() {
            SymbolSamplesPanel symbolSamplesPanel = new SymbolSamplesPanel();
            m_resultsPanel.addTab( "Symbol Samples " + m_pattern.getText(), symbolSamplesPanel, true, true);
            ApiDemo.INSTANCE.controller().reqMatchingSymbols(m_pattern.getText(), symbolSamplesPanel);
        }
    }

    static class SymbolSamplesPanel extends NewTabPanel implements ISymbolSamplesHandler {
        final SymbolSamplesModel m_model = new SymbolSamplesModel();
        final ArrayList<SymbolSamplesRow> m_rows = new ArrayList<SymbolSamplesRow>();

        SymbolSamplesPanel() {
            JTable table = new JTable( m_model);
            JScrollPane scroll = new JScrollPane( table);
            setLayout( new BorderLayout() );
            add( scroll);
        };

        /** Called when the tab is first visited. */
        @Override public void activated() { /* noop */ }

        /** Called when the tab is closed by clicking the X. */
        @Override public void closed() { /* noop */ }

        @Override
        public void symbolSamples(ContractDescription[] contractDescriptions) {
            for (int i = 0; i < contractDescriptions.length; i++) {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < contractDescriptions[i].derivativeSecTypes().length; j++){
                    sb.append(contractDescriptions[i].derivativeSecTypes()[j] + " ");
                }
                SymbolSamplesRow symbolSamplesRow = new SymbolSamplesRow(
                        contractDescriptions[i].contract().conid(),
                        contractDescriptions[i].contract().symbol(),
                        contractDescriptions[i].contract().secType().getApiString(),
                        contractDescriptions[i].contract().primaryExch(),
                        contractDescriptions[i].contract().currency(),
                        sb.toString()						
                        );
                m_rows.add( symbolSamplesRow);
            }
            fire();
        }

        private void fire() {
            SwingUtilities.invokeLater( new Runnable() {
                @Override public void run() {
                    m_model.fireTableRowsInserted( m_rows.size() - 1, m_rows.size() - 1);
                    revalidate();
                    repaint();
                }
           });
        }

        class SymbolSamplesModel extends AbstractTableModel {
            @Override public int getRowCount() {
                return m_rows.size();
            }

            @Override public int getColumnCount() {
                return 6;
            }

            @Override public String getColumnName(int col) {
                switch( col) {
                    case 0: return "ConId";
                    case 1: return "Symbol";
                    case 2: return "SecType";
                    case 3: return "PrimaryExch";
                    case 4: return "Currency";
                    case 5: return "Derivative SecTypes";
                    default: return null;
                }
            }

            @Override public Object getValueAt(int rowIn, int col) {
                SymbolSamplesRow symbolSamplesRow = m_rows.get( rowIn);
                switch( col) {
                    case 0: return symbolSamplesRow.m_conId;
                    case 1: return symbolSamplesRow.m_symbol;
                    case 2: return symbolSamplesRow.m_secType;
                    case 3: return symbolSamplesRow.m_primaryExch;
                    case 4: return symbolSamplesRow.m_currency;
                    case 5: return symbolSamplesRow.m_derivativeSecTypes;
                    default: return null;
                }
            }
        }

        static class SymbolSamplesRow {
            int m_conId;
            String m_symbol;
            String m_secType;
            String m_primaryExch;
            String m_currency;
            String m_derivativeSecTypes;

            public SymbolSamplesRow(int conId, String symbol, String secType, String primaryExch, String currency, String derivativeSecTypes) {
                update( conId, symbol, secType, primaryExch, currency, derivativeSecTypes);
            }

            void update( int conId, String symbol, String secType, String primaryExch, String currency, String derivativeSecTypes) {
                m_conId = conId;
                m_symbol = symbol;
                m_secType = secType;
                m_primaryExch = primaryExch;
                m_currency = currency;
                m_derivativeSecTypes = derivativeSecTypes;
            }
        }
    }
	
	private class TopRequestPanel extends JPanel {
		final ContractPanel m_contractPanel = new ContractPanel(m_contract);
		protected TCombo<String> m_marketDataType = new TCombo<String>( MarketDataType.getFields() );
		MarketDataPanel m_parentPanel;
		
		TopRequestPanel(MarketDataPanel parentPanel) {
			m_marketDataType.setSelectedItem( MarketDataType.REALTIME);
			m_parentPanel = parentPanel;
			
			HtmlButton reqTop = new HtmlButton( "Request Top Market Data") {
				@Override protected void actionPerformed() {
					onTop();
				}
			};

			HtmlButton cancelTop = new HtmlButton( "Cancel Top Market Data") {
				@Override protected void actionPerformed() {
					onCancelTop();
				}
			};

			m_marketDataType.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent event) {
					ApiDemo.INSTANCE.controller().reqMktDataType( MarketDataType.getField(m_marketDataType.getSelectedItem()));
				}
			});

			VerticalPanel paramPanel = new VerticalPanel();
			paramPanel.add( "Market data type", m_marketDataType);

			VerticalPanel butPanel = new VerticalPanel();
			butPanel.add( Box.createVerticalStrut( 40));
			butPanel.add( reqTop);
			butPanel.add( cancelTop);

			JPanel rightPanel = new StackPanel();
			rightPanel.add( paramPanel);
			rightPanel.add( Box.createVerticalStrut( 20));
			rightPanel.add( butPanel);

			setLayout( new BoxLayout( this, BoxLayout.X_AXIS) );
			add( m_contractPanel);
			add( Box.createHorizontalStrut(20));
			add( rightPanel);
		}

		protected void onTop() {
			m_contractPanel.onOK();
			if (m_topResultPanel == null) {
				m_topResultPanel = new TopResultsPanel(m_parentPanel);
				m_resultsPanel.addTab( "Top Data", m_topResultPanel, true, true);
			}
			
			m_topResultPanel.m_model.addRow( m_contract);
		}

		protected void onCancelTop() {
			m_topResultPanel.m_model.removeSelectedRows();
		}
	}
	
	private class TopResultsPanel extends NewTabPanel {
		final TopModel m_model;
		final JTable m_tab;

		TopResultsPanel(MarketDataPanel parentPanel) {
			m_model = new TopModel(parentPanel);
			m_tab = new TopTable( m_model);

			JScrollPane scroll = new JScrollPane( m_tab);
			
			setLayout( new BorderLayout() );
			add( scroll);
		}
		
		/** Called when the tab is first visited. */
		@Override public void activated() {
		}

		/** Called when the tab is closed by clicking the X. */
		@Override public void closed() {
			m_model.desubscribe();
			m_topResultPanel = null;
		}

		class TopTable extends JTable {
			public TopTable(TopModel model) { super( model); }
		}
	}		
	
	private class DeepRequestPanel extends JPanel {
		final ContractPanel m_contractPanel = new ContractPanel(m_contract);
		
		DeepRequestPanel() {
			HtmlButton reqDeep = new HtmlButton( "Request Deep Market Data") {
				@Override protected void actionPerformed() {
					onDeep();
				}
			};
			
			VerticalPanel butPanel = new VerticalPanel();
			butPanel.add( reqDeep);
			
			setLayout( new BoxLayout( this, BoxLayout.X_AXIS) );
			add( m_contractPanel);
			add( Box.createHorizontalStrut(20));
			add( butPanel);
		}

		protected void onDeep() {
			m_contractPanel.onOK();
			DeepResultsPanel resultPanel = new DeepResultsPanel();
			m_resultsPanel.addTab( "Deep " + m_contract.symbol(), resultPanel, true, true);
			ApiDemo.INSTANCE.controller().reqDeepMktData(m_contract, 6, resultPanel);
		}
	}

	private static class DeepResultsPanel extends NewTabPanel implements IDeepMktDataHandler {
		final DeepModel m_buy = new DeepModel();
		final DeepModel m_sell = new DeepModel();

		DeepResultsPanel() {
			HtmlButton desub = new HtmlButton( "Desubscribe") {
				public void actionPerformed() {
					onDesub();
				}
			};
			
			JTable buyTab = new JTable( m_buy);
			JTable sellTab = new JTable( m_sell);
			
			JScrollPane buyScroll = new JScrollPane( buyTab);
			JScrollPane sellScroll = new JScrollPane( sellTab);
			
			JPanel mid = new JPanel( new GridLayout( 1, 2) );
			mid.add( buyScroll);
			mid.add( sellScroll);
			
			setLayout( new BorderLayout() );
			add( mid);
			add( desub, BorderLayout.SOUTH);
		}
		
		protected void onDesub() {
			ApiDemo.INSTANCE.controller().cancelDeepMktData( this);
		}

		@Override public void activated() {
		}

		/** Called when the tab is closed by clicking the X. */
		@Override public void closed() {
			ApiDemo.INSTANCE.controller().cancelDeepMktData( this);
		}
		
		@Override public void updateMktDepth(int pos, String mm, DeepType operation, DeepSide side, double price, int size) {
			if (side == DeepSide.BUY) {
				m_buy.updateMktDepth(pos, mm, operation, price, size);
			}
			else {
				m_sell.updateMktDepth(pos, mm, operation, price, size);
			}
		}

		class DeepModel extends AbstractTableModel {
			final ArrayList<DeepRow> m_rows = new ArrayList<DeepRow>();

			@Override public int getRowCount() {
				return m_rows.size();
			}

			public void updateMktDepth(int pos, String mm, DeepType operation, double price, int size) {
				switch( operation) {
					case INSERT:
						m_rows.add( pos, new DeepRow( mm, price, size) );
						fireTableRowsInserted(pos, pos);
						break;
					case UPDATE:
						m_rows.get( pos).update( mm, price, size);
						fireTableRowsUpdated(pos, pos);
						break;
					case DELETE:
						if (pos < m_rows.size() ) {
							m_rows.remove( pos);
						}
						else {
							// this happens but seems to be harmless
							// System.out.println( "can't remove " + pos);
						}
						fireTableRowsDeleted(pos, pos);
						break;
				}
			}

			@Override public int getColumnCount() {
				return 3;
			}
			
			@Override public String getColumnName(int col) {
				switch( col) {
					case 0: return "Mkt Maker";
					case 1: return "Price";
					case 2: return "Size";
					default: return null;
				}
			}

			@Override public Object getValueAt(int rowIn, int col) {
				DeepRow row = m_rows.get( rowIn);
				
				switch( col) {
					case 0: return row.m_mm;
					case 1: return row.m_price;
					case 2: return row.m_size;
					default: return null;
				}
			}
		}
		
		static class DeepRow {
			String m_mm;
			double m_price;
			int m_size;

			public DeepRow(String mm, double price, int size) {
				update( mm, price, size);
			}
			
			void update( String mm, double price, int size) {
				m_mm = mm;
				m_price = price;
				m_size = size;
			}
		}
	}

	private class HistRequestPanel extends JPanel {
		final ContractPanel m_contractPanel = new ContractPanel(m_contract);
		final UpperField m_end = new UpperField();
		final UpperField m_duration = new UpperField();
		final TCombo<DurationUnit> m_durationUnit = new TCombo<DurationUnit>( DurationUnit.values() );
		final TCombo<BarSize> m_barSize = new TCombo<BarSize>( BarSize.values() );
		final TCombo<WhatToShow> m_whatToShow = new TCombo<WhatToShow>( WhatToShow.values() );
		final JCheckBox m_rthOnly = new JCheckBox();
		
		HistRequestPanel() { 		
			m_end.setText( "20120101 12:00:00");
			m_duration.setText( "1");
			m_durationUnit.setSelectedItem( DurationUnit.WEEK);
			m_barSize.setSelectedItem( BarSize._1_hour);
			
			HtmlButton button = new HtmlButton( "Request historical data") {
				@Override protected void actionPerformed() {
					onHistorical();
				}
			};
			
	    	VerticalPanel paramPanel = new VerticalPanel();
			paramPanel.add( "End", m_end);
			paramPanel.add( "Duration", m_duration);
			paramPanel.add( "Duration unit", m_durationUnit);
			paramPanel.add( "Bar size", m_barSize);
			paramPanel.add( "What to show", m_whatToShow);
			paramPanel.add( "RTH only", m_rthOnly);
			
			VerticalPanel butPanel = new VerticalPanel();
			butPanel.add( button);
			
			JPanel rightPanel = new StackPanel();
			rightPanel.add( paramPanel);
			rightPanel.add( Box.createVerticalStrut( 20));
			rightPanel.add( butPanel);
			
			setLayout( new BoxLayout( this, BoxLayout.X_AXIS) );
			add( m_contractPanel);
			add( Box.createHorizontalStrut(20) );
			add( rightPanel);
		}
	
		protected void onHistorical() {
			m_contractPanel.onOK();
			BarResultsPanel panel = new BarResultsPanel( true);
			ApiDemo.INSTANCE.controller().reqHistoricalData(m_contract, m_end.getText(), m_duration.getInt(), m_durationUnit.getSelectedItem(), m_barSize.getSelectedItem(), m_whatToShow.getSelectedItem(), m_rthOnly.isSelected(), panel);
			m_resultsPanel.addTab( "Historical " + m_contract.symbol(), panel, true, true);
		}
	}

	private class RealtimeRequestPanel extends JPanel {
		final ContractPanel m_contractPanel = new ContractPanel(m_contract);
		final TCombo<WhatToShow> m_whatToShow = new TCombo<WhatToShow>( WhatToShow.values() );
		final JCheckBox m_rthOnly = new JCheckBox();
		
		RealtimeRequestPanel() { 		
			HtmlButton button = new HtmlButton( "Request real-time bars") {
				@Override protected void actionPerformed() {
					onRealTime();
				}
			};
	
	    	VerticalPanel paramPanel = new VerticalPanel();
			paramPanel.add( "What to show", m_whatToShow);
			paramPanel.add( "RTH only", m_rthOnly);
			
			VerticalPanel butPanel = new VerticalPanel();
			butPanel.add( button);
			
			JPanel rightPanel = new StackPanel();
			rightPanel.add( paramPanel);
			rightPanel.add( Box.createVerticalStrut( 20));
			rightPanel.add( butPanel);
			
			setLayout( new BoxLayout( this, BoxLayout.X_AXIS) );
			add( m_contractPanel);
			add( Box.createHorizontalStrut(20) );
			add( rightPanel);
		}
	
		protected void onRealTime() {
			m_contractPanel.onOK();
			BarResultsPanel panel = new BarResultsPanel( false);
			ApiDemo.INSTANCE.controller().reqRealTimeBars(m_contract, m_whatToShow.getSelectedItem(), m_rthOnly.isSelected(), panel);
			m_resultsPanel.addTab( "Real-time " + m_contract.symbol(), panel, true, true);
		}
	}
	
	static class BarResultsPanel extends NewTabPanel implements IHistoricalDataHandler, IRealTimeBarHandler {
		final BarModel m_model = new BarModel();
		final ArrayList<Bar> m_rows = new ArrayList<Bar>();
		final boolean m_historical;
		final Chart m_chart = new Chart( m_rows);
		
		BarResultsPanel( boolean historical) {
			m_historical = historical;
			
			JTable tab = new JTable( m_model);
			JScrollPane scroll = new JScrollPane( tab) {
				public Dimension getPreferredSize() {
					Dimension d = super.getPreferredSize();
					d.width = 500;
					return d;
				}
			};

			JScrollPane chartScroll = new JScrollPane( m_chart);

			setLayout( new BorderLayout() );
			add( scroll, BorderLayout.WEST);
			add( chartScroll, BorderLayout.CENTER);
		}

		/** Called when the tab is first visited. */
		@Override public void activated() {
		}

		/** Called when the tab is closed by clicking the X. */
		@Override public void closed() {
			if (m_historical) {
				ApiDemo.INSTANCE.controller().cancelHistoricalData( this);
			}
			else {
				ApiDemo.INSTANCE.controller().cancelRealtimeBars( this);
			}
		}

		@Override public void historicalData(Bar bar, boolean hasGaps) {
			m_rows.add( bar);
		}
		
		@Override public void historicalDataEnd() {
			fire();
		}

		@Override public void realtimeBar(Bar bar) {
			m_rows.add( bar); 
			fire();
		}
		
		private void fire() {
			SwingUtilities.invokeLater( new Runnable() {
				@Override public void run() {
					m_model.fireTableRowsInserted( m_rows.size() - 1, m_rows.size() - 1);
					m_chart.repaint();
				}
			});
		}

		class BarModel extends AbstractTableModel {
			@Override public int getRowCount() {
				return m_rows.size();
			}

			@Override public int getColumnCount() {
				return 7;
			}
			
			@Override public String getColumnName(int col) {
				switch( col) {
					case 0: return "Date/time";
					case 1: return "Open";
					case 2: return "High";
					case 3: return "Low";
					case 4: return "Close";
					case 5: return "Volume";
					case 6: return "WAP";
					default: return null;
				}
			}

			@Override public Object getValueAt(int rowIn, int col) {
				Bar row = m_rows.get( rowIn);
				switch( col) {
					case 0: return row.formattedTime();
					case 1: return row.open();
					case 2: return row.high();
					case 3: return row.low();
					case 4: return row.close();
					case 5: return row.volume();
					case 6: return row.wap();
					default: return null;
				}
			}
		}		
	}
	
	private class ScannerRequestPanel extends JPanel {
		final UpperField m_numRows = new UpperField( "15");
		final TCombo<ScanCode> m_scanCode = new TCombo<ScanCode>( ScanCode.values() );
		final TCombo<Instrument> m_instrument = new TCombo<Instrument>( Instrument.values() );
		final UpperField m_location = new UpperField( "STK.US.MAJOR", 9);
		final TCombo<String> m_stockType = new TCombo<String>( "ALL", "STOCK", "ETF");
		private MarketDataPanel m_parentPanel;
		
		ScannerRequestPanel(MarketDataPanel parentPanel) {
			m_parentPanel = parentPanel;
			
			HtmlButton go = new HtmlButton( "Go") {
				@Override protected void actionPerformed() {
					onGo();
				}
			};
			
			VerticalPanel paramsPanel = new VerticalPanel();
			paramsPanel.add( "Scan code", m_scanCode);
			paramsPanel.add( "Instrument", m_instrument);
			paramsPanel.add( "Location", m_location, Box.createHorizontalStrut(10), go);
			paramsPanel.add( "Stock type", m_stockType);
			paramsPanel.add( "Num rows", m_numRows);
			
			setLayout( new BorderLayout() );
			add( paramsPanel, BorderLayout.NORTH);
		}

		protected void onGo() {
			ScannerSubscription sub = new ScannerSubscription();
			sub.numberOfRows( m_numRows.getInt() );
			sub.scanCode( m_scanCode.getSelectedItem().toString() );
			sub.instrument( m_instrument.getSelectedItem().toString() );
			sub.locationCode( m_location.getText() );
			sub.stockTypeFilter( m_stockType.getSelectedItem().toString() );
			
			ScannerResultsPanel resultsPanel = new ScannerResultsPanel(m_parentPanel);
			m_resultsPanel.addTab( sub.scanCode(), resultsPanel, true, true);

			ApiDemo.INSTANCE.controller().reqScannerSubscription( sub, resultsPanel);
		}
	}

	static class ScannerResultsPanel extends NewTabPanel implements IScannerHandler {
		final HashSet<Integer> m_conids = new HashSet<Integer>();
		final TopModel m_model;

		ScannerResultsPanel(MarketDataPanel parentPanel) {
			m_model = new TopModel(parentPanel);
			JTable table = new JTable( m_model);
			JScrollPane scroll = new JScrollPane( table);
			setLayout( new BorderLayout() );
			add( scroll);
		}

		/** Called when the tab is first visited. */
		@Override public void activated() {
		}

		/** Called when the tab is closed by clicking the X. */
		@Override public void closed() {
			ApiDemo.INSTANCE.controller().cancelScannerSubscription( this);
			m_model.desubscribe();
		}

		@Override public void scannerParameters(String xml) {
			try {
				File file = File.createTempFile( "pre", ".xml");
				FileWriter writer = new FileWriter( file);
				writer.write( xml);
				writer.close();

				Desktop.getDesktop().open( file);
			}
			catch (Exception e) {
				e.printStackTrace();
			}
		}

		@Override public void scannerData(int rank, final ContractDetails contractDetails, String legsStr) {
			if (!m_conids.contains( contractDetails.conid() ) ) {
				m_conids.add( contractDetails.conid() );
				SwingUtilities.invokeLater( new Runnable() {
					@Override public void run() {
						m_model.addRow( contractDetails.contract() );
					}
				});
			}
		}

		@Override public void scannerDataEnd() {
			// we could sort here
		}
	}
	
	class SecDefOptParamsPanel extends JPanel {
		
		final UpperField m_underlyingSymbol = new UpperField();
		final UpperField m_futFopExchange = new UpperField();
//		final UpperField m_currency = new UpperField();
		final UpperField m_underlyingSecType = new UpperField();
		final UpperField m_underlyingConId = new UpperField();
		
		SecDefOptParamsPanel() {
			VerticalPanel paramsPanel = new VerticalPanel();
			HtmlButton go = new HtmlButton("Go") { @Override protected void actionPerformed() { onGo(); } };
			
			m_underlyingConId.setText(Integer.MAX_VALUE);			
			paramsPanel.add("Underlying symbol", m_underlyingSymbol);			
			paramsPanel.add("FUT-FOP exchange", m_futFopExchange);			
//			paramsPanel.add("Currency", m_currency);			
			paramsPanel.add("Underlying security type", m_underlyingSecType);			
			paramsPanel.add("Underlying contract id", m_underlyingConId);			
			paramsPanel.add(go);
			setLayout(new BorderLayout());
			add(paramsPanel, BorderLayout.NORTH);
		}

		protected void onGo() {
			String underlyingSymbol = m_underlyingSymbol.getText();
			String futFopExchange = m_futFopExchange.getText();
//			String currency = m_currency.getText();
			String underlyingSecType = m_underlyingSecType.getText();
			int underlyingConId = m_underlyingConId.getInt();
			
			ApiDemo.INSTANCE.controller().reqSecDefOptParams( 
					underlyingSymbol,
					futFopExchange,
//					currency,
					underlyingSecType,
					underlyingConId,
					new ISecDefOptParamsReqHandler() {
						
						@Override
						public void securityDefinitionOptionalParameterEnd(int reqId) { }
						
						@Override
						public void securityDefinitionOptionalParameter(final String exchange, final int underlyingConId, final String tradingClass, final String multiplier,
								final Set<String> expirations, final Set<Double> strikes) {
							SwingUtilities.invokeLater( new Runnable() { @Override public void run() {

								SecDefOptParamsReqResultsPanel resultsPanel = new SecDefOptParamsReqResultsPanel(expirations, strikes);

								m_resultsPanel.addTab(exchange + " " + 
										underlyingConId + " " + 
										tradingClass + " " + 
										multiplier, 
										resultsPanel, true, true);
							}});
						}
					});
		}
		
	}
	
	static class SecDefOptParamsReqResultsPanel extends NewTabPanel {

		final OptParamsModel m_model;
		
		public SecDefOptParamsReqResultsPanel(Set<String> expirations, Set<Double> strikes) {
			JTable table = new JTable(m_model = new OptParamsModel(expirations, strikes));
			JScrollPane scroll = new JScrollPane(table);
			
			setLayout(new BorderLayout());
			add(scroll);
		}
		
		@Override
		public void activated() {
		}

		@Override
		public void closed() {
		}

	}
}
