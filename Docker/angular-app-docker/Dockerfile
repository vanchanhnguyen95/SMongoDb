FROM node:18.15.0-alpine3.17
RUN addgroup app && adduser -S -G app app
USER app
WORKDIR /app
COPY . .
RUN npm install
ENV API_PATH =http://10.0.10.146:9200
EXPOSE 4201

# shell form
# CMD npm start
# Exec form: nhanh hơn, thuận tiện hơn
CMD [ "npm" , "start" ]
ENTRYPOINT [ "npm" , "start" ]

