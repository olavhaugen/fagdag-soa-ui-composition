![Seqeunce diagram](http://www.websequencediagrams.com/cgi-bin/cdraw?lz=dGl0bGUgQnV5IHNpbmdsZSBib29rCgpDbGllbnQtPlNhbGVzOgAbBWJvb2sgKAABBWlkLCBvcmRlciBpZCkKCgAgBS0-U2hpcHBpbmc6IEJvb2sgc29sZCAoAB0KAB8HQmlsbAAEIVdhcmVob3VzZQA1FwCBFgoAawlTaGlwIHRvIChhZGRyZXNzAIEVDQCBRwkAdQlQYXkgYnkgKGNhcmQgZGV0YWlsACYNAIEgBwCBSgxQYXltZW50IHJlY2VpdmUAgQMObm90ZSByaWdodCBvZgCBCAUAgQwLaXQhCgoAghcIAIFRDU8AgkEFc2hpcHAAQw4&s=napkin)
```sequence
title Buy single book

Client->Sales: Buy book (book id, order id)
Sales->Shipping: Book sold (order id)
Sales->Billing: Book sold (order id)
Sales->Warehouse: Book sold (order id)

Client->Shipping: Ship to (address, order id)

Client->Billing: Pay by (card details, order id)
Billing->Shipping: Payment received (order id)

note right of Shipping: Ship it!
Shipping->Warehouse: Order shipped (order id)
```
Generated with [www.websequencediagrams.com]( https://www.websequencediagrams.com/)