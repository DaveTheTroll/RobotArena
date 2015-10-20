#XBOX info
#A = 0
#B = 1
#X = 2
#Y = 3
#LB = 4
#RB = 5
#Back = 6
#Start = 7
#LS = 8
#RS = 9
#LS X = 0 (-1 left to 1 right)
#LS Y = 1 (-1 Up to 1 Down)
#LT RT = 2 (1 LT to -1 RT)
#RS Y = 3
#RS X = 4
#DPad = 0
import pygame
pygame.init()
clock = pygame.time.Clock()
class Controller:
    def __init__(self):
        self.my_joystick = pygame.joystick.Joystick(0)
        self.my_joystick.init()
        if self.my_joystick.get_name() == "Controller (Xbox 360 Wireless Receiver for Windows)":
            self.joystickType = "Xbox 360 Controller"
        else:
            self.joystickType = "Other"
        self.numaxes = self.my_joystick.get_numaxes()
        self.numballs = self.my_joystick.get_numballs()
        self.numbuttons = self.my_joystick.get_numbuttons()
        self.numhats = self.my_joystick.get_numhats()
    def getAxis(self,number):
        return self.my_joystick.get_axis(number)
    def getBall(self,number):
        return self.my_joystick.get_ball(number)
    def getButton(self,number):
        return self.my_joystick.get_button(number)
    def getHat(self,number):
        return self.my_joystick.get_hat(number)
