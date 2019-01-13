FROM node:11.6 AS build

# Install dependencies
COPY ./NotificationGateway/Web/package.json /CBS/Source/NotificationGateway/Web/package.json
WORKDIR /CBS/Source/NotificationGateway/Web
RUN yarn install

# Build production code
COPY ./NotificationGateway/Web /CBS/Source/NotificationGateway/Web
COPY ./NotificationGateway/Core/wwwroot /CBS/Source/NotificationGateway/Core/wwwroot
COPY ./NotificationGateway/Web/Features/environment.prod.js /CBS/Source/NotificationGateway/Web/Features/environment.js
WORKDIR /CBS/Source/NotificationGateway/Web
RUN npm run build

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/NotificationGateway/Core/wwwroot /usr/share/nginx/html
COPY --from=build /CBS/Source/NotificationGateway/Web/nginx-default.conf /etc/nginx/conf.d/default.conf