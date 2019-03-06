FROM microsoft/dotnet:2.2-sdk-bionic AS build

# Install dependencies
COPY ./NuGet.Config /CBS/Source/NuGet.Config
COPY ./Source/Alerts/Alerts.sln /CBS/Source/Alerts/Alerts.sln
COPY ./Source/Alerts/Concepts/Concepts.csproj /CBS/Source/Alerts/Concepts/Concepts.csproj
COPY ./Source/Alerts/Core/Core.csproj /CBS/Source/Alerts/Core/Core.csproj
COPY ./Source/Alerts/Domain/Domain.csproj /CBS/Source/Alerts/Domain/Domain.csproj
COPY ./Source/Alerts/Domain.Specs/Domain.Specs.csproj /CBS/Source/Alerts/Domain.Specs/Domain.Specs.csproj
COPY ./Source/Alerts/Events/Events.csproj /CBS/Source/Alerts/Events/Events.csproj
COPY ./Source/Alerts/Events.Admin/Events.Admin.csproj /CBS/Source/Alerts/Events.Admin/Events.Admin.csproj
COPY ./Source/Alerts/Events.Reporting/Events.Reporting.csproj /CBS/Source/Alerts/Events.Reporting/Events.Reporting.csproj
COPY ./Source/Alerts/Policies/Policies.csproj /CBS/Source/Alerts/Policies/Policies.csproj
COPY ./Source/Alerts/Policies.Specs/Policies.Specs.csproj /CBS/Source/Alerts/Policies.Specs/Policies.Specs.csproj
COPY ./Source/Alerts/Read/Read.csproj /CBS/Source/Alerts/Read/Read.csproj
COPY ./Source/Alerts/Read.Specs/Read.Specs.csproj /CBS/Source/Alerts/Read.Specs/Read.Specs.csproj
COPY ./Source/Alerts/Rules/Rules.csproj /CBS/Source/Alerts/Rules/Rules.csproj
COPY ./Source/Alerts/Rules.Specs/Rules.Specs.csproj /CBS/Source/Alerts/Rules.Specs/Rules.Specs.csproj

WORKDIR /CBS/Source/Alerts
RUN dotnet restore

# Build production code
COPY ./Source/Alerts /CBS/Source/Alerts
WORKDIR /CBS/Source/Alerts/Core
RUN dotnet publish --no-restore -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
COPY --from=build /CBS/Source/Alerts/Core/out /CBS/Core/
COPY --from=build /CBS/Source/Alerts/Core/.dolittle /CBS/Core/.dolittle
COPY ./Source/Alerts/bounded-context.json /CBS/bounded-context.json
WORKDIR /CBS/Core
ENTRYPOINT ["dotnet", "/CBS/Core/Core.dll"]