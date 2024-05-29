# Stage 1: Build the Angular app
FROM node:alpine as build

WORKDIR /usr/src/app

# Copy package.json and package-lock.json separately for better caching
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application files
COPY . .

# Build the Angular app in production mode
RUN npm run build -- --configuration=production

# Stage 2: Serve the app with nginx
FROM nginx:alpine

# Copy the build output to the nginx html directory
COPY --from=build /usr/src/app/dist /usr/share/nginx/html

# Expose port 80
EXPOSE 4200

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
