FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./Navigation /CBS/Source/Navigation
COPY ./UserManagement/Web/package.json /CBS/Source/UserManagement/Web/package.json
WORKDIR /CBS/Source/UserManagement/Web
RUN yarn install

# Build production code
COPY ./UserManagement/Web /CBS/Source/UserManagement/Web
WORKDIR /CBS/Source/UserManagement/Web
RUN npm run ${mode}

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/UserManagement/Web/dist /usr/share/nginx/html
COPY --from=build /CBS/Source/UserManagement/Web/nginx-default.conf /etc/nginx/conf.d/default.conf