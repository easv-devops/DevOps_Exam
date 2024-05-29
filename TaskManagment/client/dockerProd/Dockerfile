# Use an official Node runtime as a parent image
FROM node:alpine

WORKDIR /usr/src/app

COPY . /usr/src/app

RUN npm install

COPY . .

RUN npm install -g @angular/cli

CMD ["ng", "serve", "--host", "0.0.0.0", "-c", "production"]
