from car_camera import *
from car_checking import *

obj = car_checking()
while 1:
    obj.check_car()
    print(obj.car_count, end='')
    time.sleep(0.1)
    print('---')
