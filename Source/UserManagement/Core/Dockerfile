FROM microsoft/dotnet:2.2-sdk-bionic AS build

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/UserManagement/UserManagement.sln /CBS/Source/UserManagement/UserManagement.sln
COPY ./Source/UserManagement/Concepts/Concepts.csproj /CBS/Source/UserManagement/Concepts/Concepts.csproj
COPY ./Source/UserManagement/Core/Core.csproj /CBS/Source/UserManagement/Core/Core.csproj
COPY ./Source/UserManagement/Domain/Domain.csproj /CBS/Source/UserManagement/Domain/Domain.csproj
COPY ./Source/UserManagement/Domain.Specs/Domain.Specs.csproj /CBS/Source/UserManagement/Domain.Specs/Domain.Specs.csproj
COPY ./Source/UserManagement/Events/Events.csproj /CBS/Source/UserManagement/Events/Events.csproj
COPY ./Source/UserManagement/Events.VolunteerReporting/Events.VolunteerReporting.csproj /CBS/Source/UserManagement/Events.VolunteerReporting/Events.VolunteerReporting.csproj
COPY ./Source/UserManagement/Policies/Policies.csproj /CBS/Source/UserManagement/Policies/Policies.csproj
COPY ./Source/UserManagement/Read/Read.csproj /CBS/Source/UserManagement/Read/Read.csproj
COPY ./Source/UserManagement/Rules/Rules.csproj /CBS/Source/UserManagement/Rules/Rules.csproj

WORKDIR /CBS/Source/UserManagement
RUN dotnet restore

# Build production code
COPY ./Source/UserManagement /CBS/Source/UserManagement
WORKDIR /CBS/Source/UserManagement/Core
RUN dotnet publish --no-restore -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build /CBS/Source/UserManagement/Core/out /CBS/Core/
COPY --from=build /CBS/Source/UserManagement/Core/.dolittle /CBS/Core/.dolittle
COPY ./Source/UserManagement/bounded-context.json /CBS/bounded-context.json
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]