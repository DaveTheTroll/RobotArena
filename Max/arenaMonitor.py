from suds.client import Client
import json
import robotArena
class Arena:
    
    def __init__(self,url,arena):
        self.client = Client(url)
        self.arena = arena
        self.maxAcceleration = 0.1
        self.maxSpeed = 1
        self.minSpeed = -1
        self.maxSteerRate = 0.1
        self.maxSteer = 1

        
    def getRobots(self):
        JSONstr = self.client.service.GetArenaState(self.arena)
        JSONdict = json.loads(JSONstr)
        self.name = JSONdict["Name"]
        self.robots = JSONdict["RobotHandles"]
        
    def getRobotState(self,handle):
        robotState = robotArena.RobotState(self.client,handle)
        return robotState

    def getRobotColor(self,handle):
        color = self.client.service.GetColor(handle)
        colorLoads = json.loads(color)
        r = colorLoads["R"]
        g = colorLoads["G"]
        b = colorLoads["B"]
        return (r,g,b)
    def getArenaParameters(self):
        JSONstr = self.client.service.GetArenaState(self.arena)
        JSONdict = json.loads(JSONstr)
        self.maxAcceleration = JSONdict["RobotParameters"]["MaxAcceleration"]
        self.maxSpeed = JSONdict["RobotParameters"]["MaxSpeed"]
        self.minSpeed = JSONdict["RobotParameters"]["MinSpeed"]
        self.maxSteerRate = JSONdict["RobotParameters"]["MaxSteerRate"]
        self.maxSteer = JSONdict["RobotParameters"]["MaxSteer"]

if __name__ == "__main__":
    url = "http://localhost:49711/Arena.asmx?WSDL"
    arena = int(input("Arena handle? "))
    thisArena = Arena(url,arena)
    thisArena.getRobots()
    for bot in thisArena.robots:
        print(bot)
