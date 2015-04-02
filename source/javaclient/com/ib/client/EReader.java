/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.client;

import java.io.DataInputStream;
import java.io.EOFException;
import java.io.IOException;
import java.util.Arrays;
import java.util.Deque;
import java.util.LinkedList;



/**
 * This class reads commands from TWS and passes them to the user defined
 * EWrapper.
 *
 * This class is initialized with a DataInputStream that is connected to the
 * TWS. Messages begin with an ID and any relevant data are passed afterwards.
 */
public class EReader extends Thread {
    private EClientSocket 	m_clientSocket;
    private EReaderSignal m_signal;
    private boolean 		m_useV100Plus;
    private EDecoder m_threadReadDecoder, m_processMsgsDecoder;
    private static final EWrapper defaultWrapper = new DefaultEWrapper();
    private byte[] m_iBuf = new byte[8192];
    private int m_iBufLen = 0;
    private Deque<EMessage> m_msgQueue = new LinkedList<EMessage>();
    
    public void setUseV100Plus() { m_useV100Plus = true; }

    protected EClient parent()    { return m_clientSocket; }
    private EWrapper eWrapper()         { return parent().wrapper(); }

    /**
     * Construct the EReader.
     * @param parent An EClientSocket connected to TWS.
     * @param signal A callback that informs that there are messages in msg queue.
     */
    public EReader(EClientSocket parent, EReaderSignal signal) {
    	m_clientSocket = parent;
        m_signal = signal;
        m_threadReadDecoder = new EDecoder(parent.serverVersion(), defaultWrapper);
        m_processMsgsDecoder = new EDecoder(parent.serverVersion(), parent.wrapper(), parent);
    }
    
    /**
     * Read and put messages to the msg queue until interrupted or TWS closes connection.
     */
    public void run() {
        try {
            // loop until thread is terminated
            while (!isInterrupted()) {
            	if (!putMessageToQueue())
            		break;
            }
        }
        catch ( Exception ex ) {
        	//if (parent().isConnected()) {
        		if( ex instanceof EOFException ) {
            		eWrapper().error(EClientErrors.NO_VALID_ID, EClientErrors.BAD_LENGTH.code(),
            				EClientErrors.BAD_LENGTH.msg() + " " + ex.getMessage());
        		}
        		else {
        			eWrapper().error( ex);
        		}
        	//}
        } 
        
        m_signal.issueSignal();
    }

	public boolean putMessageToQueue() throws IOException {
		EMessage msg = readSingleMessage();
		
		if (msg == null)
			return false;
		
		synchronized(m_msgQueue) {
			m_msgQueue.addFirst(msg);
		}
		
		m_signal.issueSignal();
		
		return true;
	}   

	protected EMessage getMsg() {
    	synchronized (m_msgQueue) {
    		return m_msgQueue.isEmpty() ? null : m_msgQueue.removeLast();
		}
    }
    
    public void processMsgs() throws IOException {
    	EMessage msg = getMsg();
    	
    	while (msg != null && m_processMsgsDecoder.processMsg(msg) > 0) {
    		msg = getMsg();
    	}
    }

	private EMessage readSingleMessage() throws IOException {
		if (m_useV100Plus) {
			int msgSize = m_clientSocket.readInt();
			byte[] buf = new byte[msgSize];
			
			m_clientSocket.read(buf, 0, msgSize);
			
			return new EMessage(buf);
		}
		
		if (m_iBufLen == 0)
			m_iBufLen = m_clientSocket.read(m_iBuf, m_iBufLen, m_iBuf.length - m_iBufLen);
				
		int msgSize = m_iBufLen > 0 ? m_threadReadDecoder.processMsg(new EMessage(m_iBuf)) : 0;
		
		if (msgSize == 0)
			return null;
		
		EMessage msg = new EMessage(Arrays.copyOf(m_iBuf, msgSize));
		
		System.arraycopy(Arrays.copyOfRange(m_iBuf, msgSize, m_iBuf.length), 0, m_iBuf, 0, m_iBuf.length - msgSize);
		
		m_iBufLen -= msgSize;
		
		return msg;
	}   
}
