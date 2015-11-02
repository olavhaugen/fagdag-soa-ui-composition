# SOA GUI Composition

_Fagdag i Webstep Fokus 6. november 2015_

Dette Git-repoet innholder kode for API og relevant informasjon for å løse oppgavene for dagen. 
Vi ønsker at dere [gjør en Fork](https://help.github.com/articles/fork-a-repo/) av repoet slik at vi kan følge med på de forskjellige løsningene.

## Nyttig informasjon

[Udi Dahan sin bortforklaring](http://udidahan.com/2012/06/23/ui-composition-techniques-for-correct-service-boundaries/)

## Oppgaver

1. Lag en liste av bøker med tittel, pris, bilde, og lagerbeholdning
2. Vi detaljer for en bok
3. Kjøp en bok. Bruker skal fylle ut leveringsadresse, betalingsinformasjon og til slutt få en kvittering for kjøpet.

Sekvensdiagram for #3:

![Sequence diagram](http://www.websequencediagrams.com/cgi-bin/cdraw?lz=dGl0bGUgQnV5IHNpbmdsZSBib29rCgpDbGllbnQtPlNhbGVzOgAbBWJvb2sgKAABBWlkLCBvcmRlciBpZCkKAB8FLT5TaGlwcGluZzogQm9vayBzb2xkICgAFRFCaWxsAAQhV2FyZWhvdXNlADUXAIEVCgBrCVNoaXAgdG8gKGFkZHJlc3MAgRUMAIFFCQB0CVBheSBieSAoY2FyZCBkZXRhaWwAJQ0AgR8HAIFJDFBheW1lbnQgcmVjZWl2ZQCBAg5ub3RlIHJpZ2h0IG9mAIEHBQCBCwtpdCEKAIIVCACBTw1PAII-BXNoaXBwAEMN&s=roundgreen)
<!--sequence
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
-->

## API

APIet skal representere en forenklet versjon av en online bokhandel, tilsvarende Amazon.

Hvis dere ikke ønsker å kjøre koden lokalt, har dere det tilgjengelig i Azure på http://webstepfagfredag.cloudapp.net/

## Tjenester

APIet består av følgende tjenester

### Sales

Produktkatalog (liste over alle bøker)

    GET /sales/books


Detaljer om en bok

    GET /sales/books/{bookId}  

### Marketing

Pris på en bok

    GET /marketing/bookprices/{bookId}

Bilde av boken

    GET /marketing/imageurls/{bookId}

### Shipping

Registere leveringsadresse på en ordre

    POST /shipping/orders/{orderId}?address={address}


### Billing

Registrere betalingsinformasjon på en ordre

    POST /billing/orders/{orderId}?creditCardNumber={creditCardNumber}


### Warehouse

Lagerbeholdning for en bok

    GET /warehouse/inventory/{bookId}
