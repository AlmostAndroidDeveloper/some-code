import Adafruit_ADS1x15
import time
from car_camera import *

adc = Adafruit_ADS1x15.ADS1115()
timer = 2


class car_checking:
    def __init__(self):
        self.car_count = 0

    # sonic0 = adc.read_adc(0)

    def getSensorState(self, number):
        sonic = adc.read_adc(number)
        tries = 8
        failures = 0
        rng = 3000
        for i in range(tries):
            if not adc.read_adc(number) in range(sonic - rng, sonic + rng):
                failures += 1
            if failures > tries / 2:
                return self.getSensorState(number)
        return sonic < 28000

    def isCarEnter(self):
        last_time = time.time()
        if self.getSensorState(0) and not self.getSensorState(1):
            last_time = time.time()
            while time.time() - last_time < timer:
                if self.getSensorState(0) and self.getSensorState(1):
                    last_time = time.time()
                    while time.time() - last_time < timer:
                        if not self.getSensorState(0) and self.getSensorState(1):
                            return True
        return False

    def isCarExit(self):
        last_time = time.time()
        if self.getSensorState(1) and not self.getSensorState(0):
            last_time = time.time()
            while time.time() - last_time < timer:
                if self.getSensorState(0) and self.getSensorState(1):
                    last_time = time.time()
                    while time.time() - last_time < timer:
                        if not self.getSensorState(1) and self.getSensorState(0):
                            return True
        return False

    def check_car(self):
        global car_count
        if self.isCarEnter():
            self.car_count += 1
            take_photo_in()
        elif self.isCarExit():
            self.car_count -= 1
            take_photo_out()
        time.sleep(0.5)
