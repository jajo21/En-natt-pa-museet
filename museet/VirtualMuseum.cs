using System;
using Museet.Models;
using Simulator;

namespace Museet
{
    internal class VirtualMuseumProgram : IApplication
    {
        MuseumStorage museumStorage;
        TestMuseum testMuseum; 

        public VirtualMuseumProgram()
        {
            museumStorage = new MuseumStorage();
            testMuseum = new TestMuseum(museumStorage); // Frivillig att använda, lägger till ett testmuseum.
        }

        public void Run(string verb, string[] options)
        {
            // FIXME: Continue with your program here
            //Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(',',options));

            switch (verb)
            {
                case "select":
                    if(options.Length == 0)
                    {
                        System.Console.WriteLine("[MU] Inget museum valt. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if(!museumStorage.GetMuseumDictionary().ContainsKey(options[0])) //Går ej att göra såhär.. Får lösas på annat sätt
                    {
                        Console.WriteLine("Museumet finns inte, skriv [mu show museums] för att se vilka museum som finns tillgängliga.");
                        Console.WriteLine("Eller skriv [mu help] för att se överiga kommandon.");
                    }
                    else 
                    {
                         SelectMuseum(options[0]); // mu select [museum-namn], för att ta sig in i valt museum
                    }
                    break;
                case "show":
                    if(options.Length == 0)
                    {
                        System.Console.WriteLine("[MU] Inget av de existerande kommandona för att visa museer, rum eller konstverk är valda. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if (options[0] == "rooms")
                    {
                        ShowSelectedMuseum(); // mu show rooms, för att vissa alla rum i det museumet man är i för stunden
                    }
                    else if (options[0] == "room")
                    {
                        ShowArtInSelectedRoom(options[1]); // mu show room [rums-namn], för att visa konstverk i rummet.
                    }
                    else if (options[0] == "museums")
                    {
                        Console.WriteLine($"Det här är de museer du kan välja mellan:");
                        Console.WriteLine(museumStorage.GetAllMuseumNames()); // mu show museums, för att visa alla tillgängliga museum.
                    }
                    else
                    {
                        Console.WriteLine("Okänt kommando, skriv [mu help] för att se tillgänliga kommandon.");
                    }
                    break;
                case "add":
                    if(options.Length == 0)
                    {
                        System.Console.WriteLine("[MU] Inget av de existerande kommandona för att lägga till museum, rum eller konstverk är valda. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if (options[0] == "museum")
                    {
                        AddNewMuseum(options[1]); // mu add museum [museum-namn], för att lägga till ett nytt museum
                    }
                    else if (options[0] == "room")
                    {
                        AddNewRoom(options[1]); // mu add room [room-name], för att lägga till ett nytt rum i nuvarande museum
                    }
                    else if (options[0] == "art")
                    {
                        AddNewArt(options[1]); // mu add art [room-name], för att ta användaren in i en metod där du får lägga till info om konsten
                    }
                    else 
                    {
                        Console.WriteLine("Okänt kommando, skriv [mu help] för att se tillgänliga kommandon.");
                    }
                    break;
                case "delete":
                    if(options.Length == 0)
                    {
                        System.Console.WriteLine("[MU] Inget av de existerande kommandona för att ta bort rum eller konstverk är valda. Skriv [mu help] för hjälp!");
                        throw new Exception("Mu error!");
                    }
                    else if (options[0] == "art")
                    {
                        DeleteArtFromRoom(options[1], options[2]); // mu delete art [room-name] [art-place], för att ta bort konst på vald plats i rummet
                    }
                    else if (options[0] == "room")
                    {
                        DeleteRoomFromMuseum(options[1]); // mu delete room [room-name], för att ta bort rum från museet, rummet måste vara tomt 
                    }
                    else
                    {
                        Console.WriteLine("Okänt kommando, skriv [mu help] för att se tillgänliga kommandon.");
                    }
                    break;
                case "help":
                    WriteHelpCommands(); // mu help, få en lista med kommandon som kan användas
                    break;
                default:
                    System.Console.WriteLine("Okänt kommando!");
                    WriteHelpCommands();
                    break;
            }
        }
        public void SelectMuseum(string museumChoice)
        {
            if (museumChoice == museumStorage.GetMuseumDictionary()[museumChoice].GetMuseumName())
            {
                museumStorage.SetVisitingMuseum(museumChoice);
                Console.WriteLine($"Du är nu på museumet {museumChoice}!");
            }
        }
        private void ShowSelectedMuseum()
        {
            if (museumStorage.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumStorage.GetMuseumDictionary())
                {
                    if (museumStorage.GetVisitingMuseumName() == museum.Key)
                    {
                        Console.WriteLine($"Museum: {museum.Key}");
                        Console.WriteLine("Konstverken presenteras i denna ordning -- titel, beskrivning, konstnär --");
                        Console.WriteLine($"{museum.Value.GetRoomAndArtStrings()}");
                    }
                }
            }
        }
        private void ShowArtInSelectedRoom(string roomName)
        {
            if (museumStorage.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumStorage.GetMuseumDictionary())
                {
                    if (museumStorage.GetVisitingMuseumName() == museum.Key)
                    {
                        bool roomIsInMuseum = false;
                        foreach (var room in museum.Value.GetRoomList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                Console.WriteLine($"I rummet {room.GetRoomNameString()} finns följande konst: \n{room.GetAllArtInRoomString()}");
                                roomIsInMuseum = true;
                            }
                        }
                        if(!roomIsInMuseum) 
                        {
                            Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum.");
                        }
                    }
                }
            }
        }
        public void AddNewMuseum(string museumName)
        {
            if (museumName.Length > 0)
            {
                museumStorage.AddContent(new Museum(museumName));
                Console.WriteLine($"Museum {museumName} tillagt!");
            }
            else
            {
                Console.WriteLine("Du måste skriva minst ett tecken för att skapa ett nytt museum!");
                Console.WriteLine("Testa igen!");
            }
        }
        public void AddNewRoom(string roomName)
        {
            if (roomName.Length > 0)
            {
                if (museumStorage.GetVisitingMuseumName() == "")
                {
                    Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [namn] eller skriv mu help för hjälp!");
                }
                else
                {
                    foreach (var museum in museumStorage.GetMuseumDictionary())
                    {
                        if (museumStorage.GetVisitingMuseumName() == museum.Key)
                        {
                            museum.Value.AddContent(new Room(roomName));
                        }
                    }
                    Console.WriteLine($"Rum {roomName} tillagt i museum {museumStorage.GetVisitingMuseumName()}");
                }
            }
            else
            {
                Console.WriteLine("Du måste skriva minst ett tecken för att skapa ett nytt rum!");
                Console.WriteLine("Testa igen!");
            }
        }
        private void AddNewArt(string roomName)
        {
            if (roomName.Length > 0)
            {
                if (museumStorage.GetVisitingMuseumName() == "")
                {
                    Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [namn] eller skriv mu help för hjälp!");
                }
                else
                {
                    foreach (var museum in museumStorage.GetMuseumDictionary())
                    {
                        if (museumStorage.GetVisitingMuseumName() == museum.Key)
                        {
                            bool roomIsInMuseum = false;
                            foreach (var room in museum.Value.GetRoomList())
                            {
                                
                                if (roomName == room.GetRoomNameString())
                                {
                                    if (room.isArtListFull())
                                    {
                                        Console.WriteLine("Rummet är tyvärr fullt. Testa att fylla på ett annat rum!");
                                    }
                                    else
                                    {
                                        Console.Write($"Skriv in titeln på konsten: ");
                                        string title = Console.ReadLine();
                                        Console.Write("Skriv in en beskrivning av konsten: ");
                                        string description = Console.ReadLine();
                                        Console.Write("Skriv in namnet på konstnären: ");
                                        string artist = Console.ReadLine();

                                        room.AddContent(new Art(title, description, artist));
                                        Console.WriteLine("Konst tillagt i rum " + room.GetRoomNameString());
                                        roomIsInMuseum = true;
                                    }
                                }
                            }
                            if(!roomIsInMuseum)
                            {
                                Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum."); 
                            }
                        }
                    }
                }
            }
        }
        private void DeleteArtFromRoom(string roomName, string artPosition)
        {
            if (museumStorage.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumStorage.GetMuseumDictionary())
                {
                    if (museumStorage.GetVisitingMuseumName() == museum.Key)
                    {
                        bool roomIsInMuseum = false;
                        foreach (var room in museum.Value.GetRoomList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                try
                                {
                                    room.DeleteContent(room.GetArtList()[Convert.ToInt32(artPosition) - 1]);
                                    Console.WriteLine($"Konstverket är nu borttaget!");
                                    roomIsInMuseum = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Du måste skriva in vilken konstplats du vill ta bort i valt rum.");
                                    Console.WriteLine("Om konsten du vill ta bort finns på plats 1 i rummet. Skriv 1 efter rumsnamnet.");
                                }
                            }
                        }
                        if(!roomIsInMuseum)
                        {
                            Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum.");
                        }
                    }
                }
            }
        }
        private void DeleteRoomFromMuseum(string roomName)
        {
            if (museumStorage.GetVisitingMuseumName() == "")
            {
                Console.WriteLine("Du är inte inne på något museum vänligen skriv mu select [museum-namn] eller skriv mu help för hjälp!");
            }
            else
            {
                foreach (var museum in museumStorage.GetMuseumDictionary())
                {
                    if (museumStorage.GetVisitingMuseumName() == museum.Key)
                    {
                        bool roomIsInMuseum = false;
                        foreach (var room in museum.Value.GetRoomList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                try
                                {
                                    museum.Value.DeleteContent(room);
                                    Console.WriteLine($"Rummet {room.GetRoomNameString()} är nu borttaget");
                                    roomIsInMuseum = true;
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        if(!roomIsInMuseum)
                        {
                            Console.WriteLine("Rummet finns tyvärr inte i det här museet, var god försök med ett annat rum.");
                        }
                    }
                }
            }
        }
        public void WriteHelpCommands()
        {
            System.Console.WriteLine("Hjälp");
            System.Console.WriteLine("Kommandon:");
            System.Console.WriteLine("\n[select]");
            System.Console.WriteLine(" mu select [museum-name] # Väljer vilket museum du vill besöka");

            System.Console.WriteLine("\n[show]");
            System.Console.WriteLine(" mu show museums # Visar vilka museum som finns att besöka.");
            System.Console.WriteLine(" mu show rooms # Visar alla rum i museumet du befinner dig i.");
            System.Console.WriteLine(" mu show room [room-name] # Visar konstverken i valt rum.");

            System.Console.WriteLine("\n[add]");
            System.Console.WriteLine(" mu add museum [museum-name] # Lägger till ett nytt museum med ditt valda namn (namnet får ej innehålla mellanslag)."); // Fixa det här?
            System.Console.WriteLine(" mu add room [room-name] # Lägger till ett nytt rum i museumet du befinner dig i (namnet får ej innehålla mellanslag)."); // Fixa det här?
            System.Console.WriteLine(" mu add art [room-name] # Lägger till ett nytt konstverk i rummet du väljer, du får lägga till information om konstverket efter du har genomfört kommandot.");

            System.Console.WriteLine("\n[delete]");
            System.Console.WriteLine(" mu delete art [room-name] [art-place] # Du väljer vilket konstverk du vill ta bort på vilken plats i ett rum.");
            System.Console.WriteLine(" mu delete room [room-name] # Du väljer vilket rum du vill ta bort i museet. (Rummet måste vara tomt).");

            System.Console.WriteLine("\n[help]");
            System.Console.WriteLine(" mu help # Skriver ut en hjälplista.");
        }
    }
}