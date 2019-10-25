/*
 * Copyright (C) 2014 Freie Universität Berlin
 *
 * This file is subject to the terms and conditions of the GNU Lesser
 * General Public License v2.1. See the file LICENSE in the top level
 * directory for more details.
 */

/**
 * @ingroup     examples
 * @{
 *
 * @file
 * @brief       Hello World application
 *
 * @author      Kaspar Schleiser <kaspar@schleiser.de>
 * @author      Ludwig Knüpfer <ludwig.knuepfer@fu-berlin.de>
 *
 * @}
 */

#include <stdio.h>
#include "periph/gpio.h"
#include "xtimer.h"
#include "timex.h"
#include "thread.h"

char stack[THREAD_STACKSIZE_MAIN];
char stack2[THREAD_STACKSIZE_MAIN];

void *thread_handler(void *arg)
{
	(void) arg;

	while(1) 
	{
		xtimer_usleep(300000);
    	gpio_toggle(GPIO_PIN(PORT_C, 8));
	}

	return NULL;
}

int main(void)
{
    gpio_init(GPIO_PIN(PORT_C, 8), GPIO_OUT);
    gpio_clear(GPIO_PIN(PORT_C, 8));
    gpio_init(GPIO_PIN(PORT_C, 9), GPIO_OUT);
    gpio_clear(GPIO_PIN(PORT_C, 9));

    thread_create(stack, sizeof(stack),
	THREAD_PRIORITY_MAIN - 1,
	THREAD_CREATE_STACKTEST,
	thread_handler, NULL
	, "thread");
	
    return 0;
}
