from suds.client import Client

client = Client("http://192.168.10.32:49711/ArenaJSON.asmx?WSDL")
robotHandle = client.service.CreateRobot(0)
print(robotHandle)
