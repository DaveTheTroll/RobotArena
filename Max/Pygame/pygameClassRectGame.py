import pygame
import sys
sys.path.append('../../Dave/PyGame')
from PyGameBase import PyGameBase

class SquareMoveGame(PyGameBase):
    def __init__(self):
        PyGameBase.__init__(self,400,600,40)
        self.rectRed = True
        self.color = (255,0,0)
        self.x = 100
        self.y = 100
    def OnKeyDown(self,key,deltaT):
        if key == pygame.K_SPACE:
            self.rectRed = not self.rectRed
        if self.rectRed:
            self.color = (255,0,0)
        else:
            self.color = (0,0,255)
    def Update(self,deltaT):
        pressed = pygame.key.get_pressed()
        if pressed[pygame.K_UP]: self.y-=2
        if pressed[pygame.K_DOWN]: self.y+=2
        if pressed[pygame.K_LEFT]: self.x-=2
        if pressed[pygame.K_RIGHT]: self.x+=2
    def Render(self,deltaT):
        self.Clear()
        pygame.draw.rect(self.surface, self.color, pygame.Rect(self.x,self.y,100,100), 10)

game = SquareMoveGame()
game.Start()
