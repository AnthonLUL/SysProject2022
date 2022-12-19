from socket import *

import requests
import json
import urllib3

urllib3.disable_warnings();

urlwithID = "";

#url = "https://localhost:7230/api/AbsenseApi/{}"
url = "https://absenseapi20221214143540.azurewebsites.net/api/absenseapi/{}"

serverPort = 7000
serverSocket = socket(AF_INET, SOCK_DGRAM)
serverSocket.bind(('', serverPort))
print("The server is ready to receive")
while True:
    message, clientAddress = serverSocket.recvfrom(2048)
    modifiedMessage = message.decode()
    parts = modifiedMessage.split('+')
    studentId = parts[0]
    urlWithID = url.format(studentId)
    print(studentId)
    print("MAC:"+parts[1])
    #studentIdJson = json.loads(studentId)
    #studentIdJson2 = studentId.json()
    print(urlWithID)
    response = requests.put(urlWithID, verify=False)
    statuscode = response.status_code
    if statuscode == 200:
        print("Check in Succesfull")
    else:
        print("check in failed",statuscode)



    #serverSocket.sendto(modifiedMessage.encode(),clientAddress)

