import pygame
pygame.init()
joysticks = []
clock = pygame.time.Clock()
playing = True
for i in range(0, pygame.joystick.get_count()):
    joysticks.append(pygame.joystick.Joystick(i))
    joysticks[-1].init()
print("Controllers: ",joysticks[-1].get_name())
while playing:
    clock.tick(40)
    for event in pygame.event.get():
        if event.type == pygame.JOYAXISMOTION:
            print("Joystick ",joysticks[event.joy].get_name()," axis",event.axis,"motion.")
        elif event.type == pygame.JOYBUTTONDOWN:
            print "Joystick '",joysticks[event.joy].get_name(),"' button",event.button,"down."
        elif event.type == pygame.JOYBUTTONUP:
            print "Joystick '",joysticks[event.joy].get_name(),"' button",event.button,"up."
