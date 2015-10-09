from suds.client import Client

client = Client("http://192.168.0.14:49711/ArenaJSON.asmx?WSDL")
thing = client.service.GetRobot()

print(thing)
