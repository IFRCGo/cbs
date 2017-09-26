# CBS Example backend application

[![Build status](https://ci.appveyor.com/api/projects/status/aymmq31lpjdsxk6v?svg=true)](https://ci.appveyor.com/project/karolikl/cbs) 

## Prerequisites

.NET Core 2.0 SDK and runtime   
https://www.microsoft.com/net/download/core

Any terminal and git. To get quickly up and running, suggested options are [cmder]([http://cmder.net/]) on Windows and [iTerm2](https://www.iterm2.com/downloads.html) on Mac.

## Local build

(Active path: `cbs\source\example`)

Download nuget dependencies
> `dotnet restore`   

Build
> `dotnet build`

Run locally   
(Active path: `cbs\source\example\web`)

> `dotnet run`

Open browser at address http://localhost:5000