"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""

import unittest

from enum_implem import Enum


EnumTestCase(unittest.TestCase):
    def setUp(self):
        pass


    def tearDown(self):
        pass


    def test_enum():
        e = Enum("ZERO", "ONE", "TWO")
        print(e.ZERO)
        print(e.to_str(e.ZERO))

if "__main__" == __name__:
    unittest.main()
              
