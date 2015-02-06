/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.controller;


import java.io.DataInputStream;
import java.io.FilterInputStream;
import java.io.FilterOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Field;
import java.net.Socket;

import com.ib.client.Contract;
import com.ib.client.EClientErrors;
import com.ib.client.EJavaSignal;
import com.ib.client.EWrapper;
import com.ib.client.EClientSocket;
import com.ib.client.EReader;
import com.ib.client.Order;

// NOTE: TWS 936 SERVER_VERSION is 67.

public class ApiConnection extends EClientSocket {
	public interface ILogger {
		void log(String valueOf);
	}

	public static final char EOL = 0;
	public static final char LOG_EOL = '_';

	private final ILogger m_inLogger;
	private final ILogger m_outLogger;
	private static final EJavaSignal m_signal = new EJavaSignal();

	public ApiConnection(EWrapper wrapper, ILogger inLogger, ILogger outLogger) {
		super( wrapper, m_signal);
		m_inLogger = inLogger;
		m_outLogger = outLogger;
	}

	@Override public synchronized void eConnect(Socket socket, int clientId) throws IOException {
		super.eConnect(socket, clientId);

		// replace the output stream with one that logs all data to m_outLogger
		if (isConnected()) {
			try {
				Field realOsField = FilterOutputStream.class.getDeclaredField( "out");
				realOsField.setAccessible( true);
				OutputStream realOs = (OutputStream)realOsField.get( m_dos);
				realOsField.set( m_dos, new MyOS( realOs) );
			}
			catch( Exception e) {
				e.printStackTrace();
			}
		}
	}

	/** Replace the input stream with one that logs all data to m_inLogger. */
	@Override public EReader createReader(EClientSocket socket, DataInputStream dis) {
		try {
			Field realIsField = FilterInputStream.class.getDeclaredField( "in");
			realIsField.setAccessible( true);
			InputStream realIs = (InputStream)realIsField.get( dis);
			realIsField.set( dis, new MyIS( realIs) );
		}
		catch( Exception e) {
			e.printStackTrace();
		}
		return super.createReader(socket, dis);
	}

	public synchronized void placeOrder(Contract contract, Order order) {
		// not connected?
		if( !isConnected() ) {
            notConnected();
			return;
		}

		// ApiController requires TWS 932 or higher; this limitation could be removed if needed
		if (serverVersion() < 66) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS, "ApiController requires TWS build 932 or higher to place orders.");
            return;
		}

	    placeOrder(order.orderId(), contract, order);
	}

    /** An output stream that forks all writes to the output logger. */
    private class MyOS extends OutputStream {
    	final OutputStream m_os;

    	MyOS( OutputStream os) {
    		m_os = os;
    	}

    	@Override public void write(byte[] b) throws IOException {
    		m_os.write( b);
    		log( new String( b) );
    	}

    	@Override public synchronized void write(byte[] b, int off, int len) throws IOException {
    		m_os.write(b, off, len);
    		log( new String( b, off, len) );
    	}

    	@Override public synchronized void write(int b) throws IOException {
    		m_os.write(b);
    		log( String.valueOf( (char)b) );
    	}

    	@Override public void flush() throws IOException {
    		m_os.flush();
    	}

    	@Override public void close() throws IOException {
    		m_os.close();
    		m_outLogger.log( "<output stream closed>");
    	}

    	void log( String str) {
    		m_outLogger.log( str.replace( EOL, LOG_EOL) );
    	}
    }

    /** An input stream that forks all reads to the input logger. */
    private class MyIS extends InputStream {
    	InputStream m_is;

    	MyIS( InputStream is) {
    		m_is = is;
    	}

		@Override public int read() throws IOException {
			int c = m_is.read();
			log( String.valueOf( (char)c) );
			return c;
		}

		@Override public int read(byte[] b) throws IOException {
			int n = m_is.read(b);
			log( new String( b, 0, n) );
			return n;
		}

		@Override public int read(byte[] b, int off, int len) throws IOException {
			int n = m_is.read(b, off, len);
			log( new String( b, 0, n) );
			return n;
		}

		@Override public void close() throws IOException {
			super.close();
			log( "<input stream closed>");
		}

    	void log( String str) {
    		m_inLogger.log( str.replace( EOL, LOG_EOL) );
    	}
    }
}
