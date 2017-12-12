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
COPY --from=angular-build /src/Source/VolunteerReporting/Web/wwwroot ./wwwroot
EXPOSE 5000
ENTRYPOINT ["dotnet", "Web.dll"]