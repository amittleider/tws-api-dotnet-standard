#!/usr/bin/env python3


"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""


"""
The Reader runs in a separate threads and is responsible for receiving the
incoming messages.
It will read the packets from the wire, use the low level IB messaging to 
remove the size prefix and put the rest in a Queue.
"""


from threading import Thread
import comm
from logger import LOGGER


class Reader(Thread):
    def __init__(self, conn, msg_queue):
        super().__init__()
        self.conn = conn
        self.msg_queue = msg_queue
        self.prevBuf = b""


    def run(self):
        while self.conn.is_connected():
        
            buf = self.prevBuf + self.conn.recv_msg()
            LOGGER.debug("reader loop, prevBuf.size: %d recvd size: %d buf %s",
                len(self.prevBuf), len(buf), buf)
           
            while len(buf) > 0:
                (size, msg, buf) = comm.read_msg(buf)
                #LOGGER.debug("resp %s", buf.decode('ascii'))
                LOGGER.debug("size:%d msg.size:%d msg:|%s| buf:%s|", size,
                    len(msg), buf, "|")

                if len(msg) == size:
                    self.msg_queue.put(msg)
                    self.prevBuf = b""
                elif len(msg) < size:
                    LOGGER.debug("more incoming packet(s) are needed ")
                    self.prevBuf = buf
                else:
                    LOGGER.error("recvd bigger msg (%d) than expected (%d)", 
                        len(msg), size)

        LOGGER.debug("Reader thread finished")

