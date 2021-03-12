@echo off
echo Starting clients...
for /l %%i in (1,1,400) do ^
start "" "E:\KTH\Degree Project\Unordinal\unity_project1\tank_client\builds\tank_rotate_move_shoot\tank_client.exe" ^
-batchmode -nographics

::taskkill /im "tank_client.exe" /f