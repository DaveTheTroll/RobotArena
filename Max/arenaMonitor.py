from suds.client import Client
import json
import robotArena
class Arena:
    
    def __init__(self,url,arena):
        self.client = Client(url)
        self.arena = arena
        
    def getRobots(self):
        JSONstr = self.client.service.GetArenaState(self.arena)
        JSONdict = json.loads(JSONstr)
        self.name = JSONdict["Name"]
        self.robots = JSONdict["RobotHandles"]
        
    def getRobotState(self,handle):
        robotState = robotArena.RobotState(self.client,handle)
        return robotState
if __name__ == "__main__":
    url = "http://localhost:49711/Arena.asmx?WSDL"
    arena = int(input("Arena handle? "))
    thisArena = Arena(url,arena)
    thisArena.getRobots()
    for bot in thisArena.robots:
        print(bot)
