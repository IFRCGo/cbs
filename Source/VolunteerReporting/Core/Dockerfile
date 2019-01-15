FROM microsoft/dotnet:2.2-sdk-bionic AS build

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/VolunteerReporting/VolunteerReporting.sln /CBS/Source/VolunteerReporting/VolunteerReporting.sln
COPY ./Source/VolunteerReporting/Concepts/Concepts.csproj /CBS/Source/VolunteerReporting/Concepts/Concepts.csproj
COPY ./Source/VolunteerReporting/Core/Core.csproj /CBS/Source/VolunteerReporting/Core/Core.csproj
COPY ./Source/VolunteerReporting/Domain/Domain.csproj /CBS/Source/VolunteerReporting/Domain/Domain.csproj
COPY ./Source/VolunteerReporting/Domain.Specs/Domain.Specs.csproj /CBS/Source/VolunteerReporting/Domain.Specs/Domain.Specs.csproj
COPY ./Source/VolunteerReporting/Events/Events.csproj /CBS/Source/VolunteerReporting/Events/Events.csproj
COPY ./Source/VolunteerReporting/Events.Admin/Events.Admin.csproj /CBS/Source/VolunteerReporting/Events.Admin/Events.Admin.csproj
COPY ./Source/VolunteerReporting/Events.NotificationGateway/Events.NotificationGateway.csproj /CBS/Source/VolunteerReporting/Events.NotificationGateway/Events.NotificationGateway.csproj
COPY ./Source/VolunteerReporting/Policy/Policy.csproj /CBS/Source/VolunteerReporting/Policy/Policy.csproj
COPY ./Source/VolunteerReporting/Read/Read.csproj /CBS/Source/VolunteerReporting/Read/Read.csproj
COPY ./Source/VolunteerReporting/TextMessaging/TextMessaging.csproj /CBS/Source/VolunteerReporting/TextMessaging/TextMessaging.csproj

WORKDIR /CBS/Source/VolunteerReporting
RUN dotnet restore

# Build production code
COPY ./Source/VolunteerReporting /CBS/Source/VolunteerReporting
WORKDIR /CBS/Source/VolunteerReporting/Core
RUN dotnet publish --no-restore -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build /CBS/Source/VolunteerReporting/Core/out /CBS/Core/
COPY --from=build /CBS/Source/VolunteerReporting/Core/.dolittle /CBS/Core/.dolittle
COPY ./Source/VolunteerReporting/bounded-context.json /CBS/bounded-context.json
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]