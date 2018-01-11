# Build the static content part
FROM node:latest
WORKDIR /src
COPY package.json /src
RUN npm install
COPY . /src

EXPOSE 4200
CMD ["npm", "start"]

#https://stackoverflow.com/questions/45525227/different-proxy-config-based-on-environment-in-angular-2-cli?noredirect=1&lq=1