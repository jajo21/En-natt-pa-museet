# En natt på museet - December 2021
## Instruktioner
1. Ladda ner repot från https://github.com/jajo21/En-natt-pa-museet
2. Leta upp valfri terminal och utgå från mappen "museet"
3. Applikationen kräver att du har .NET SDK installerat
4. Skriv kommandot ```dotnet run``` i terminalen
5. Applikationen körs nu i terminalen

## Syfte - YH-utbildning: Webbutvecklare .NET
* Inlämningsuppgift i kursen Objektorienterad Programmering med C# - December 2021
* Beskrivning: Du jobbar i det här scenariot som frilansande programmerare år 1979 och har fått ett uppdrag att göra ett modernt arbetsverkyg till ett konstmuseum, som personalen kan använda från deras splirrans nya datorterminal. Datorn har alla moderna program installerade man kan tänkas behöva - men personalen skulle behöva ett arbetsverktyg för att hålla koll på och inventera deras olika rum och konstverk! Du har pitchat en idé att programmet ska fungera precis som alla andra program via command line arguments - vilket personalen är väldigt positivt inställda till.
* Resultat: 97/100 (VG)

## Tekniker
* .NET Core
* .NET Core CLI
* OOP
* C#
* xUnit

## Kravspecifikation
|Krav|Uppfyllt|Förklaring|
|---|---|---|
|**1** |**Ja**| *Lösningen ska vara en vidareutveckling av det givna kodrepot från Github Classroom.*|
|**2** |**Ja**| *Programmet går att starta vid inläming, och via den virtuella konsollen kan applikationen 'mu' användas.*|
|**3** |**Ja**| *Applikationen 'mu' kan med ett lämpligt kommando lista alla rum samt konstverken som finns i rummet.*|
|**4** |**Ja**| *Applikationen 'mu' kan med ett lämpligt kommando lista alla konstverken som finns i ett specifikt rum, rummet är angivet i kommandot.*|
|**5** |**Ja**| *Applikationen 'mu' kan med ett lämpligt kommando lägga till ett nytt konstverk i ett rum.*|
|**6** |**Ja**| *Applikationen 'mu' kan med ett lämpligt kommando radera ett specifikt konstverk från ett rum.*|
|**7** |**Ja**| *Applikationen 'mu' kan med ett lämpligt kommando lägga till ett helt nytt rum i museet.*|
|**8** |**Ja**| *Applikationen 'mu' kan med ett lämpligt kommando radera ett specifikt rum i museet.*|
|**9** |**Ja**| *Varje konstverk representeras i kod via en **titel**, **beskrivning** och en **upphovsmakare***|
|**10** |**Ja**| *Endast 3 konstverk kan finnas i varje rum.*|
|**11** |**Ja**| *Ett rum kan inte raderas om det finns konstverk i rummet.*|
|**12** |**Ja**| *Med applikationen 'mu' kan man skapa ett helt nytt museum/byggnad.*|
|**13** |**Ja**| *Via applikationen 'mu' kan man med kommandot 'select' välja vilken vald byggnad övriga kommandon utförs på, man behöver inte alltid ange vilket museeum som används.*|
|**14** |**Ja**| *Koden är strukturad på ett sådant sätt att Console klassen är väl separerad från programmets modellklasser (i.e. "konstverk" och "rum") - så att dessa går att återanvända i framtida applikationer*|
|**15** |**Ja**| *Repot ska lämnas in med minst **3 enhetstester** implementerade.*|
|**16** |**Ja**| *Enhetstesterna bevisar att flera museum/byggnader kan finnas med olika uppställningar av konstverk och rum.*|
|**17** |**Ja**| *Enhetstesterna bevisar att reglerna i krav _10_ & _11_ alltid efterföljs.*|
|**18** |**Ja**| *Lösningen ska förutom kod innehålla en fil med namnet "reflections" i formatet _md_, _txt_ eller _pdf_.*|
|**19** |**Ja**| *reflections_-filen ska under rubriken "Kommandon" innehålla en **kortfattad** beskrivning av vilka _verb_ som är tillgängliga i din applikation och vad som anges som ytterligare argument för varje verb - - varför dessa är lämpliga argument till verbet.*|
|**20** |**Ja**| *reflections_-filen ska under rubriken "Seperation" beskriva hur du har seperarat användningen av _System.Consol_ från dina modell-klasser. (1-4 paragrafer)*|
|**21** | **Ja**| *reflections_-filen ska under rubriken "Testning" beskriva de tester du skapat och deras syfte i lösningen samt en **motivering** varför just dessa tester är lämpliga i denna uppgift (2-3 paragrafer)*|
