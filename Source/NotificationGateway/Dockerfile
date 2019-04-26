FROM microsoft/dotnet:2.2-sdk-bionic AS build-core

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/NotificationGateway/NotificationGateway.sln /CBS/Source/NotificationGateway/NotificationGateway.sln
COPY ./Source/NotificationGateway/Concepts/Concepts.csproj /CBS/Source/NotificationGateway/Concepts/Concepts.csproj
COPY ./Source/NotificationGateway/Core/Core.csproj /CBS/Source/NotificationGateway/Core/Core.csproj
COPY ./Source/NotificationGateway/Domain/Domain.csproj /CBS/Source/NotificationGateway/Domain/Domain.csproj
COPY ./Source/NotificationGateway/Domain.Specs/Domain.Specs.csproj /CBS/Source/NotificationGateway/Domain.Specs/Domain.Specs.csproj
COPY ./Source/NotificationGateway/Events/Events.csproj /CBS/Source/NotificationGateway/Events/Events.csproj
COPY ./Source/NotificationGateway/Policies/Policies.csproj /CBS/Source/NotificationGateway/Policies/Policies.csproj
COPY ./Source/NotificationGateway/Policies.Specs/Policies.Specs.csproj /CBS/Source/NotificationGateway/Policies.Specs/Policies.Specs.csproj
COPY ./Source/NotificationGateway/Read/Read.csproj /CBS/Source/NotificationGateway/Read/Read.csproj
COPY ./Source/NotificationGateway/Read.Specs/Read.Specs.csproj /CBS/Source/NotificationGateway/Read.Specs/Read.Specs.csproj
COPY ./Source/NotificationGateway/Rules/Rules.csproj /CBS/Source/NotificationGateway/Rules/Rules.csproj
COPY ./Source/NotificationGateway/Rules.Specs/Rules.Specs.csproj /CBS/Source/NotificationGateway/Rules.Specs/Rules.Specs.csproj

WORKDIR /CBS/Source/NotificationGateway
RUN dotnet restore

# Build production code
COPY ./Source/NotificationGateway /CBS/Source/NotificationGateway
WORKDIR /CBS/Source/NotificationGateway/Core
RUN dotnet publish --no-restore -c Release -o out

FROM node:11.6-stretch AS build-web
ARG mode=build-test

# Install dependencies
COPY ./Source/NotificationGateway/Web/package.json /CBS/Source/NotificationGateway/Web/package.json
WORKDIR /CBS/Source/NotificationGateway/Web
RUN yarn install

# Build production code
COPY ./Source/NotificationGateway/Web /CBS/Source/NotificationGateway/Web
WORKDIR /CBS/Source/NotificationGateway/Web
RUN yarn build

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build-web /CBS/Source/NotificationGateway/Web/dist /CBS/Core/wwwroot
COPY ./Source/NotificationGateway/bounded-context.json /CBS/bounded-context.json
COPY --from=build-core /CBS/Source/NotificationGateway/Core/out /CBS/Core/
COPY --from=build-core /CBS/Source/NotificationGateway/Core/.dolittle /CBS/Core/.dolittle
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]
