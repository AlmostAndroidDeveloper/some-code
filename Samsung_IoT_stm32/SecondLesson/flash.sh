#!/bin/bash

make
sudo stm32flash -E -w bin/*/*.hex -v /dev/ttyACM0