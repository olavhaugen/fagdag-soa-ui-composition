Book store API in nancy
=======================

Sales module
------------

Get book catalog

    http://localhost:5000/books

Get book details

    http://localhost:5000/books/1

Marketing module
----------------

Get price 

    http://localhost:5001/books/1

Billing module
--------------

Post billing details

    POST http://localhost:5002/billingDetails/1

Shipping module
---------------

Post shipping details

    POST http://localhost:5003/shippingDetails/1
