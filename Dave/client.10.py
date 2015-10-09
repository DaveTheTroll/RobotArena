from suds.client import Client
import time
import json

client = Client("http://192.168.10.32:49711/ArenaJSON.asmx?WSDL")
robot = client.service.CreateRobot(0)
client.service.SetColor(robot,"Red")
client.service.SetSpeedDemand(robot,1, -0.3)

while(True):
    stateJson = client.service.GetRobotState(robot)
    state = json.loads(stateJson)
    print(state['Location']['Position']['X'])
    time.sleep(0.2)
