#from distutils.core import setup
from setuptools import setup
from IBApi import get_version_string

setup(
    name='ibapi',
    version=get_version_string(),
    packages=['IBApi'],
    url='https://interactivebrokers.github.io/tws-api',
    license='IB API Non-Commercial License or the IB API Commercial License',
    author='IBG LLC',
    author_email='dnastase@interactivebrokers.com',
    description='Python IB API'
)
