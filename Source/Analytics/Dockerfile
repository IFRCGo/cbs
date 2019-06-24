FROM microsoft/dotnet:2.2-sdk-bionic AS build-core

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/Analytics/Analytics.sln /CBS/Source/Analytics/Analytics.sln
COPY ./Source/Analytics/Core/Core.csproj /CBS/Source/Analytics/Core/Core.csproj
COPY ./Source/Analytics/Concepts/Concepts.csproj /CBS/Source/Analytics/Concepts/Concepts.csproj
COPY ./Source/Analytics/Domain/Domain.csproj /CBS/Source/Analytics/Domain/Domain.csproj
COPY ./Source/Analytics/Domain.Specs/Domain.Specs.csproj /CBS/Source/Analytics/Domain.Specs/Domain.Specs.csproj
COPY ./Source/Analytics/Policies/Policies.csproj /CBS/Source/Analytics/Policies/Policies.csproj
COPY ./Source/Analytics/Events/Events.csproj /CBS/Source/Analytics/Events/Events.csproj
COPY ./Source/Analytics/Events.Reporting/Events.Reporting.csproj /CBS/Source/Analytics/Events.Reporting/Events.Reporting.csproj
COPY ./Source/Analytics/Read/Read.csproj /CBS/Source/Analytics/Read/Read.csproj

WORKDIR /CBS/Source/Analytics
RUN dotnet restore

# Build production code
COPY ./Source/Analytics /CBS/Source/Analytics
WORKDIR /CBS/Source/Analytics/Core
RUN dotnet publish -c Release -o out

FROM node:11.6-slim AS build-web

# Install dependencies
COPY ./Source/Analytics/Web/package.json /CBS/Source/Analytics/Web/package.json
WORKDIR /CBS/Source/Analytics/Web
RUN yarn install

# Build production code
COPY ./Source/Analytics/Web /CBS/Source/Analytics/Web
WORKDIR /CBS/Source/Analytics/Web
RUN yarn build

# Build runtime image 
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY ./Source/Analytics/bounded-context.json /CBS/bounded-context.json
COPY --from=build-core /CBS/Source/Analytics/Core/out /CBS/Core/
COPY --from=build-core /CBS/Source/Analytics/Core/.dolittle /CBS/Core/.dolittle
COPY --from=build-web /CBS/Source/Analytics/Web/dist /CBS/Core/wwwroot
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]