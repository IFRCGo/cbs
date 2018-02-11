# Build the .NET part
FROM microsoft/dotnet:2.0.5-sdk-2.1.4 AS dotnet-build
WORKDIR /src
COPY ./NuGet.Config ./
COPY ./Build/MSBuild ./Build/MSBuild
COPY ./Source/Infrastructure ./Source/Infrastructure
COPY ./Source/VolunteerReporting ./Source/VolunteerReporting
WORKDIR /src/Source/VolunteerReporting/Web
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0.5-runtime
WORKDIR /app
COPY --from=dotnet-build /src/Source/VolunteerReporting/Web/out .
ENTRYPOINT ["dotnet", "Web.dll"]