FROM node:11.6-slim AS build
ARG mode=build-test

# Install dependencies
COPY ./Navigation /CBS/Source/Navigation
COPY ./VolunteerReporting/Web/package.json /CBS/Source/VolunteerReporting/Web/package.json
WORKDIR /CBS/Source/VolunteerReporting/Web
RUN yarn install

# Build production code
COPY ./VolunteerReporting/Web /CBS/Source/VolunteerReporting/Web
WORKDIR /CBS/Source/VolunteerReporting/Web
RUN npm run ${mode}

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /CBS/Source/VolunteerReporting/Web/dist /usr/share/nginx/html
COPY --from=build /CBS/Source/VolunteerReporting/Web/nginx-default.conf /etc/nginx/conf.d/default.conf