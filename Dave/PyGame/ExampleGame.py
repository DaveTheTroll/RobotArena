import pygame
from datetime import datetime
from PyGameBase import PyGameBase

class ExampleGame(PyGameBase):
    def __init__(self):
        PyGameBase.__init__(self, 200, 150, 100)
        self.T = 0
        self.startTime = datetime.now()

    def Render(self, deltaT):
        self.Clear()
        self.T += deltaT
        
        timeSinceStart = datetime.now() - self.startTime
        
#        x = (self.T / 10) % 200
#        pygame.draw.rect(self.surface, (255, 128, 0), pygame.Rect(200, 100, 3*x/2, x), 5)
        font = pygame.font.SysFont("Verdana", 25)
        
        text = font.render(str(self.T / 1000.0)+" : "+str(deltaT), True, (28, 128, 0))
        self.surface.blit(text, (50, 25))
        
        text = font.render(str(timeSinceStart.seconds + timeSinceStart.microseconds / 1000000.0), False, (196, 128, 0))
        self.surface.blit(text, (50, 75))

if __name__=="__main__":
    game = ExampleGame()
    game.Start()
