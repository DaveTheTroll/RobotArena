from suds.client import Client
import json
class Robot(object):

    def __init__(self,url,arena):
        self.client = Client(url)
        self.handle = self.client.service.CreateRobot(arena)
        self._colour = (100,100,100)

    def destroy(self):
        self.client.service.DeleteRobot(self.handle)

    @property
    def colour(self):
        return self._colour

    @colour.setter
    def colour(self,C):
        self._colour = C
        self.client.service.SetColor(self.handle,255,C[0],C[1],C[2])
        
    def setSpeed(self,speed,steer):
        self.client.service.SetSpeedDemand(self.handle,speed,steer)

    def getState(self):
        self.state = RobotState(self.client,self.handle)
        return self.state

class RobotState(object):

    def __init__(self,client,handle):
        JSONstr = client.service.GetRobotState(handle)
        JSONdict = json.loads(JSONstr)
        self.handle = JSONdict['Handle']
        self.speed = JSONdict["Speed"]
        self.steer = JSONdict["Steer"]
        self.X = JSONdict["Location"]["Position"]["X"]
        self.Y = JSONdict["Location"]["Position"]["Y"]
        self.heading = JSONdict["Location"]["Heading"]["Degrees"]
        self.arena = JSONdict["ArenaHandle"]
