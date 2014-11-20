/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
* and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#pragma once
#ifndef eposixclientsocket_def
#define eposixclientsocket_def

#include "EClient.h"
#include "EClientMsgSink.h"

class EWrapper;
class EReaderSignal;

class TWSAPIDLLEXP EClientSocket : public EClient, public EClientMsgSink
{
protected:
    virtual void prepareBufferImpl(std::ostream&) const;
	virtual void prepareBuffer(std::ostream&) const;
	void closeAndSend(std::string msg, unsigned offset = 0);

public:

	explicit EClientSocket(EWrapper *ptr, EReaderSignal *pSignal = 0);
	~EClientSocket();

	bool eConnect( const char *host, unsigned int port, int clientId = 0, bool extraAuth = false);
	// override virtual funcs from EClient
	void eDisconnect();

	bool isSocketOK() const;
	int fd() const;
    bool asyncEConnect() const;
    void asyncEConnect(bool val);

private:

	bool eConnectImpl(int clientId, bool extraAuth, ConnState* stateOutPt);

private:
	int send( const char* buf, size_t sz);
	void encodeMsgLen(std::string& msg, unsigned offset) const;
	int bufferedSend(const char* buf, size_t sz);
	int bufferedSend(const std::string& msg);
    int sendBufferedData();

    static void CleanupBuffer(BytesVec&, int processed);


public:
	int receive( char* buf, size_t sz);
	bool isOutBufferEmpty() const;

public:
	// callback from socket
	void onSend();
	void onError();

private:

	void onConnect();
	void onClose();

public:
	// helper
	bool handleSocketError();

private:

	int m_fd;
    bool m_allowRedirect;
    const char* m_hostNorm;
    bool m_asyncEConnect;
    EReaderSignal *m_pSignal;
	BytesVec m_outBuffer;

//EClientMsgSink implementation
public:
    void serverVersion(int version, const char *time);
    void redirect(const char *host, int port);    
};

#endif
