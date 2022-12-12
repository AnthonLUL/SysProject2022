import os
os.system('sudo chown pi -R /dev/input')
#import getmac # sudo pip install get-mac

import re,uuid
import evdev
from evdev import categorize, ecodes
from socket import *
BROADCAST_TO_PORT = 7000

PiMac = ':'.join(re.findall('..','%012x' % uuid.getnode()))
#PiMac = getmac.get_mac_address()

sock = socket(AF_INET, SOCK_DGRAM)
# sock.bind('', 14593)) # (ip,port)
# no explicit bind will bind to default ip+ random port
sock.setsockopt(SOL_SOCKET, SO_BROADCAST, 60000)
#serverName = 'localhost' # her er IP eller DNS look up
#serverName = '255.255.255.255'
#serverPort = 7001


class Device():
    name = 'Sycreader RFID Technology Co., Ltd SYC ID&IC USB Reader'

    @classmethod
    def list(cls, show_all=False):
        # list the available devices
        devices = [evdev.InputDevice(fn) for fn in evdev.list_devices()]
        if show_all:
            for device in devices:
                print("event: " + device.fn, "name: " + device.name, "hardware: " + device.phys)
        return devices

    @classmethod
    def connect(cls):
        # connect to device if available
        try:
            device = [dev for dev in cls.list() if cls.name in dev.name][0]
            device = evdev.InputDevice(device.fn)
            return device
        except IndexError:
            print("Device not found.\n - Check if it is properly connected. \n - Check permission of /dev/input/ (see README.md)")
            exit()

    @classmethod
    def run(cls):
        device = cls.connect()
        container = []
        try:
            device.grab()
            # bind the device to the script
            print("RFID scanner is ready....")
            print("Press Control + c to quit.")
            for event in device.read_loop():
                    # enter into an endeless read-loop
                    if event.type == ecodes.EV_KEY and event.value == 1:
                        digit = evdev.ecodes.KEY[event.code]
                        if digit == 'KEY_ENTER':
                            # create and dump the tag
                            tag = "".join(i.strip('KEY_') for i in container)
                            tagAndMac = tag+"+"+PiMac
                            #tag = "+".join(PiMac)
                            print(tag)
                            print(tagAndMac)
                            sock.sendto(bytes(tagAndMac, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
                            #sock.sendto(tag.encode(), (serverName, serverPort))

                            container = []
                        else:
                            container.append(digit)

        except:
            # catch all exceptions to be able release the device
            device.ungrab()
            print('Quitting.')

Device.run()