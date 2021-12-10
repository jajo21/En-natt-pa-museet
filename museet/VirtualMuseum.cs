using System;
using Museet.Models;
using Simulator;

namespace Museet
{
    internal class VirtualMuseumProgram : IApplication
    {
        MuseumCollection museumCollection;
        TestMuseum testMuseum; // Frivillig att använda, lägger till ett testmuseum (namn = bilmuseum).
        public VirtualMuseumProgram()
        {
            museumCollection = new MuseumCollection();
            testMuseum = new TestMuseum(museumCollection); // Frivillig att använda, lägger till ett testmuseum i musemCollection (namn = bilmuseum).
        }

        public void Run(string verb, string[] options)
        {
            switch (verb)
            {
                case "select": // mu select [museum-namn], för att ta sig in i valt museum, samt felhantering.
                    if(options.Length == 0)
                    {
                        System.Console.WriteLine("[MU] Inget museum valt. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if(!museumCollection.GetDictionary().ContainsKey(options[0])) 
                    {
                        Console.WriteLine("Museumet finns inte, skriv [mu show museums] för att se vilka museum som finns tillgängliga.");
                        Console.WriteLine("Eller skriv [mu help] för att se överiga kommandon.");
                    }
                    else 
                    {
                         SelectMuseum(options[0]); 
                    }
                    break;
                case "show": // Skriver ut information på skärmen beroende på användarens val, samt felhantering.
                    if(options.Length == 0)
                    {
                        System.Console.WriteLine("[MU] Inget av de existerande kommandona för att visa museer, rum eller konstverk är valt. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if (options[0] == "rooms") // mu show rooms, för att visa alla rum i det museumet man är i för stunden
                    {
                        ShowRoomAndArtInSelectedMuseum(); 
                    }
                    else if (options[0] == "room") // mu show room [rums-namn], för att visa konstverk i rummet.
                    {
                        ShowArtInRoom(options[1]); 
                    }
                    else if (options[0] == "museums") // mu show museums, för att visa alla tillgängliga museum.
                    {
                        Console.WriteLine($"Det här är de museer du kan välja mellan:");
                        Console.WriteLine(museumCollection.GetAllMuseumNames()); 
                    }
                    else
                    {
                        Console.WriteLine("Okänt kommando, skriv [mu help] för att se tillgänliga kommandon.");
                    }
                    break;
                case "add": // Adderar innehåll i programmet, samt felhantering.
                    if(options.Length == 0)
                    {
                        Console.WriteLine("[MU] Inget av de existerande kommandona för att lägga till museum, rum eller konstverk är valt. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if (options[0] == "museum")// mu add museum [museum-namn], för att lägga till ett nytt museum
                    {
                        AddNewMuseum(options[1]); 
                    }
                    else if (options[0] == "room")// mu add room [room-name], för att lägga till ett nytt rum i nuvarande museum
                    {
                        AddNewRoom(options[1]); 
                    }
                    else if (options[0] == "art")// mu add art [room-name], för att ta användaren in i en metod där du får lägga till info om konsten
                    {
                        AddNewArt(options[1]); 
                    }
                    else 
                    {
                        Console.WriteLine("Okänt kommando, skriv [mu help] för att se tillgänliga kommandon.");
                    }
                    break;
                case "delete": // Tar bort antingen rum eller konstverk från museet, samt felhantering.
                    if(options.Length == 0)
                    {
                        Console.WriteLine("[MU] Inget av de existerande kommandona för att ta bort rum eller konstverk är valt. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if (options[0] == "art")// mu delete art [room-name] [art-place], för att ta bort konst på vald plats i rummet
                    {
                        DeleteArtFromRoom(options[1], options[2]); 
                    }
                    else if (options[0] == "room")// mu delete room [room-name], för att ta bort rum från museet, rummet måste vara tomt
                    {
                        DeleteRoomFromMuseum(options[1]);  
                    }
                    else
                    {
                        Console.WriteLine("Okänt kommando, skriv [mu help] för att se tillgänliga kommandon.");
                    }
                    break;
                case "help":// mu help, få en lista med kommandon som kan användas
                    WriteHelpCommands(); 
                    break;
                default:
                    System.Console.WriteLine("Okänt kommando!\n");
                    WriteHelpCommands();
                    break;
            }
        }
        // Väljer vilket museum användaren ska vara på
        public void SelectMuseum(string museumChoice)
        {
            if (museumChoice == museumCollection.GetDictionary()[museumChoice].GetMuseumName()) // Om museumnamn-inputen finns i dictionaryn
            {
                museumCollection.SetVisitingMuseum(museumChoice); // Sätt värdet på visiting variabeln till samma namn
                Console.WriteLine($"Du är nu på museet {museumChoice}!");
            }
        }
        // Visar alla rum och all konst i museet du befinner dig på
        private void ShowRoomAndArtInSelectedMuseum()
        {
            if (museumCollection.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumCollection.GetDictionary())
                {
                    if (museumCollection.GetVisitingMuseumName() == museum.Key)
                    {
                        if(museum.Value.GetListCount() == 0) {
                            Console.WriteLine("Museet har för närvarande inga rum eller konstverk!");
                        }
                        else
                        {
                            Console.WriteLine($"Museum: {museum.Key}");
                            Console.WriteLine("Konstverken presenteras i denna ordning -- titel, beskrivning, konstnär --");
                            Console.WriteLine($"{museum.Value.GetRoomAndArtStrings()}");   
                        }
                        
                    }
                }
            }
        }
        // Visar konst ifrån användarens valda rum.
        private void ShowArtInRoom(string roomName)
        {
            if (museumCollection.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumCollection.GetDictionary())
                {
                    if (museumCollection.GetVisitingMuseumName() == museum.Key)
                    {
                        bool isRoomInMuseum = false;
                        foreach (var room in museum.Value.GetList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                Console.WriteLine($"I rummet {room.GetRoomNameString()} finns följande konst: \n{room.GetAllArtInRoomString()}");
                                isRoomInMuseum = true;
                            }
                        }
                        if(!isRoomInMuseum) 
                        {
                            Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum.");
                        }
                    }
                }
            }
        }
        //Lägger till ett nytt museum
        public void AddNewMuseum(string museumName)
        {
            if (museumName.Length > 0)
            {
                museumCollection.AddContent(new Museum(museumName));
                Console.WriteLine($"Museum {museumName} tillagt!");
            }
            else
            {
                Console.WriteLine("Du måste skriva minst ett tecken för att skapa ett nytt museum!");
                Console.WriteLine("Testa igen! Eller skriv [mu help] för hjälp");
            }
        }
        //Lägger till ett nytt rum i museumet
        public void AddNewRoom(string roomName)
        {
            if (roomName.Length > 0)
            {
                if (museumCollection.GetVisitingMuseumName() == "")
                {
                    Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [namn] eller skriv mu help för hjälp!");
                }
                else
                {
                    foreach (var museum in museumCollection.GetDictionary())
                    {
                        if (museumCollection.GetVisitingMuseumName() == museum.Key)
                        {
                            museum.Value.AddContent(new Room(roomName));
                        }
                    }
                    Console.WriteLine($"Rum {roomName} tillagt i museum {museumCollection.GetVisitingMuseumName()}");
                }
            }
            else
            {
                Console.WriteLine("Du måste skriva minst ett tecken för att skapa ett nytt rum!");
                Console.WriteLine("Testa igen! Eller skriv [mu help] för hjälp");
            }
        }
        //Lägger till ett nytt konstverk i valt rum om inputen är korrekt och användaren har valt museum
        private void AddNewArt(string roomName)
        {
            if (roomName.Length > 0)
            {
                if (museumCollection.GetVisitingMuseumName() == "") // Om användaren inte valt museum
                {
                    Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [namn] eller skriv mu help för hjälp!");
                }
                else
                {
                    foreach (var museum in museumCollection.GetDictionary()) // hittar alla museum i Dictionaryn
                    {
                        if (museumCollection.GetVisitingMuseumName() == museum.Key) // om det museum du besöker(visiting variabeln i MuseumCollection) stämmer överens med keyn i dictionaryn
                        {
                            bool isRoomInMuseum = false;
                            foreach (var room in museum.Value.GetList()) // hitta alla rum i rumslistan
                            {
                                
                                if (roomName == room.GetRoomNameString()) // om användarens input är samma som ett rumsnamn i listan
                                {
                                    if (room.isRoomFull()) // om rumslistan är full
                                    {
                                        Console.WriteLine("Rummet är tyvärr fullt. Testa att fylla på ett annat rum!");
                                    }
                                    else // annars lägg till nytt rum
                                    {
                                        Console.Write($"Skriv in titeln på konsten: ");
                                        string title = Console.ReadLine();
                                        Console.Write("Skriv in en beskrivning av konsten: ");
                                        string description = Console.ReadLine();
                                        Console.Write("Skriv in namnet på konstnären: ");
                                        string artist = Console.ReadLine();

                                        room.AddContent(new Art(title, description, artist));
                                        Console.WriteLine("Konst tillagt i rum " + room.GetRoomNameString());
                                        
                                    }
                                    isRoomInMuseum = true;
                                }
                            }
                            if(!isRoomInMuseum) // om rummet inte finns i museumet
                            {
                                Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum."); 
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Du måste skriva ett rumsnamn också för att kunna lägga till konst i rätt rum!");
                Console.WriteLine("Testa igen! Eller skriv [mu help] för hjälp");
            }
        }
        // Ta bort ett konstverk från valt rum, logiken ser snarlik ut som metoden ovanför när man lägger till konst
        private void DeleteArtFromRoom(string roomName, string artPosition)
        {
            if (museumCollection.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumCollection.GetDictionary())
                {
                    if (museumCollection.GetVisitingMuseumName() == museum.Key)
                    {
                        bool isRoomInMuseum = false;
                        foreach (var room in museum.Value.GetList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                try
                                {
                                    room.DeleteContent(room.GetList()[Convert.ToInt32(artPosition) - 1]);
                                    Console.WriteLine($"Konstverket är nu borttaget!");
                                }
                                catch
                                {
                                    Console.WriteLine("Du måste skriva in vilken konstplats du vill ta bort i valt rum.");
                                    Console.WriteLine("Om konsten du vill ta bort finns på plats 1 i rummet. Skriv 1 efter rumsnamnet.");
                                }
                                isRoomInMuseum = true;
                            }
                        }
                        if(!isRoomInMuseum)
                        {
                            Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum.");
                        }
                    }
                }
            }
        }
        // Ta bort rum om inputen från användaren stämmer överens med ett rum och är tomt
        private void DeleteRoomFromMuseum(string roomName)
        {
            if (museumCollection.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumCollection.GetDictionary())
                {
                    if (museumCollection.GetVisitingMuseumName() == museum.Key)
                    {
                        bool isRoomInMuseum = false;
                        foreach (var room in museum.Value.GetList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                try
                                {
                                    museum.Value.DeleteContent(room);
                                    Console.WriteLine($"Rummet {room.GetRoomNameString()} är nu borttaget");
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine(ex.Message);
                                }
                                isRoomInMuseum = true;
                            }
                        }
                        if(!isRoomInMuseum)
                        {
                            Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum.");
                        }
                    }
                }
            }
        }
        // Skriver ut hjälpkommando till användaren
        public void WriteHelpCommands()
        {
            Console.WriteLine("Hjälp");
            Console.WriteLine("Kommandon:");
            Console.WriteLine("\n[mu select]");
            Console.WriteLine(" mu select [museum-name] # Väljer vilket museum du vill besöka");

            Console.WriteLine("\n[mu show]");
            Console.WriteLine(" mu show museums # Visar vilka museum som finns att besöka.");
            Console.WriteLine(" mu show rooms # Visar alla rum i museumet du befinner dig i.");
            Console.WriteLine(" mu show room [room-name] # Visar konstverken i valt rum.");

            Console.WriteLine("\n[mu add]");
            Console.WriteLine(" mu add museum [museum-name] # Lägger till ett nytt museum med ditt valda namn (namnet får ej innehålla mellanslag)."); // Fixa det här?
            Console.WriteLine(" mu add room [room-name] # Lägger till ett nytt rum i museumet du befinner dig i (namnet får ej innehålla mellanslag)."); // Fixa det här?
            Console.WriteLine(" mu add art [room-name] # Lägger till ett nytt konstverk i rummet du väljer, du får lägga till information om konstverket efter du har genomfört kommandot.");

            Console.WriteLine("\n[mu delete]");
            Console.WriteLine(" mu delete art [room-name] [art-place] # Du väljer vilket konstverk du vill ta bort på vilken plats i ett rum.");
            Console.WriteLine(" mu delete room [room-name] # Du väljer vilket rum du vill ta bort i museet. (Rummet måste vara tomt).");

            Console.WriteLine("\n[mu help]");
            Console.WriteLine(" mu help # Skriver ut en hjälplista med förklaring av kommandon.");
        }
    }
}