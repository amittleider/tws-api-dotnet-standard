package com.ib.client;

import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;

import com.sun.xml.internal.ws.util.ByteArrayBuffer;

public class EMessage {
	ByteArrayBuffer m_buf;
	
	public EMessage(byte[] buf) {
		m_buf = new ByteArrayBuffer(buf);
	}
	
	public EMessage(Builder buf) {
		m_buf = new ByteArrayBuffer();
		
		try {
			buf.writeTo(new DataOutputStream(m_buf));
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public InputStream getStream() {
		return m_buf.newInputStream();
	}
	
	public byte[] getRawData() {
		byte[] buf = new byte[m_buf.size()];
		
		System.arraycopy(m_buf.getRawData(), 0, buf, 0, buf.length);
		
		return buf;
	}
}
