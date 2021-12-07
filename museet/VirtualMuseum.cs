using System;
using Museet.Models;
using Simulator;

namespace Museet
{
    internal class VirtualMuseumProgram : IApplication
    {
        MuseumStorage museumStorage;

        public VirtualMuseumProgram()
        {
            museumStorage = new MuseumStorage();
            var museum1 = new Museum("museum1");
            var museum2 = new Museum("museum2");
            var room1 = new Room("room1");
            var room2 = new Room("room2");
            var room3 = new Room("room3");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("En katt bakom flötet", "Underbara katten", "Kattskrället");
            var artwork3 = new Art("KonstTitel", "Konstbeskrivning", "Konstnär");
            var artwork4 = new Art("KonstTitel2", "Konstbeskrivning2", "Konstnär2");
            museumStorage.AddMuseumToDictionary(museum1);
            museumStorage.AddMuseumToDictionary(museum2);
            museum1.AddRoomToMuseum(room1);
            museum1.AddRoomToMuseum(room2);
            museum2.AddRoomToMuseum(room3);
            room1.AddArtToRoom(artwork1);
            room1.AddArtToRoom(artwork2);
            room2.AddArtToRoom(artwork3);
            room2.AddArtToRoom(artwork4);
            room3.AddArtToRoom(artwork3);
            room3.AddArtToRoom(artwork4);
        }

        public void Run(string verb, string[] options)
        {
            // FIXME: Continue with your program here
            //Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(',',options));

            switch (verb)
            {
                case "select":
                    if (options[0] == "show")
                    {
                        Console.WriteLine("\nDet här är museumen du kan välja mellan:");
                        Console.WriteLine(museumStorage.GetAllMuseumNames());
                    }
                    else
                    {
                        SelectMuseum(options[0]);
                    }
                    break;
                case "show":
                    if (options[0] == "museum")
                    {
                        ShowSelectedMuseum();
                    }
                    else if (options[0] == "room")
                    {
                        ShowArtInSelectedRoom(options[1]);
                    }
                    break;
                case "add":
                    if (options[0] == "museum")
                    {
                        AddNewMuseum(options[1]);
                    }
                    else if (options[0] == "room")
                    {
                        AddNewRoom(options[1]);
                    }
                    else if (options[0] == "art")
                    {
                        AddNewArt(options[1]);
                    }
                    break;
                case "delete":
                    if (options[0] == "art")
                    {
                        DeleteArtFromRoom(options[1], options[2]);
                    }
                    else if (options[0] == "room")
                    {
                        DeleteRoomFromMuseum(options[1]);
                    }
                    break;
                case "help":
                    WriteHelpCommands();
                    break;
                default:
                    // Show the help menu when the verb was unrecognized
                    System.Console.WriteLine("Unkown command!");
                    WriteHelpCommands();
                    break;
            }
        }
        public void SelectMuseum(string museumChoice)
        {
            foreach (var museum in museumStorage.GetMuseumDictionary())
            {
                if (museumChoice == museum.Key)
                {
                    museumStorage.SetVisitingMuseum(museumChoice);
                    Console.WriteLine($"Du är nu på museumet {museumChoice}!");
                }
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
                        foreach (var room in museum.Value.GetRoomList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                Console.WriteLine($"I rummet {room.GetRoomNameString()} finns följande konst: \n{room.GetAllArtInRoomString()}");
                            }
                        }
                    }
                }
            }
        }
        public void AddNewMuseum(string museumName)
        {
            if (museumName.Length > 0)
            {
                museumStorage.AddMuseumToDictionary(new Museum(museumName));
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
                            museum.Value.AddRoomToMuseum(new Room(roomName));
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
                            foreach (var room in museum.Value.GetRoomList())
                            {
                                if (roomName == room.GetRoomNameString()) // OM RUMMET ÄR FULLT SKRIV RUMMET ÄR FULLT
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

                                        room.AddArtToRoom(new Art(title, description, artist));
                                        Console.WriteLine("Konst tillagt i rum " + room.GetRoomNameString());
                                    }
                                }
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
                        foreach (var room in museum.Value.GetRoomList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                try
                                {
                                    room.GetArtList().Remove(room.GetArtList()[Convert.ToInt32(artPosition) - 1]); 
                                    Console.WriteLine($"Konstverket är nu borttaget!");
                                }
                                catch
                                {
                                    Console.WriteLine("Du måste skriva in vilken konstplats du vill ta bort i valt rum.");
                                    Console.WriteLine("Om konsten du vill ta bort finns på plats 1 i rummet. Skriv 1 efter rumsnamnet");
                                }
                            }
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
                        foreach (var room in museum.Value.GetRoomList())
                        {
                            if (roomName == room.GetRoomNameString())
                            {
                                if (room.isArtListEmpty())
                                {
                                    museum.Value.GetRoomList().Remove(room);
                                    Console.WriteLine($"Rummet {room.GetRoomNameString()} är nu borttaget");
                                }
                                else
                                {
                                    Console.WriteLine("Rummet är inte tomt. Var god ta bort all konst innan du kan ta bort rummet.");
                                }
                            }
                        }
                    }
                }
            }
        }
        public void WriteHelpCommands()
        {
            System.Console.WriteLine("Hjälp");
            System.Console.WriteLine("Kommandon:");
            System.Console.WriteLine(" mu museum [name] # Väljer vilket museum du vill besöka");
            System.Console.WriteLine(" mu add [example] [name] # Du lägger till vad art,room eller museum");
            System.Console.WriteLine(" mu delete [example] [name] # Du väljer vad du vill ta bort");
            System.Console.WriteLine(" mu show museum # Visar alla museum som finns i systemet");
        }
    }
}