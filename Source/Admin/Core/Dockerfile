FROM microsoft/dotnet:2.2-sdk-bionic AS build

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

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build /CBS/Source/Admin/Core/out /CBS/Core/
COPY --from=build /CBS/Source/Admin/Core/.dolittle /CBS/Core/.dolittle
COPY ./Source/Admin/bounded-context.json /CBS/bounded-context.json
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]