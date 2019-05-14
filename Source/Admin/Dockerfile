FROM microsoft/dotnet:2.2-sdk-bionic AS build-core

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/Admin/Admin.sln /CBS/Source/Admin/Admin.sln
COPY ./Source/Admin/Concepts/Concepts.csproj /CBS/Source/Admin/Concepts/Concepts.csproj
COPY ./Source/Admin/Core/Core.csproj /CBS/Source/Admin/Core/Core.csproj
COPY ./Source/Admin/Domain/Domain.csproj /CBS/Source/Admin/Domain/Domain.csproj
COPY ./Source/Admin/Events/Events.csproj /CBS/Source/Admin/Events/Events.csproj
COPY ./Source/Admin/Read/Read.csproj /CBS/Source/Admin/Read/Read.csproj
COPY ./Source/Admin/Rules/Rules.csproj /CBS/Source/Admin/Rules/Rules.csproj

WORKDIR /CBS/Source/Admin
RUN dotnet restore

# Build production code
COPY ./Source/Admin /CBS/Source/Admin
WORKDIR /CBS/Source/Admin/Core
RUN dotnet publish --no-restore -c Release -o out

FROM node:11.6-slim AS build-web
ARG mode=build-test

# Install dependencies
COPY ./Source/Navigation /CBS/Source/Navigation
COPY ./Source/Admin/Web/package.json /CBS/Source/Admin/Web/package.json
WORKDIR /CBS/Source/Admin/Web
RUN yarn install

# Build production code
COPY ./Source/Admin/Web /CBS/Source/Admin/Web
WORKDIR /CBS/Source/Admin/Web
RUN npm run ${mode}

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build-web /CBS/Source/Admin/Web/dist /CBS/Core/wwwroot
COPY ./Source/Admin/bounded-context.json /CBS/bounded-context.json
COPY --from=build-core /CBS/Source/Admin/Core/out /CBS/Core/
COPY --from=build-core /CBS/Source/Admin/Core/.dolittle /CBS/Core/.dolittle
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]
