/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.client;

import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.IOException;

/** This class is used to build messages so the entire message can be
 *  sent to the socket in a single write. */
public class Builder {
	private static final char SEP = 0;
	private static final int PADDING_SIZE = 1; // 1 disables padding, 4 is normal if padding is used
	private static final byte[] EMPTY_LENGTH_HEADER = new byte[ 4 ]; 
	        
	private final ByteBuffer m_sb;
	private boolean m_useSendMax;
	
	public Builder( int size ) {
	    m_sb = new ByteBuffer( size );
	}
	
	/** If a numeric value is set to the maxvalue (appropriate for the data type),
	 *  then when it is serialized using send it is automatically replaced by a null field. */
	public void setUseSendMax() {
	    m_useSendMax = true;
	}
	
	public void send(int a) {
	    if ( m_useSendMax ) {
	        sendMax( a );
	    }
	    else {
	        send( String.valueOf(a) );
	    }
	}

	public void sendMax(int a) {
		send( a == Integer.MAX_VALUE ? "" : String.valueOf( a) );
	}

	public void send(double a) {
	    if ( m_useSendMax ) {
	        sendMax( a );
	    }
	    else {
	        send( String.valueOf( a) );
	    }
	}

	public void sendMax(double a) {
		send( a == Double.MAX_VALUE ? "" : String.valueOf( a) );
	}

	public void send( boolean a) {
		send( a ? 1 : 0);
	}

	public void send( IApiEnum a) {
		send( a == null ? (String)null : a.getApiString() );
	}

	public void send( String a) {
		if (a != null) {
		    byte[] buffer = a.getBytes();
		    m_sb.write( buffer, 0, buffer.length );
		}
		m_sb.write( SEP);
	}

	public void send( byte[] bytes ) {
        if ( bytes != null ) {
            m_sb.write(  bytes, 0, bytes.length );
        }
    }
	
    public int allocateLengthHeader() {
        int lengthHeaderPosition = m_sb.size();
        m_sb.write( EMPTY_LENGTH_HEADER, 0, EMPTY_LENGTH_HEADER.length );
        return lengthHeaderPosition;
    }

    public void updateLength( int lengthHeaderPosition ) {
        m_sb.updateLength( lengthHeaderPosition );
    }

    public void writeTo( DataOutputStream dos ) throws IOException {
       m_sb.writeTo( dos );
    }

    // b[] must be at least b[position+4]
    public static void intToBytes(int val, byte b[], int position) {
        b[position+0] = (byte)(0xff & (val >> 24));
        b[position+1] = (byte)(0xff & (val >> 16));
        b[position+2] = (byte)(0xff & (val >> 8));
        b[position+3] = (byte)(0xff & val);
        return;
    }
    
    /** inner class: ByteBuffer - storage for bytes and direct access to buffer. */
    private static class ByteBuffer extends ByteArrayOutputStream {
        public ByteBuffer( int capacity ) {
            super( capacity );
        }

        public void updateLength( int lengthHeaderPosition ) {
            int len = this.count - EMPTY_LENGTH_HEADER.length - lengthHeaderPosition;
            if ( PADDING_SIZE > 1 ) {
                int padding = PADDING_SIZE - len%PADDING_SIZE;
                if ( padding < PADDING_SIZE ) {
                    this.write( EMPTY_LENGTH_HEADER, 0, PADDING_SIZE ); // extra padding at the end
                    len = this.count - EMPTY_LENGTH_HEADER.length - lengthHeaderPosition;
                }
            }
            intToBytes(len, this.buf, lengthHeaderPosition);
        }
        
        public void writeTo( DataOutputStream out ) throws IOException {
            out.write( this.buf, 0, this.count );
        }
    }
}
