FROM microsoft/dotnet:2.2-sdk-bionic AS build

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/Reporting/Reporting.sln /CBS/Source/Reporting/Reporting.sln
COPY ./Source/Reporting/Concepts/Concepts.csproj /CBS/Source/Reporting/Concepts/Concepts.csproj
COPY ./Source/Reporting/Core/Core.csproj /CBS/Source/Reporting/Core/Core.csproj
COPY ./Source/Reporting/Domain/Domain.csproj /CBS/Source/Reporting/Domain/Domain.csproj
COPY ./Source/Reporting/Domain.Specs/Domain.Specs.csproj /CBS/Source/Reporting/Domain.Specs/Domain.Specs.csproj
COPY ./Source/Reporting/Events/Events.csproj /CBS/Source/Reporting/Events/Events.csproj
COPY ./Source/Reporting/Events.Admin/Events.Admin.csproj /CBS/Source/Reporting/Events.Admin/Events.Admin.csproj
COPY ./Source/Reporting/Events.NotificationGateway/Events.NotificationGateway.csproj /CBS/Source/Reporting/Events.NotificationGateway/Events.NotificationGateway.csproj
COPY ./Source/Reporting/Policies/Policies.csproj /CBS/Source/Reporting/Policies/Policies.csproj
COPY ./Source/Reporting/Policies.Specs/Policies.Specs.csproj /CBS/Source/Reporting/Policies.Specs/Policies.Specs.csproj
COPY ./Source/Reporting/Read/Read.csproj /CBS/Source/Reporting/Read/Read.csproj
COPY ./Source/Reporting/Read.Specs/Read.Specs.csproj /CBS/Source/Reporting/Read.Specs/Read.Specs.csproj
COPY ./Source/Reporting/Rules/Rules.csproj /CBS/Source/Reporting/Rules/Rules.csproj
COPY ./Source/Reporting/Rules.Specs/Rules.Specs.csproj /CBS/Source/Reporting/Rules.Specs/Rules.Specs.csproj

WORKDIR /CBS/Source/Reporting
RUN dotnet restore

# Build production code
COPY ./Source/Reporting /CBS/Source/Reporting
WORKDIR /CBS/Source/Reporting/Core
RUN dotnet publish --no-restore -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build /CBS/Source/Reporting/Core/out /CBS/Core/
COPY --from=build /CBS/Source/Reporting/Core/.dolittle /CBS/Core/.dolittle
COPY ./Source/Reporting/bounded-context.json /CBS/bounded-context.json
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]