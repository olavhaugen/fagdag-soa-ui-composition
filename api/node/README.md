API in node.js
==============

Run locally via node.js
-----------------------
cd all-in-one
npm install
node .

curl http://localhost:3000/books
curl http://localhost:3000/books/1
curl http://1localhost:3001/books/1
curl -X POST http://localhost:3002/billingDetails/1
curl -X POST http://localhost:3003/shippingDetails/1


Run in docker containers
------------------------
cd all-in-one
docker build --tag api-v1 .
docker run -ti -p 3000:3000 -p 3001:3001 -p 3002:3002 -p 3003:3003 api-v1

curl http://192.168.99.100:3000/books
curl http://192.168.99.100:3000/books/1
curl http://192.168.99.100:3001/books/1
curl -X POST http://192.168.99.100:3002/billingDetails/1
curl -X POST http://192.168.99.100:3003/shippingDetails/1

(IP-address must be changed to your docker machine)


Run all containers
------------------
docker-compose up