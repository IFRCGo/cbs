FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./Navigation /CBS/Source/Navigation
COPY ./Admin/Web/package.json /CBS/Source/Admin/Web/package.json
WORKDIR /CBS/Source/Admin/Web
RUN yarn install

# Build production code
COPY ./Admin/Web /CBS/Source/Admin/Web
WORKDIR /CBS/Source/Admin/Web
RUN npm run ${mode}

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/Admin/Web/dist /usr/share/nginx/html
COPY --from=build /CBS/Source/Admin/Web/nginx-default.conf /etc/nginx/conf.d/default.conf