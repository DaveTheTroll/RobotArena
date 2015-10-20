import json
import robotArena
import sys
sys.path.append('../Dave/Pygame')
sys.path.append('../Max/Pygame')
from joystickClass import Controller
from PyGameBase import PyGameBase
import arenaMonitor
import pygame
#import pygameArena

class JoystickArena(PyGameBase):
    def __init__(self,width,height,frameRate,arena,handle):
        self.surface = pygame.display.set_mode((width,height))
        self.frameRate = frameRate
        self.arena = arena
        self.controller = Controller()
        self.speedDemand = 0
        self.steerDemand = 0
        self.myRobot = robotArena.Robot("http://localhost:49711/Arena.asmx?WSDL",handle)
    def Update(self,deltaT):
        self.speedDemand = self.controller.getAxis(2)*-1
        self.steerDemand = self.controller.getAxis(0)*-1
        self.arena.getRobots()
        self.myRobot.setSpeed(self.speedDemand,self.steerDemand)
    def Render(self,deltaT):
        self.Clear()
        for robot in self.arena.robots:
            X = self.arena.getRobotState(robot).X*10+100
            Y = 200-self.arena.getRobotState(robot).Y*10
            pygame.draw.ellipse(self.surface,(255,255,255),(X,Y,20,20))
if __name__ == "__main__":
    url = "http://localhost:49711/Arena.asmx?WSDL"
    arena = int(input("Arena handle? "))
    thisArena = arenaMonitor.Arena(url,arena)
    print("thisArena done")
    thisPyGame = JoystickArena(400,400,40,thisArena,arena)
    print("thisPyGame done")
    thisPyGame.Start()
    thisPyGame.myRobot.destroy()
