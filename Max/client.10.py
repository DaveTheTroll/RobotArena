from suds.client import Client

client = Client("http://192.168.10.32:49711/ArenaJSON.asmx?WSDL")
thing = client.service.GetTest()

print(thing)
