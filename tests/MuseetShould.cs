using System;
using Xunit;
using Museet.Models;

namespace tests
{
    public class MuseetShould
    {
        [Fact]
        public void AddNewArtToRoom()
        {
            // Arrange
            var room1 = new Room("Test");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");

            // Act
            room1.AddContent(artwork1);
            var expected = 1;

            // Assert
            Assert.Equal(expected, room1.GetRoomArtListCount());
        }
        [Fact]
        public void WriteOutAllArtsInMuseum()
        {
            // Arrange
            var museum = new Museum("Museum1");
            var room1 = new Room("Room1");
            var room2 = new Room("Room2");

            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("En katt bakom flötet", "Underbara katten", "Kattskrället");

            // Act
            room1.AddContent(artwork1);
            room2.AddContent(artwork2);
            museum.AddContent(room1);
            museum.AddContent(room2);

            var museumString = museum.GetRoomAndArtStrings();


            // Assert
            Assert.Contains("En bild som", museumString);
            Assert.Contains("Kattskrället", museumString);
        }
        [Fact]
        public void WriteOutAllArtsInRoom()
        {
            // Arrange
            var museum = new Museum("Museum1");
            var room1 = new Room("Room1");
            var room2 = new Room("Room2");

            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("En katt bakom flötet", "Underbara katten", "Kattskrället");

            // Act
            room1.AddContent(artwork1);
            room2.AddContent(artwork2);
            museum.AddContent(room1);
            museum.AddContent(room2);

            var roomString = museum.GetArtStringsFromRoom(room1);

            // Assert
            Assert.Contains("Lyret", roomString);
            
        }
                [Fact]
        public void DeleteArtFromRoom()
        {
            // Arrange
            var museum = new Museum("Museum1");
            var room1 = new Room("Room1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("En katt bakom flötet", "Underbara katten", "Kattskrället");

            // Act
            room1.AddContent(artwork1);
            room1.AddContent(artwork2);
            museum.AddContent(room1);

            Assert.Equal(2, room1.GetRoomArtListCount()); // Testar innan delete

            room1.DeleteContent(artwork1);

            int artCount = room1.GetRoomArtListCount();
            
            // Assert
            Assert.Equal(1, artCount); // Testar efter delete
            
        }
        [Fact]
        public void AddNewRoomInMuseum()
        {
            // Arrange
            var museum = new Museum("Museum1");
            // Act
            museum.AddContent(new Room("Room1"));
            museum.AddContent(new Room("Room2"));

            Assert.Equal(2, museum.GetRoomsListCount());
            
        }
        [Fact]
        public void DeleteRoomInMuseum()
        {
            // Arrange
            var museum = new Museum("Museum1");
            var room1 = new Room("Room1");
            // Act
            museum.AddContent(room1);
            museum.AddContent(new Room("Room2"));

            museum.DeleteContent(room1);

            Assert.Equal(1, museum.GetRoomsListCount());
        }

                        [Fact]
        public void AddMuseumToDictionary()
        {
            var MuseumStorage = new MuseumStorage();
            // Arrange
            var museum1 = new Museum("Museum1");
            var museum2 = new Museum("Museum2");
            
            // Act
            MuseumStorage.AddContent(museum1);
            MuseumStorage.AddContent(museum2);

            Assert.Equal(2, MuseumStorage.GetMuseumCount());
            
        }
        [Fact]
        public void AddOneArtToManyAndGetFail()
        {
            var room1 = new Room("Room1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("En katt bakom flötet", "Underbara katten", "Kattskrället");
            var artwork3 = new Art("KonstExempel", "Konstförklaring", "Konstförfattare");
            var artwork4 = new Art("KonstExempel2", "Konstförklaring2", "Konstförfattare2");

            room1.AddContent(artwork1);
            room1.AddContent(artwork2);
            room1.AddContent(artwork3);
            room1.AddContent(artwork4); //Har lagt till 4 konstvärk

            var roomCount = room1.GetRoomArtListCount(); 

            Assert.Equal(3, roomCount); //Roomcounten borde ändå vara 3 eftersom den inte kan lägga till 4
        }
        [Fact]
        public void CheckIfRoomIsFull()
        {
            var room1 = new Room("Room1");
            var artwork1 = new Art("En hund bakom ratten", "En bild som måste upplevas för att förstås", "Lyret");
            var artwork2 = new Art("En katt bakom flötet", "Underbara katten", "Kattskrället");
            var artwork3 = new Art("KonstExempel", "Konstförklaring", "Konstförfattare");

            room1.AddContent(artwork1);
            room1.AddContent(artwork2);
            room1.AddContent(artwork3);

            Assert.True(room1.isArtListFull()); //Roomcounten borde ändå vara 3 eftersom den inte kan lägga till 4
        }
    }
}
