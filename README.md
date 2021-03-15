# tank_server
Contains a server executable under "tank_server/builds".

# tank_client
Contains executables with differnet behavior pattern under "tank_client/builds".

# Batch operation
The file "open_multiple.bat" is to use batch operation to open multiple executables. The path following the "start" syntax should be modified accordingly. One can use command 
```
taskkill /im "tank_client.exe" /f 
```
to terminate multiple executables with the same filename in Windows command lind. 
