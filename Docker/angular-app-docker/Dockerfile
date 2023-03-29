FROM node:18.15.0-alpine3.17
RUN npm install -g @angular/cli@15.2.4
RUN addgroup app && adduser -S -G app app
USER app
WORKDIR /app
RUN mkdir data
COPY package*.json .
RUN npm install
COPY . .
ENV API_PATH =http://10.0.10.146:9200
EXPOSE 4200

# shell form
# CMD npm start
# Exec form: nhanh hơn, thuận tiện hơn
# CMD [ "npm" , "start" ]
# ENTRYPOINT [ "npm" , "start" ]
ENTRYPOINT [ "ng" ,"serve" ,"--host", "0.0.0.0", "--disable-host-check" ]

