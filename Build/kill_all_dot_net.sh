#!/bin/bash
ps -ef | grep -i dotnet | awk {'print $2'} | xargs kill -9