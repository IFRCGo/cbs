FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/Analytics/Analytics.sln /CBS/Source/Analytics/Analytics.sln
COPY ./Source/Analytics/Concepts/Concepts.csproj /CBS/Source/Analytics/Concepts/Concepts.csproj
COPY ./Source/Analytics/Core/Core.csproj /CBS/Source/Analytics/Core/Core.csproj
COPY ./Source/Analytics/Domain/Domain.csproj /CBS/Source/Analytics/Domain/Domain.csproj
COPY ./Source/Analytics/Domain.Specs/Domain.Specs.csproj /CBS/Source/Analytics/Domain.Specs/Domain.Specs.csproj
COPY ./Source/Analytics/Events/Events.csproj /CBS/Source/Analytics/Events/Events.csproj
COPY ./Source/Analytics/Policies/Policies.csproj /CBS/Source/Analytics/Policies/Policies.csproj
COPY ./Source/Analytics/Policies.Specs/Policies.Specs.csproj /CBS/Source/Analytics/Policies.Specs/Policies.Specs.csproj
COPY ./Source/Analytics/Read/Read.csproj /CBS/Source/Analytics/Read/Read.csproj
COPY ./Source/Analytics/Read.Specs/Read.Specs.csproj /CBS/Source/Analytics/Read.Specs/Read.Specs.csproj
COPY ./Source/Analytics/Rules/Rules.csproj /CBS/Source/Analytics/Rules/Rules.csproj
COPY ./Source/Analytics/Rules.Specs/Rules.Specs.csproj /CBS/Source/Analytics/Rules.Specs/Rules.Specs.csproj
COPY ./Navigation /CBS/Source/Navigation
COPY ./Analytics/Web.Frontend/package.json /CBS/Source/Analytics/Web.Frontend/package.json

WORKDIR ./CBS/Source/Navigation/Web.Common
RUN npm install
WORKDIR ./CBS/Source/Navigation/Web.NodeJS
RUN npm install

WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN npm install

# Build production code
COPY ./Source/Analytics /CBS/Source/Analytics
WORKDIR /CBS/Source/Analytics/Core
RUN dotnet publish --no-restore -c Release -o out

COPY ./Analytics/Web.Frontend /CBS/Source/Analytics/Web.Frontend
WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN npm run ${mode}

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/Analytics/Web/dist /usr/share/nginx/html
COPY --from=build /CBS/Source/Analytics/Web/nginx-default.conf /etc/nginx/conf.d/default.conf