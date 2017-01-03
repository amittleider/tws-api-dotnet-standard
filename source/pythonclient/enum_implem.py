#!/usr/bin/env python3


"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""


""" 
    Simple enum implementation
"""


class Enum:
    def __init__(self, *args):
        self.idx2name = {}
        for (idx, name) in enumerate(args):
            setattr(self, name, idx)
            self.idx2name[idx] = name

    def to_str(self, idx):
        return self.idx2name.get(idx, "NOTFOUND")


def test_enum():
    e = Enum("ZERO", "ONE", "TWO")
    print(e.ZERO)
    print(e.to_str(e.ZERO))


if __name__ == "__main__":
    #test_setattr_log()
    #test_poly()
    test_enum()
   
