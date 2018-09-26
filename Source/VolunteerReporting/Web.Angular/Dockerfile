# Build the static content part
FROM node:latest AS angular-build
WORKDIR /src
RUN ["yarn","global", "add", "typescript"]
RUN ["yarn","global", "add", "@angular/cli@6.0.8"]
COPY ./Source/VolunteerReporting/Web.Angular /Source/VolunteerReporting/Web.Angular
COPY ./Source/Navigation /Source/Navigation
WORKDIR /Source/VolunteerReporting/Web.Angular
RUN ["yarn", "install"]
RUN ["yarn", "lint"]
RUN ["ng", "build", "--prod", "--base-href=/reporting/", "--deploy-url=/reporting/"]

FROM nginx:1.13-alpine
COPY --from=angular-build /Source/VolunteerReporting/Web.Angular/dist /usr/share/nginx/html
COPY --from=angular-build /Source/VolunteerReporting/Web.Angular/nginx-default.conf /etc/nginx/conf.d/default.conf
