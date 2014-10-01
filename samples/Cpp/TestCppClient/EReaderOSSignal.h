#pragma once
#include "ereadersignal.h"

class EReaderOSSignal :
	public EReaderSignal
{
	HANDLE m_evMsgs;
public:
	EReaderOSSignal(void);
	~EReaderOSSignal(void);

	virtual void onMsgRecv();

	void waitSignal();
};

