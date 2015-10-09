import pygame
import sys
pygame.init()

screen = pygame.display.set_mode((400,600))
clock = pygame.time.Clock()

running = True
rectRed = True
color = (255,0,0)
x = 100
y = 100

while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        if event.type == pygame.KEYDOWN and event.key == pygame.K_SPACE:
            rectRed = not rectRed
        if rectRed:
            color = (255,0,0)
        else:
            color = (0,0,255)
    pressed = pygame.key.get_pressed()
    if pressed[pygame.K_UP]: y-=2
    if pressed[pygame.K_DOWN]: y+=2
    if pressed[pygame.K_LEFT]: x-=2
    if pressed[pygame.K_RIGHT]: x+=2
    pygame.draw.rect(screen, color, pygame.Rect(x,y,100,100), 10)
    pygame.display.flip()
    clock.tick(40)
    screen.fill((0,0,0))

pygame.quit()
