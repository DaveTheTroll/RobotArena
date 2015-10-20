import pygame
import sys
sys.path.append('../../Dave/PyGame')
from PyGameBase import PyGameBase
from joystickClass import Controller

class RectGame(PyGameBase):
    def __init__(self):
        PyGameBase.__init__(self,400,600,40)
        self.rectR = 0
        self.rectG = 0
        self.rectB = 0
        self.x = 100
        self.y = 100
        self.controller = Controller()
        self.width = 10
    def Update(self,deltaT):
        addX = self.controller.getAxis(0)
        addY = self.controller.getAxis(1)
        self.x += addX*2
        self.y += addY*2
        if self.controller.getButton(0) == True:
            self.rectG += 5
            if self.rectG >= 255:
                self.rectG -= 255
        if self.controller.getButton(1) == True:
            self.rectR += 5
            if self.rectR >= 255:
                self.rectR -= 255
        if self.controller.getButton(2) == True:
            self.rectB += 5
            if self.rectB >= 255:
                self.rectB -= 255
        dPad = self.controller.getHat(0)
        if dPad == (1,0):
            self.width = 10
        elif dPad == (0,-1):
            self.width = 0
        elif dPad == (-1,0):
            self.width = 5
        elif dPad == (0,1):
            self.width = (20)
    def Render(self,deltaT):
        self.Clear()
        pygame.draw.rect(self.surface, (self.rectR, self.rectG, self.rectB) , pygame.Rect(self.x,self.y,100,100), self.width)
game = RectGame()
game.Start()
