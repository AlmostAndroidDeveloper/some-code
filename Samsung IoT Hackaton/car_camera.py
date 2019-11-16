from picamera import PiCamera
from time import sleep
import datetime


def take_photo_in():
    camera = PiCamera()
    sleep(1)
    camera.capture('IN_PHOTOS/' + datetime.datetime.now().strftime('%d-%m-%Y %H:%M:%S') + '.jpg')
    camera.close()


def take_photo_out():
    camera = PiCamera()
    sleep(1)
    camera.capture('OUT_PHOTOS/' + datetime.datetime.now().strftime('%d-%m-%Y %H:%M:%S') + '.jpg')
    camera.close()
