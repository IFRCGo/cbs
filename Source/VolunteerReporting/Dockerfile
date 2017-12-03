# Build the .NET part
FROM microsoft/dotnet:2.0.0-sdk AS dotnet-build
WORKDIR /src
COPY ./NuGet.Config ./
COPY ./Build/MSBuild ./Build/MSBuild
COPY ./Source/Infrastructure ./Source/Infrastructure
COPY ./Source/VolunteerReporting ./Source/VolunteerReporting
WORKDIR /src/Source/VolunteerReporting/Web
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build the static content part
FROM node:latest AS angular-build
WORKDIR /src
RUN ["npm", "install", "-g", "yarn"]
RUN ["yarn","global", "add", "typescript"]
RUN ["yarn","global", "add", "@angular/cli@latest"]
COPY ./Source/VolunteerReporting/Web.Angular ./Source/VolunteerReporting/Web.Angular
WORKDIR /src/Source/VolunteerReporting/Web.Angular
RUN ["yarn", "install"]
RUN ["ng", "build", "--prod"]

# Build runtime image
FROM microsoft/aspnetcore:2.0.0
WORKDIR /app
COPY --from=dotnet-build /src/Source/VolunteerReporting/Web/out ./
COPY --from=angular-build /src/Source/VolunteerReporting/Web/wwwroot ./wwwroot
EXPOSE 5000
ENTRYPOINT ["dotnet", "Web.dll"]