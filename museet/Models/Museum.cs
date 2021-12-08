
using System;
using System.Collections.Generic;

namespace Museet.Models
{
   public class Museum
	{
        List<Room> museumRooms;
        string museumName;

        public Museum(string museumName) 
        {
            this.museumName = museumName;
            this.museumRooms = new List<Room>();
        }
        public void AddContent(Room room) {
            this.museumRooms.Add(room);
        }
        public void DeleteContent(Room roomToDelete)
        {
            if(roomToDelete.isArtListEmpty())
            {
               this.museumRooms.Remove(roomToDelete); 
            }
            else throw new Exception ("Rummet är inte tomt. Var god ta bort all konst innan du kan ta bort rummet.");
        }
        public string GetMuseumName() {
            return this.museumName;
        }
        public List<Room> GetRoomList()
        {
            return museumRooms;
        }

        public string GetRoomAndArtStrings()
        {
            string roomString = "";
            foreach(var room in this.museumRooms) {
                roomString += $"\nRum: {room.GetRoomNameString()}\n{room.GetAllArtInRoomString()}";
            }
            return roomString;
        }        
        public int GetRoomsListCount()
        {
            return this.museumRooms.Count;
        }
    }
}