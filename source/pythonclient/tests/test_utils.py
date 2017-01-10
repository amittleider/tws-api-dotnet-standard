"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""

import unittest

from IBApi.enum_implem import Enum
from IBApi.utils import setattr_log


class UtilsTestCase(unittest.TestCase):
    def setUp(self):
        pass


    def tearDown(self):
        pass


    def test_enum(self):
        e = Enum("ZERO", "ONE", "TWO")
        print(e.ZERO)
        print(e.to_str(e.ZERO))


    def test_setattr_log(self):
        class A:
            def __init__(self):
                self.n = 5

        A.__setattr__ = setattr_log
        a = A()
        print(a.n)
        a.n = 6
        print(a.n)


    def test_polymorphism(self):
        class A:
            def __init__(self):
                self.n = 5
            def m(self):
                self.n += 1
        class B(A):
            def m(self):
                self.n += 2

        o = B()
        #import code; code.interact(local=locals())

 
if "__main__" == __name__:
    unittest.main()
              
