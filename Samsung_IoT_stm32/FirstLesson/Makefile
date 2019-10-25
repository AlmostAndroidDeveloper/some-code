# name of your application
APPLICATION = hello-world

# If no BOARD is found in the environment, use this default:
BOARD = stm32f0discovery

# This has to be the absolute path to the RIOT base directory:
RIOTBASE ?= $(CURDIR)/../..

# Comment this out to disable code in RIOT that does safety checking
# which is not needed in a production environment but helps in the
# development process:
USEMODULE += xtimer

DEVELHELP ?= 1

# Change this to 0 show compiler invocation lines by default:
QUIET ?= 1

FEATURES_REQUIRED += periph_gpio
FEATURES_REQUIRED += periph_timer

include $(RIOTBASE)/Makefile.include
