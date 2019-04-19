FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./Source/Analytics/Web.Frontend/package.json /CBS/Source/Analytics/Web.Frontend/package.json
WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN yarn install

# Build production code
COPY ./Source/Analytics/Web.Frontend /CBS/Source/Analytics/Web.Frontend
WORKDIR /CBS/Source/Analytics/Web.Frontend
RUN yarn build

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/Analytics/Web.Frontend/nginx-default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /CBS/Source/Analytics/Web.Frontend/dist /usr/share/nginx/html
