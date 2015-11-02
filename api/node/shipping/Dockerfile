FROM node:4.2.1
COPY . /src
RUN cd /src; npm install
EXPOSE 3002
CMD ["node", "/src/index.js"]
