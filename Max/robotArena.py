from suds.client import Client
import json
class Robot(object):

    def __init__(self,url,arena):
        self.client = Client(url)
        self.handle = self.client.service.CreateRobot(arena)

    def destroy(self):
        self.client.service.DeleteRobot(self.handle)

    @property
    def colour(self):
        return self._colour

    @colour.setter
    def colour(self,r,g,b):
        self._colour = (r,g,b)
        self.client.service.SetColor(self.handle,255,r,g,b)
        
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
