# Build the .NET part
FROM microsoft/dotnet:2.0.5-sdk AS dotnet-build
WORKDIR /src
COPY ./NuGet.Config ./
COPY ./Build/MSBuild ./Build/MSBuild
COPY ./Source/Infrastructure ./Source/Infrastructure
COPY ./Source/Admin ./Source/Admin
WORKDIR /src/Source/Admin/Web
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0.5-runtime
WORKDIR /app
COPY --from=dotnet-build /src/Source/Admin/Web/out .
ENTRYPOINT ["dotnet", "Web.dll"]