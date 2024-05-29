# Use an official Node runtime as a parent image
FROM node:alpine

# Set the working directory in the container
WORKDIR /usr/src/app

# Copy package.json and package-lock.json separately for better caching
COPY package*.json ./

# Install project dependencies
RUN npm install

# Copy the rest of the application files
COPY . .

# Install Angular CLI globally
RUN npm install -g @angular/cli

# Set environment variable
ENV NODE_ENV=production

# Command to run the application
CMD ["ng", "serve", "--host", "0.0.0.0"]
