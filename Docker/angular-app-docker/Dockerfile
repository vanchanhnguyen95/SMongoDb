FROM node:18.5.0-alpine3.16
WORKDIR /app
COPY . .
RUN npm install
ENV API_PATH =http://10.0.10.146:9200
EXPOSE 4200
RUN addgroup app && adduser -S -G app app
USER app
