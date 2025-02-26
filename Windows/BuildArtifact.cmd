@echo off
pushd "%~dp0"
powershell Compress-7Zip "bin\Release" -ArchiveFileName "GreatCircleSaveManager.zip" -Format Zip
:exit
popd
@echo on