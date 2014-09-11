package apidemo.util;

import com.ib.client.EClientSocket;

/** Configuration for extended authentication versions, i.e. for mobile API */
public interface IVerifyAndAuth {

	public enum ConnectionType {
	    PRE_V100,
	    V100,
	    V100_EXTRA_AUTH
	    ;
	    
	    public boolean useV100() {
	        switch ( this ) {
	            case PRE_V100:
	                return false;
	            case V100:
	            case V100_EXTRA_AUTH:
	                return true;
	        }
	        return true;
	    }
	
	    public boolean useExtraAuth() {
	        switch ( this ) {
	            case PRE_V100:
	            case V100:
	                return false;
	            case V100_EXTRA_AUTH:
	                return true;
	        }
	        return true;
	    }
	}

	public abstract boolean supportsV100();	// should v100 mode be enabled at all in GUI
	public abstract String getDefaultHost();
	public abstract String getDefaultPort();
	public abstract String getDefaultConnectOptions();
	public abstract ConnectionType getConnectionType();
	public abstract boolean startAuthRequest(EClientSocket client);
	public abstract void verifyNAuthMessageAPI(EClientSocket client, String apiData, String challenge);
}
