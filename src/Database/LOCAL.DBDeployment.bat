@echo off

SET DIR=%~dp0

SET database.name="Wine"
SET sql.files.directory=%DIR%\Wine
SET server.database="LEON\THESQLS"
SET repository.path="https://github.com/chucknorris/roundhouse.git"
SET version.file="_BuildInfo.xml"
SET version.xpath="//buildInfo/version"
SET environment="LOCAL"

echo %DIR%
echo %sql.files.directory%

"%DIR%rh.exe" /d=%database.name% /f=%sql.files.directory% /s=%server.database% /vf=%version.file% /vx=%version.xpath% /r=%repository.path% /env=%environment% /simple

pause