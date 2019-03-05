FROM node:11.6-stretch AS build
ARG mode=build-test

# Install dependencies
COPY ./NotificationGateway/Web/package.json /CBS/Source/NotificationGateway/Web/package.json
WORKDIR /CBS/Source/NotificationGateway/Web
RUN yarn install

# Build production code
COPY ./NotificationGateway/Web /CBS/Source/NotificationGateway/Web
WORKDIR /CBS/Source/NotificationGateway/Web
RUN yarn build

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/NotificationGateway/Web/nginx-default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /CBS/Source/NotificationGateway/Web/dist /usr/share/nginx/html
