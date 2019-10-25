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
#define INTERVAL (1U * US_PER_SEC)
static void btn_handler(void *arg)

{

(void)arg;

if(xtimer_usec_from_ticks(xtimer_now())>500000)
gpio_toggle(GPIO_PIN(PORT_B, 0));
printf("slept until %" PRIu32 "\n", xtimer_usec_from_ticks(xtimer_now()));


}

int main(void)
{
    puts("Hello World!");

    printf("You are running RIOT on a(n) %s board.\n", RIOT_BOARD);
    printf("This board features a(n) %s MCU.\n", RIOT_MCU);

    gpio_init_int(GPIO_PIN(PORT_A, 4), GPIO_IN_PU, GPIO_FALLING, btn_handler, NULL);
    gpio_init(GPIO_PIN(PORT_B, 0), GPIO_OUT);
    gpio_clear(GPIO_PIN(PORT_B, 0));

    

    // while(1){
    //     xtimer_usleep(300000);
    //     gpio_toggle(GPIO_PIN(PORT_B, 0));
    // }

    return 0;
}
