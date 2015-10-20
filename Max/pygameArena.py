from suds.client import Client
import json
import robotArena
import arenaMonitor
import sys
sys.path.append('../Dave/PyGame')
from PyGameBase import PyGameBase
import pygame

class PyGameArena(PyGameBase):
    def __init__(self,width,height,frameRate,arena):
        pygame.init()
        self.surface = pygame.display.set_mode((width,height))
        self.frameRate = frameRate
        self.arena = arena
    def Update(self,deltaT):
        self.arena.getRobots()
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
    thisPyGame = PyGameArena(400,400,40,thisArena)
    print("thisPyGame done")
    thisPyGame.Start()
