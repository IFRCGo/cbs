FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY /NuGet.Config /src
COPY /Source/Sms/. /src/Source/Sms
COPY /Source/Infrastructure/. /src/Source/Infrastructure
WORKDIR /src/Source/Sms/SmsEagle/Web
RUN dotnet publish -c Release -o /app

FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "Web.dll"]


