# My Aviary

## Over de app
Later een grote vogelkooi hebben, met verschillende (handtamme) vogelsoorten is een droom van mij. Vooruitdenkend leek het mij dan ook super om een app bij de hand te hebben die mij kan helpen in het managen van mijn vogels. 

## Features

### Register en log in
Het is mogelijk om te registreren en in te loggen. 
Dit kan als user en als admin.
### My Cages
Hier krijg je je overzicht van je kooien en kan je je kooien toevoegen.
Als je op een kooi klikt, krijg je de detailpagina. Hierop is een foto te zien en de dagelijkse taken die in deze kooi moeten gebeuren. 

### My Birds
Hieronder krijg je een overzicht van alle vogels. Dit door middel van een foto van de vogel, met je eigen gegeven naam, soortnaam en het geslacht. Sorteren kan via kooi, soort en geslacht. Zoeken kan via alle kenmerken.  Als je op een vogel klikt, kom je op de detailpagina van de vogel. Hierop kan je volgende zaken vinden:
-	Naam 
-    Soortnaam
-	Wetenschappelijke naam
-	Locatie (kooi)
-	Geslacht
-	Leeftijd 

### Pairs
Hier krijg je een mooi overzicht van alle vogels die een paartje vormen. Nieuwe paartjes kunnen gemaakt worden via een knop.

### Nests
Op de ‘Nests’ pagina krijg je een overzicht van je nestkasten, met daaronder het eigen geven nummer of eigen gegeven naam en de status. Statussen gaan van “free”, tot “possibly used” tot “used”. Als je op een nest klikt, kom je op de detailpagina. Indien de status op "used" staat zie je hier het pair eronder.



## Werking

### Een kooi toevoegen
Een gebruiker kan meerdere kooien toevoegen. De naam, een foto en de locatie worden gevraagd.

### Een vogel toevoegen
Bij het toevoegen van een vogel worden de volgende zaken gevraagd:
-	de (eigen gegeven) naam
-	de soort:
via een dropdown menu kan je een soort kiezen. 
-	een foto:
je kan hier kiezen om de app je camera te laten gebruiken, of een reeds gemaakte foto up te loaden vanuit je galerij. 
-	de datum waarop de vogel werd uitgebroed 
-	het geslacht
-	de voeding:
     via dropdown menu

### Een paar toevoegen
Als je op de “Add pair” knop duwt op de “Pairs” pagina , wordt eerst gevraagd van welke soort het koppel is.  Vervolgens krijg je via de "add male" en "add female" knoppen een lijst te zien van je vogels van desbetreffend geslacht waaruit je kan kiezen.
### Een nest toevoegen
Bij het toevoegen van een nest wordt een foto en naam gevraagd. Indien je geen foto wenst toe te voegen wordt een standaard foto gebruikt.

### Iets aanpassen of verwijderen
Via een knopje op elke detailpagina krijg je de mogelijkheid om de gegevens aan te passen of te verwijderen.

## Specifieke implementaties voor PRI

Ik zal gebruik maken van een Web API om de data uit mijn database te halen. De app heeft 6 controllers met CRUD methoden:

- BirdsController
- CagesController
- PairsController
- NestsController
- FoodController
- SpeciesController

Een gebruiker kan zich inloggen en registereren. Identity met JWT wordt geimplementeerd. Er is een user en admin rol.
Admin heeft crud rechten op 'species' en 'food' en beheert de users.

Ik zal een vue.js applicatie maken die communiceert met mijn API.
Eén van deze vue-paginas zal communiceren met volgende externe api:

https://some-random-api.ml/animal/bird

 Deze stuurt een willekeurig weetje over vogels terug. Zo kan da gebruiker leuke fait diversjes te weten komen.

### Endpoints
GET api/cages\
GET api/cages/id\
PUT api/cages\
POST api/cages\
DEL api/cages\id\


GET api/birds\
GET api/birds/id\
PUT api/birds\
POST api/birds\
DEL api/birds\id\

GET api/nests\
GET api/nests/id\
PUT api/nests\
POST api/nests\
DEL api/nests\id\

GET api/pairs\
GET api/pairs/id\
PUT api/pairs\
POST api/pairs\
DEL api/pairs\id\

GET api/species\
GET api/species/id\
PUT api/species\
POST api/species\
DEL api/species\id\


GET api/tasks\
GET api/tasks/id\
PUT api/tasks\
POST api/tasks\
DEL api/tasks\id\


GET api/food\
GET api/food/id\
PUT api/food\
POST api/food\
DEL api/food\id\



