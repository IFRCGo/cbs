# Build the static content part
FROM node:latest AS angular-build
WORKDIR /src
RUN ["yarn","global", "add", "typescript"]
RUN ["yarn","global", "add", "@angular/cli@6.0.8"]
COPY ./Source/UserManagement/Web.Angular /Source/UserManagement/Web.Angular
COPY ./Source/Navigation /Source/Navigation
WORKDIR /Source/UserManagement/Web.Angular
RUN ["yarn", "install"]
RUN ["ng", "build", "--prod", "--base-href=/users/", "--deploy-url=/users/"]

FROM nginx:1.13-alpine
COPY --from=angular-build /Source/UserManagement/Web.Angular/dist /usr/share/nginx/html
COPY --from=angular-build /Source/UserManagement/Web.Angular/nginx-default.conf /etc/nginx/conf.d/default.conf
