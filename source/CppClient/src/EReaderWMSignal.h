#pragma once
#include "ereadersignal.h"

class EReaderWMSignal :
	public EReaderSignal
{
	HWND m_hWnd;
	int m_msg;

public:
	EReaderWMSignal(HWND hWnd, int msg);

	virtual void onMsgRecv();
};

