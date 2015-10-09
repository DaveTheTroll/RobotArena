import pygame
import sys

class PyGameExample:
    def __init__(self):
        pygame.init()
        self.surface = pygame.display.set_mode((800, 600))

    def Loop(self):
        done = False
        self.T = 0

        clock = pygame.time.Clock()
        
        while not done:
            deltaT = clock.tick(100)
            self.T += deltaT
            
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    done = True
            self.Update(deltaT)
        pygame.quit()

    def Update(self, deltaT):
        self.surface.fill((0,0,0))
        x = (self.T / 10) % 300
        pygame.draw.rect(self.surface, (255, 128, 0), pygame.Rect(200, 100, 2*x, x), 5)
        font = pygame.font.SysFont("Verdana", 25)
        text = font.render(str(self.T / 1000.0)+" : "+str(deltaT), 1, (28, 128, 0))
        self.surface.blit(text, (50, 50))
        pygame.display.flip()

if __name__ == "__main__":
    main = PyGameExample()
    main.Loop();
    print("Bye")
