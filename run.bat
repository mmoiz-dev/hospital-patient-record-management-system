@echo off
echo Building and running Hospital Patient Records System...
cd HospitalPatientRecords
dotnet restore
dotnet build
dotnet run
pause 