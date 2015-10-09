from suds.client import Client

client = Client("http://localhost:49711/ArenaJSON.asmx?WSDL")
thing = client.service.GetTest()

print(thing)
