FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./Navigation /CBS/Source/Navigation
COPY ./Analytics/Web.Frontend/package.json /CBS/Source/Analytics/Web.Frontend/package.json
WORKDIR ./CBS/Source/Navigation/Web.Common
RUN npm install
WORKDIR ./CBS/Source/Navigation/Web.NodeJS
RUN npm install

WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN npm install

# Build production code
COPY ./Analytics/Web.Frontend /CBS/Source/Analytics/Web.Frontend
WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN npm run ${mode}

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/Analytics/Web/dist /usr/share/nginx/html
COPY --from=build /CBS/Source/Analytics/Web/nginx-default.conf /etc/nginx/conf.d/default.conf