# ARCleanArchitecture

Példa projekt, melynek célja a Clean Architecture bemutatása. A projekt szerkezete ez a [github repo](https://github.com/genki-tx/UnitySimpleCleanArchitecturePlane) alapján készült.

## Projekt és a Clean Architecture

A CA 4 fő rétegből áll:

+ Entities: Idekerülnek azok az elemek, amelyek a legkevesebbszer változnak. (Core mappa)
+ Use Cases: Az applikációhoz specifikus műveletek, melyeket a felhasználó tud végezni. (App mappa)
+ Interface adapters: Feladatuk a use case-k összekötése a külső funkciókkal. (Infrastructure, Presenters)
+ Frameworks and drivers: Gyakran változó dolgok pl. UI, külső szolgáltatások, adatbázisok, Web API-k (Ebben csak view-k)

Lényegében ezek a rétegek absztrakció és a változás sűrűsége alapján különülnek el. Felül a legabsztraktabb, de legkevésbé változó, és ahogy haladunk kifelé(listában lefelé) egyre inkább változó, direkt implementációk vannak.

## Szükséges framework

A projekt a Dependency Injection megvalósítására [VContainert](https://github.com/hadashiA/VContainer) használ. 
Amennyiben ezt nem telepítené, ennek legegyszerűbb módja:

+ Projekt mappájában Packages, majd manifest.json
+ és a dependency-k közé: "jp.hadashikick.vcontainer": "https://github.com/hadashiA/VContainer.git?path=VContainer/Assets/VContainer#1.17.0"

Ez egy scope-ban regisztrált elemeket tud injektálni. Meglehet adni kulcsot is ami alapján hivatkozni szeretnénk rájuk, illetve képes akár új gameobjecteket is létrehozni, amire rárakja őket.
Amennyiben Monobehaviour-be szeretnénk injektálni azokat is regisztrálni kell.

