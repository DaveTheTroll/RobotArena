from suds.client import Client

client = Client("http://192.168.10.32:49711/ArenaJSON.asmx?WSDL")
speed = input("Speed: ")
steer = input("Steer: ")
colour = str(raw_input("Colour: "))
robotHandle = client.service.CreateRobot(0)
speedDemand = client.service.SetSpeedDemand(robotHandle,speed,steer)
setColour = client.service.SetColor(robotHandle,colour)
print(robotHandle)
