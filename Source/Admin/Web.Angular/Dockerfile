# Build the static content part
FROM node:latest AS angular-build
WORKDIR /src
RUN ["yarn","global", "add", "typescript"]
RUN ["yarn","global", "add", "@angular/cli@6.0.8"]
COPY ./Source/Admin/Web.Angular /Source/Admin/Web.Angular
COPY ./Source/Navigation /Source/Navigation
WORKDIR /Source/Admin/Web.Angular
RUN ["yarn", "install"]
RUN ["ng", "build", "--prod"]

FROM nginx:1.13-alpine
COPY --from=angular-build /Source/Admin/Web.Angular/dist /usr/share/nginx/html
COPY --from=angular-build /Source/Admin/Web.Angular/nginx-default.conf /etc/nginx/conf.d/default.conf
