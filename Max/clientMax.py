from suds.client import Client
import json
client = Client("http://192.168.0.14:49711/Arena.asmx?WSDL")
def createRobot(speed,steer,colour):
    robotHandle = client.service.CreateRobot(0)
    speedDemand = client.service.SetSpeedDemand(robotHandle,speed,steer)
    setColour = client.service.SetColor(robotHandle,colour)
    print("You have create robot number ",robotHandle)
#speed = input("Speed: ")
#steer = input("Steer: ")
#colour = str(raw_input("Colour: "))
#robotHandle = client.service.CreateRobot(0)
#speedDemand = client.service.SetSpeedDemand(robotHandle,speed,steer)
#setColour = client.service.SetColor(robotHandle,colour)
#print(robotHandle)
def editRobot(handle,speed,steer,colour):
    speedDemand = client.service.SetSpeedDemand(handle,speed,steer)
    setColour = client.service.SetColor(handle,colour)
    print("Robot ",handle," edited")
def getInfo(handle):
    jsonState = client.service.GetRobotState(handle)
    state = json.loads(jsonState)
    statePrint = "Handle: "+str(state["Handle"])+" X: "+str(state["Location"]["Position"]["X"])+" Y: "+str(state["Location"]["Position"]["Y"])+" Heading: "+str(state["Location"]["Heading"]["Degrees"])
    print(statePrint)
def deleteRobot(handle):
    delete = client.service.DeleteRobot(handle)
    print("Robot ",handle," deleted")
print("createRobot(speed,steer,colour)\neditRobot(handle,speed,steer,colour)\ngetInfo(handle)\ndeleteRobot(handle)")
