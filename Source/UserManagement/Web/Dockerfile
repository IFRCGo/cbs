# Build the .NET part
FROM microsoft/dotnet:2.2-sdk-bionic AS dotnet-build
WORKDIR /src
COPY ./NuGet.Config ./
COPY ./Build/MSBuild ./Build/MSBuild
COPY ./Source/Infrastructure ./Source/Infrastructure
COPY ./Source/UserManagement ./Source/UserManagement
WORKDIR /src/Source/UserManagement/Web
RUN dotnet restore --no-cache
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic
WORKDIR /app
COPY --from=dotnet-build /src/Source/UserManagement/Web/out .
ENTRYPOINT ["dotnet", "Web.dll"]