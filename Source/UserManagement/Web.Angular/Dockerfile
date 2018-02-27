# Build the static content part
FROM node:latest AS angular-build
WORKDIR /src
RUN ["npm", "install", "-g", "yarn"]
RUN ["yarn","global", "add", "typescript"]
RUN ["yarn","global", "add", "@angular/cli@latest"]
COPY . /src
WORKDIR /src
RUN ["yarn", "install"]
RUN ["ng", "build", "--prod --base-ref /users/"]

FROM nginx:1.13-alpine
COPY --from=angular-build /src/dist /usr/share/nginx/html