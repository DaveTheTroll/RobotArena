import pygame

pygame.init()
height = 600
width = 600
white = (255,255,255)
circ1 = (100,200)

screen=pygame.display.set_mode([width,height])
pygame.draw.circle(screen,white,circ1,100,0)
pygame.display.update()
