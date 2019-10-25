#!/bin/bash

make
objcopy -O ihex bin/stm32f0discovery/hello-world.elf bin/stm32f0discovery/hello-world.hex
sudo ~/stlink/st-flash --format ihex write bin/stm32f0discovery/hello-world.hex
