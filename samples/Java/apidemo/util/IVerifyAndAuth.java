package apidemo.util;

import com.ib.client.EClientSocket;

/** Configuration for extended authentication versions, i.e. for mobile API */
public interface IVerifyAndAuth {

	public String getDefaultHost();
	public String getDefaultPort();
	public String getDefaultConnectOptions();
	/** return true if extra auth is required */
	public boolean preConnect( EClientSocket client, String connectionOpts ); 
	public void postConnect(EClientSocket client);
	public void verifyNAuthMessageAPI(EClientSocket client, String apiData, String challenge);

	/** Provides compatibility with pre-v100 messaging */
	public static class DefaultVerifyAndAuthConfig implements IVerifyAndAuth {
	    @Override public String getDefaultHost() { return ""; }
	    @Override public String getDefaultPort() { return "7496"; }
	    @Override public String getDefaultConnectOptions() { return null; }

	    @Override public boolean preConnect( EClientSocket client, String connectionOpts ) {
	        // NOOP
	        return false;
	    }
	    
	    @Override public void postConnect(EClientSocket client) {
	        // NOOP
	    }

	    @Override public void verifyNAuthMessageAPI(EClientSocket client, String apiData, String challenge) {
	        // NOOP
	    }
	}

}
