package apidemo.util;

import com.ib.client.EClientSocket;

/** Provides compatibility with pre-v100 messaging */
public class DefaultVerifyAndAuthConfig implements IVerifyAndAuth {

	@Override public boolean supportsV100() { return false;	}
	@Override public String getDefaultHost() { return ""; }
	@Override public String getDefaultPort() { return "7496"; }
	@Override public String getDefaultConnectOptions() { return null; }
	@Override public ConnectionType getConnectionType() { return ConnectionType.PRE_V100; }

	@Override public boolean startAuthRequest(EClientSocket client) {
		return false;
	}

	@Override public void verifyNAuthMessageAPI(EClientSocket client, String apiData, String challenge) {
		// NOOP
	}
}
