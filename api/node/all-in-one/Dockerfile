FROM node:4.2.1
COPY . /src
RUN cd /src; npm install
EXPOSE 3000 3001 3002 3003
CMD ["node", "/src/index.js"]
