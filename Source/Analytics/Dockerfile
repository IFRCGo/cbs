FROM microsoft/dotnet:2.2-sdk-bionic AS build-core

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/Analytics/Analytics.sln /CBS/Source/Analytics/Analytics.sln
COPY ./Source/Analytics/Events/Events.csproj /CBS/Source/Analytics/Events/Events.csproj
COPY ./Source/Analytics/Events.Admin/Events.Admin.csproj /CBS/Source/Analytics/Events.Admin/Events.Admin.csproj
COPY ./Source/Analytics/Events.Reporting/Events.Reporting.csproj /CBS/Source/Analytics/Events.Reporting/Events.Reporting.csproj
COPY ./Source/Analytics/Read/Read.csproj /CBS/Source/Analytics/Read/Read.csproj
COPY ./Source/Analytics/Read.Dolittle/Read.Dolittle.csproj /CBS/Source/Analytics/Read.Dolittle/Read.Dolittle.csproj
COPY ./Source/Analytics/Web/Web.csproj /CBS/Source/Analytics/Web/Web.csproj

WORKDIR /CBS/Source/Analytics
RUN dotnet restore

# Build production code
COPY ./Source/Analytics /CBS/Source/Analytics
WORKDIR /CBS/Source/Analytics/Web
RUN dotnet publish --no-restore -c Release -o out

FROM node:11.6-slim AS build-web
ARG mode=build-test

# Install dependencies
COPY ./Source/Analytics/Web.Frontend/package.json /CBS/Source/Analytics/Web.Frontend/package.json
WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN yarn install

# Build production code
COPY ./Source/Analytics/Web.Frontend /CBS/Source/Analytics/Web.Frontend
WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN yarn build

# Build runtime image 
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build-core /CBS/Source/Analytics/Web/out /CBS/Web/
COPY --from=build-web /CBS/Source/Analytics/Web/dist /CBS/Web/wwwroot
WORKDIR /CBS/Web
ENTRYPOINT ["dotnet", "/CBS/Web/Web.dll"]