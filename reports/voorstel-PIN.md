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

## Specifieke implementaties voor PIN

De applicatie wordt ontwikkeld in Blazor.\
Concepts:
Er wordt een 'expenses' pagina voorzien.
Hier kan men maandelijkse uitgaven toevoegen voor verschillende rubrieken:
- medicijnen
- dierenartskosten
- voeder
- materiaal
- allerlei

Eventueel kunnen kosten per individuele vogel berekend worden om zo te kunnen berekenen welke vogel het duurst is om te houden.

Deze gegevens worden in een grafiek gegoten.

