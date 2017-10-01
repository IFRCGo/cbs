# Build the .NET part
FROM microsoft/dotnet:2.0.0-sdk AS dotnet-build
WORKDIR /src
COPY ./NuGet.Config ./
COPY ./Build/MSBuild ./Build/MSBuild
COPY ./Source/Infrastructure ./Source/Infrastructure
COPY ./Source/Example/Catalog ./Source/Example/Catalog
WORKDIR /src/Source/Example/Catalog/Web
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build the static content part
FROM node:latest AS angular-build
WORKDIR /src
RUN ["npm", "install", "-g", "yarn"]
RUN ["yarn","global", "add", "typescript"]
RUN ["yarn","global", "add", "@angular/cli@latest"]
COPY ./Source/Example/Catalog/Web.Angular ./Source/Example/Catalog/Web.Angular
WORKDIR /src/Source/Example/Catalog/Web.Angular
RUN ["yarn", "install"]
RUN ["ng", "build", "--prod"]

# Build runtime image
FROM microsoft/aspnetcore:2.0.0
WORKDIR /app
COPY --from=dotnet-build /src/Source/Example/Catalog/Web/out ./
COPY --from=angular-build /src/Source/Example/Catalog/Web/wwwroot ./wwwroot
EXPOSE 5000
ENTRYPOINT ["dotnet", "Web.dll"]