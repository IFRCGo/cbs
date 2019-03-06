FROM node:11.6-stretch AS build
ARG mode=build-test

# Install dependencies
COPY ./Alerts/Web/package.json /CBS/Source/Alerts/Web/package.json
WORKDIR /CBS/Source/Alerts/Web
RUN yarn install

# Build production code
COPY ./Alerts/Web /CBS/Source/Alerts/Web
WORKDIR /CBS/Source/Alerts/Web
RUN yarn build

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/Alerts/Web/nginx-default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /CBS/Source/Alerts/Web/dist /usr/share/nginx/html
