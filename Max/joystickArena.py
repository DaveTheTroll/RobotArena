import json
import robotArena
import sys
sys.path.append('../Dave/Pygame')
sys.path.append('../Max/Pygame')
from joystickClass import Controller
from PyGameBase import PyGameBase
import arenaMonitor
import pygame
from suds import WebFault
#import pygameArena

class JoystickArena(PyGameBase):
    def __init__(self,width,height,url,frameRate,arena,handle,track,trails):
        self.surface = pygame.display.set_mode((width,height))
        self.width = width
        self.height = height
        self.frameRate = frameRate
        self.arena = arena
        self.track = track
        self.trail = trails
        self.controller = Controller()
        self.speedDemand = 0
        self.steerDemand = 0
        self.r = 250
        self.g = 250
        self.b = 250
        self.myRobot = robotArena.Robot(url,handle)
        self.X = self.myRobot.getState().X
        self.Y = self.myRobot.getState().Y
        self.prevX = self.X
        self.prevY = self.Y
        self.prevsX = [self.X*10+100]
        self.prevsY = [200-self.Y*10]
    def Update(self,deltaT):
        self.speedDemand = self.controller.getAxis(2)*-1*self.arena.maxSpeed
        self.steerDemand = self.controller.getAxis(0)*-1*self.arena.maxSteer
        if self.controller.getButton(0):
            self.g += 5
            if self.g >= 255:
                self.g = 0
        if self.controller.getButton(1):
            self.r += 5
            if self.r >= 255:
                self.r = 0
        if self.controller.getButton(2):
            self.b += 5
            if self.b >= 255:
                self.b = 0
        self.arena.getRobots()
        self.arena.getArenaParameters()
        self.myRobot.colour = (self.r,self.g,self.b)
        self.myRobot.setSpeed(self.speedDemand,self.steerDemand)
        self.prevX = self.X
        self.prevY = self.Y
        self.prevsX.append(self.prevX*10+100)
        self.prevsY.append(200-self.prevY*10)
        self.X = self.myRobot.getState().X
        self.Y = self.myRobot.getState().Y
        if len(self.prevsX) >= 100:
            self.prevsX.pop(0)
            self.prevsY.pop(0)
    def Render(self,deltaT):
        self.Clear()
        if self.track == 1:
            for robot in self.arena.robots:
                try:
                    X = self.arena.getRobotState(robot).X*10+(self.width/2)-self.myRobot.getState().X*10
                    Y = (self.height/2)-(self.arena.getRobotState(robot).Y*10-self.myRobot.getState().Y*10)
                    color = self.arena.getRobotColor(robot)
                    pygame.draw.ellipse(self.surface,color,(X,Y,20,20))
                except WebFault:
                    pass
        else:
            for robot in self.arena.robots:
                try:
                    X = self.arena.getRobotState(robot).X*10+100
                    Y = 200-self.arena.getRobotState(robot).Y*10
                    color = self.arena.getRobotColor(robot)
                    pygame.draw.ellipse(self.surface,color,(X,Y,20,20))
                except WebFault:
                    pass
        if self.trail:
            if self.track:
                for pos in range(len(self.prevsX)):
                    if pos != 0:
                        pygame.draw.line(self.surface,(self.r,self.g,self.b),(self.prevsX[pos]-1+(self.width/2)-self.myRobot.getState().X*10-100,(self.height/2)-self.prevsY[pos-1]*10-self.myRobot.getState().Y*10),(self.prevsX[pos]+(self.width/2)-self.myRobot.getState().X*10-100,(self.height/2)-self.prevsY[pos]*10-self.myRobot.getState().Y*10))
            else:
                for pos in range(len(self.prevsX)):
                    if pos != 0:
                        pygame.draw.line(self.surface,(self.r,self.g,self.b),(self.prevsX[pos-1],self.prevsY[pos-1]),(self.prevsX[pos],self.prevsY[pos]))
if __name__ == "__main__":
    url = "http://192.168.0.14:49711/Arena.asmx?WSDL"
    height = input("Screen height? ")
    width = input("Screen width? ")
    arena = int(input("Arena handle? "))
    follow = input("Track the player? 0 for no, 1 for yes")
    trail = input("Draw trails?")
    thisArena = arenaMonitor.Arena(url,arena)
    print("thisArena done")
    thisPyGame = JoystickArena(width,height,url,40,thisArena,arena,follow,trail)
    print("thisPyGame done")
    thisPyGame.Start()
    thisPyGame.myRobot.destroy()
