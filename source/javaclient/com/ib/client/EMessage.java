package com.ib.client;

import java.io.ByteArrayInputStream;
import java.io.InputStream;

public class EMessage {
	byte[] m_buf;
	
	public EMessage(byte[] buf) {
		m_buf = buf;
	}
	
	public InputStream getStream() {
		return new ByteArrayInputStream(m_buf);
	}
}
