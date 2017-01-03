#!/usr/bin/env python3


"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""


"""
Just a thin wrapper around a socket.
It allows us to keep some other info along with it.
"""


import sys
import socket
import threading

from common import *
from errors import *
import comm
from logger import LOGGER


#TODO: support SSL !!


class Connection:
    def __init__(self, host, port):
        self.host = host
        self.port = port
        self.socket = None
        self.wrapper = None
        self.lock = threading.Lock() 


    def connect(self):
        try:
            self.socket = socket.socket()
        except:
            if self.wrapper:
                self.wrapper.error(NO_VALID_ID, FAIL_CREATE_SOCK.code(), FAIL_CREATE_SOCK.msg())

        try:
            self.socket.connect((self.host, self.port))
        except:
            if self.wrapper:
                self.wrapper.error(NO_VALID_ID, CONNECT_FAIL.code(), CONNECT_FAIL.msg())
 
        self.socket.settimeout(1)   #non-blocking


    def disconnect(self):
        self.lock.acquire()
        try:
            LOGGER.debug("disconnecting")
            self.socket.close()
            self.socket = None
            LOGGER.debug("disconnected")
            if self.wrapper:
                self.wrapper.connectionClosed()
        finally:
            self.lock.release()


    def is_connected(self):
        #TODO: also handle when socket gets interrupted/error
        return self.socket is not None


    def send_msg(self, msg):
        nSent = -1

        LOGGER.debug("acquiring lock")
        self.lock.acquire()
        LOGGER.debug("acquired lock")
        try:
            nSent = self.socket.send(msg)
        except:
            LOGGER.debug("exception from send_msg %s", sys.exc_info())
            raise
        finally:
            LOGGER.debug("releasing lock")
            self.lock.release()
            LOGGER.debug("release lock")
            
        LOGGER.debug("send_msg: sent: %d", nSent)

        return nSent


    def recv_msg(self):
        LOGGER.debug("acquiring lock")
        self.lock.acquire()
        LOGGER.debug("acquired lock")
        try:
            buf = self._recv_all_msg()
        except:
            LOGGER.debug("exception from recv_msg %s", sys.exc_info())
            buf = b""
        else:
            pass
        finally:
            LOGGER.debug("releasing lock")
            self.lock.release()
            LOGGER.debug("release lock")

        return buf            
    
    def _recv_all_msg(self):
        cont = True
        allbuf = b""

        while cont:
            buf = self.socket.recv(4096)
            allbuf += buf
            LOGGER.debug("len %d raw:%s|", len(buf), buf)

            if len(buf) < 4096:
                cont = False

        return allbuf  
             
