#pragma once

#include "EDecoder.h"
#include "EMutex.h"

class EPosixClientSocket;
class EReaderSignal;
class EMessage;

class TWSAPIDLLEXP EReader
{  
    EPosixClientSocket *m_pClientSocket;
    EReaderSignal *m_pEReaderSignal;
    EDecoder m_decoder;
    std::deque<shared_ptr<EMessage>> m_msgQueue;
    EMutex m_csMsgQueue;
    std::vector<char> m_buf;
	EDecoder tmpDecoder;


	void onReceive();
	bool bufferedRead(char *buf, int size);

public:
    EReader(EPosixClientSocket *clientSocket, EReaderSignal *signal);
    ~EReader(void);
protected:
	bool processNonBlockingSelect();
    shared_ptr<EMessage> getMsg(void);
    void readToQueue();
    static DWORD WINAPI readToQueueThread(LPVOID lpParam);
    
    EMessage * readSingleMsg();

public:
    void processMsgs(void);

private:
	void start();
};

