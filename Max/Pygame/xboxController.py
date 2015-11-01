#XBOX info
#LS X = 0 (-1 left to 1 right)
#LS Y = 1 (-1 Up to 1 Down)
#LT RT = 2 (1 LT to -1 RT)
#RS Y = 3
#RS X = 4
#DPad = 0
import pygame
from enum import Enum

class NotXboxControllerError(Exception):
    pass

class Button(Enum):
    A = 0
    B = 1
    X = 2
    Y = 3
    LB = 4
    RB = 5
    Back = 6
    Start = 7
    LS = 8
    RS = 9

class Axis(Enum):
    LS_X = 0   # -1 left 1 right
    LS_Y = 1   # -1 up 1 down
    LT_RT = 2  # -1 RT 1 LT
    RS_Y = 3
    RS_X = 4

class Hat(Enum):
    DPad = 0

class HatHorizontal(Enum):
    Left = -1
    Centre = 0
    Right = 1

class HatVertical(Enum):
    Up = 1
    Centre = 0
    Down = -1

class Controller:
    def __init__(self, joystickIndex):
        self.joystick = pygame.joystick.Joystick(joystickIndex)
        self.joystick.init()
        if self.joystick.get_name() != "Controller (Xbox 360 Wireless Receiver for Windows)":
            raise NotXboxControllerError()

    @property
    def APressed(self): return self.joystick.get_button(Button.A)
    @property
    def BPressed(self): return self.joystick.get_button(Button.B)
    @property
    def XPressed(self): return self.joystick.get_button(Button.X)
    @property
    def YPressed(self): return self.joystick.get_button(Button.Y)
    @property
    def LBPressed(self): return self.joystick.get_button(Button.LB)
    @property
    def RBPressed(self): return self.joystick.get_button(Button.RB)
    @property
    def BackPressed(self): return self.joystick.get_button(Button.Back)
    @property
    def StartPressed(self): return self.joystick.get_button(Button.Start)
    @property
    def LSPressed(self): return self.joystick.get_button(Button.LS)
    @property
    def RSPressed(self): return self.joystick.get_button(Button.RS)    
    
    def getAxis(self,number):
        return self.joystick.get_axis(number)
    def getBall(self,number):
        return self.joystick.get_ball(number)
    def getHat(self,number):
        return self.joystick.get_hat(number)
