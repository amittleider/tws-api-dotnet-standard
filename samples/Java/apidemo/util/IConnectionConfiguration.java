package apidemo.util;


/** Delegate for connection parameters */
public interface IConnectionConfiguration {

	String getDefaultHost();
	String getDefaultPort();
	String getDefaultConnectOptions();

	/** Standard ApiDemo configuration for pre-v100 connection */
	class DefaultConnectionConfiguration implements IConnectionConfiguration {
	    @Override public String getDefaultHost() { return ""; }
	    @Override public String getDefaultPort() { return "7496"; }
	    @Override public String getDefaultConnectOptions() { return null; }
	}
}
