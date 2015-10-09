import pygame
import sys

class PyGameBase:
    def __init__(self, width, height, frameRate):
        pygame.init()
        self.surface = pygame.display.set_mode((width, height))
        self.frameRate = frameRate;

    def Start(self):
        done = False
        clock = pygame.time.Clock()
        
        while not done:
            deltaT = clock.tick(self.frameRate)
            
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    done = True
                else:
                    self.OnEvent(event, deltaT)
                    self.HandleEvent(event, deltaT)
                    
            self.Update(deltaT)
            self.Render(deltaT)
            pygame.display.flip()
        pygame.quit()

    def OnEvent(self, event, deltaT):
        pass

    def HandleEvent(self, event, deltaT):
        if event.type == pygame.KEYDOWN:
            self.OnKeyDown(event.key, deltaT)

    def OnKeyDown(self, key, deltaT):
        pass

    def Update(self, deltaT):
        pass

    def Render(self, deltaT):
        pass

    def Clear(self):
        self.surface.fill((0,0,0))
