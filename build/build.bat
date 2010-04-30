@echo off
set MSBUILD="%WINDIR%/Microsoft.NET/Framework/v4.0.30319/msbuild.exe"
%MSBUILD% /nologo build.proj
PAUSE