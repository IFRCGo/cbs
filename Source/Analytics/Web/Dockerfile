FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./Source/Analytics/Web/package.json /CBS/Source/Analytics/Web/package.json
WORKDIR /CBS/Source/Analytics/Web
RUN yarn install

# Build production code
COPY ./Source/Analytics/Web /CBS/Source/Analytics/Web
WORKDIR /CBS/Source/Analytics/Web
RUN yarn build

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/Analytics/Web/nginx-default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /CBS/Source/Analytics/Web/dist /usr/share/nginx/html
