using System;
using Xunit;
using Museet.Models;

namespace tests
{
    public class MuseumTest
    {
        [Fact]
        public void AddNewArtToRoom() // Visar att det går att addera konst till rum
        {
            var room1 = new Room("Test");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");

            room1.AddContent(artwork1);
            var expected = 1;

            Assert.Equal(expected, room1.GetListCount());
        }
        [Fact]
        public void WriteOutAllArtsInMuseum() // Visar at det går att skriva ut allt innehåll i valt museum
        {
            var museum = new Museum("museum1");
            var room1 = new Room("testroom1");
            var room2 = new Room("testroom2");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("testtitel", "testbeskrivning", "testkonstnär");

            room1.AddContent(artwork1);
            room2.AddContent(artwork2);
            museum.AddContent(room1);
            museum.AddContent(room2);

            var museumString = museum.GetRoomAndArtStrings();

            Assert.Contains("En bild som", museumString);
            Assert.Contains("testkonstnär", museumString);
        }
        
        [Fact]
        public void DeleteArtFromRoom() // Kollar att det går att ta bort saker från rum
        {
            var museum = new Museum("museum1");
            var room1 = new Room("testroom1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("testtitel", "testbeskrivning", "testkonstnär");

            room1.AddContent(artwork1);
            room1.AddContent(artwork2); // Adderar 2 stycken konstverk till room1
            museum.AddContent(room1);
            room1.DeleteContent(artwork1); // Tar bort 1 konstverk från room1
            
            int artCount = museum.GetList()[0].GetListCount(); // Kollar i rätt rum i museet hur många konstverk som ligger i listan
            
            Assert.Equal(1, artCount); // Resultatet bör vara 1 konstverk kvar i konstverkslistan
        }
        [Fact]
        public void AddNewRoomToMuseum() // Testar metoden för att lägga till nytt rum till museet
        {
            var museum = new Museum("museum1");

            museum.AddContent(new Room("testroom1"));
            museum.AddContent(new Room("testroom2"));

            Assert.Equal(2, museum.GetListCount());
        }
        [Fact]
        public void DeleteRoomInMuseum() // Testar metoden som tar bort rum från museet
        {
            var museum = new Museum("museum1");
            var room1 = new Room("testroom1");
            var room2 = new Room("testroom2");

            museum.AddContent(room1);
            museum.AddContent(room2);
            museum.DeleteContent(room1);

            Assert.Equal(1, museum.GetListCount());
        }

        [Fact]
        public void AddMuseumToDictionary() //Kollar att det går att lägga till nya och olika museum i MuseumStorage Dicionary
        {
            var museumCollection = new MuseumCollection();
            var museum1 = new Museum("museum1");
            var museum2 = new Museum("museum2");
            
            museumCollection.AddContent(museum1);
            museumCollection.AddContent(museum2);

            Assert.Equal(2, museumCollection.GetDictionaryCount()); // Kollar att summan i dictionaryn stämmer
            Assert.Equal("museum2", museumCollection.GetDictionary()["museum2"].GetMuseumName()); // Kollar att rätt museum finns där
        }
        [Fact]
        public void ShouldNotBeAbleToAddMoreThanThreeArtsToRoom() // Kollar att man verkligen inte kan lägga till mer än 3 konstverk i rummen
        {
            var room1 = new Room("Room1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("testtitel", "testbeskrivning", "testkonstnär");
            var artwork3 = new Art("testtitel3", "testbeskrivning3", "testkonstnär3");
            var artwork4 = new Art("testtitel4", "testbeskrivning4", "testkonstnär4");

            room1.AddContent(artwork1);
            room1.AddContent(artwork2);
            room1.AddContent(artwork3);
            room1.AddContent(artwork4); //Har lagt till 4 konstverk

            var roomCount = room1.GetListCount(); 

            Assert.Equal(3, roomCount); //Roomcounten borde ändå vara 3 eftersom den inte kan lägga till 4
        }
        [Fact]
        public void CheckIfRoomIsFull() // Kollar att metoden registrerar att ett rum är fullt
        {
            var room1 = new Room("testroom1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("testtitel", "testbeskrivning", "testkonstnär");
            var artwork3 = new Art("testtitel3", "testbeskrivning3", "testkonstnär3");

            room1.AddContent(artwork1);
            room1.AddContent(artwork2);
            room1.AddContent(artwork3);
            bool trueIfRoomIsFull = room1.isRoomFull();

            Assert.True(trueIfRoomIsFull); // Om testet går igenom visar metoden att rummet är fullt
        }
        [Fact]
        public void CheckIfRoomIsEmpty() // Kollar metoden som kontrollerar om ett rum är tomt
        {
            var room1 = new Room("testroom1");

            bool trueIfRoomIsEmpty = room1.isRoomEmpty();

            Assert.True(trueIfRoomIsEmpty);
        }
        [Fact]
        public void ShouldNotBeAbleToDeleteRoomWithArtInIt() // Kollar att metoden som tar bort rum kastar en Exception om rummet inte är tomt
        {
            var museum1 = new Museum("museum1");
            var room1 = new Room("testroom1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            museum1.AddContent(room1);
            room1.AddContent(artwork1);
            
            Assert.Throws<Exception>(() => museum1.DeleteContent(room1)); 
            // När koden för att ta bort rummet körs bör en Exception throwas och rummet kommer inte tas bort, är denna true stämmer utfallet
        }
        
    }
}
