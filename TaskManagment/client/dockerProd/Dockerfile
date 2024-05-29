# Use an official Node runtime as a parent image
FROM node:alpine

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm install -g @angular/cli

ENV NODE_ENV=production

CMD ["ng", "serve", "--host", "0.0.0.0", "-c", "production"]
