/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#ifdef _WIN32
# include <Windows.h>
# define sleep( seconds) Sleep( seconds * 1000);
#else
# include <unistd.h>
#endif

#include "ConnectionVerifyTest.h"
#include <iostream>
#include <openssl/ssl.h>

const unsigned MAX_ATTEMPTS = 50;
const unsigned SLEEP_TIME = 10;

int main(int argc, char** argv)
{

	// initializing OpenSSL
	SSL_load_error_strings();
	SSL_library_init();

	const char* fileName = argc > 1 ? argv[1] : "private_key.pem";
	const char* host = argc > 2 ? argv[2] : "";
	unsigned int port = argc > 3 ? atoi(argv[3]) : 7496;
	int clientId = 0;

	const char* apiName = argc > 4 ? argv[4] : "TWSDemo";
	const char* apiVersion = argc > 5 ? argv[5] : "1.0";

	unsigned attempt = 0;
	printf( "Start of Connection Verify Test %u\n", attempt);

	ConnectionVerifyTest client (apiName, apiVersion);

	if (!client.initPrivateKey(fileName)){
		return 1;
	}

	for (;;) {
		++attempt;
		printf( "Attempt %u of %u\n", attempt, MAX_ATTEMPTS);


		client.connect( host, port, clientId);

		while( client.isConnected()) {
			client.processMessages();
		}

		if( attempt >= MAX_ATTEMPTS) {
			break;
		}

		printf( "Sleeping %u seconds before next attempt\n", SLEEP_TIME);
		sleep( SLEEP_TIME);

	}

	printf ( "End of Connection Verify Test\n");
	return 0;
}

