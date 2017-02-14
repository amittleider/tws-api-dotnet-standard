/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package apidemo;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.util.AbstractMap.SimpleEntry;
import java.util.List;
import java.util.Map.Entry;

import javax.swing.JComponent;

public class Histogram extends JComponent {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private static final int m_barHeight = 15;
	private final List<Entry<Double, Long>> m_rows;
	int m_width;
	private static final int m_x0 = 40;
	
	public Histogram(List<Entry<Double, Long>> rows) {
		m_rows = rows;
	}
	
	@Override protected void paintComponent(Graphics g) {
		int y = 0;
		long max = getMax();

		m_width = getWidth() - m_x0;
		
		for (Entry<Double, Long> bar : m_rows) {
			int x1 = (int)((bar.getValue() * m_width) / max);

			String label = bar.getKey() + "";
			
			g.setColor(Color.red);
			g.fillRect(m_x0, y, x1, m_barHeight);
			g.setColor(Color.black);
			g.drawString(label, 0, y + m_barHeight - 3);
			g.drawRect(m_x0, y, x1, m_barHeight);

			y += m_barHeight;
		}
	}

	long getMax() {
		return m_rows.stream().map(i -> i.getValue()).max((a, b) -> Long.compare(a, b)).orElse((long) -1);
	}
		
	@Override public Dimension getPreferredSize() {// why on main screen 1 is okay but not here?
		return new Dimension(100, m_rows.size() * m_barHeight);
	}

}
