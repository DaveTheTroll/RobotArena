from robotArena import Robot

robot = Robot("http://192.168.0.14:49711/ArenaJSON.asmx?WSDL",0)

robotState = robot.getState()
while True:
    robot.setSpeed(1,1)

    while robotState.steer != 1:
        robotState = robot.getState()
    
    robot.setSpeed(1,-1)

    while robotState.steer != -1:
        robotState = robot.getState()
