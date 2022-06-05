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
        public void AddContent(Room roomToAdd)
        {
            this.museumRooms.Add(roomToAdd);
        }
        public void DeleteContent(Room roomToDelete)
        {
            if (roomToDelete.isRoomEmpty())
            {
                this.museumRooms.Remove(roomToDelete);
            }
            else throw new Exception("Rummet är inte tomt. Var god ta bort all konst innan du kan ta bort rummet.");
        }
        public string GetMuseumName()
        {
            return this.museumName;
        }
        public List<Room> GetList()
        {
            return museumRooms;
        }
        public string GetRoomAndArtStrings()
        {
            string roomString = "";
            foreach (var room in this.museumRooms)
            {
                roomString += $"\nRum: {room.GetRoomNameString()}\n{room.GetAllArtInRoomString()}";
            }
            return roomString;
        }
        public int GetListCount()
        {
            return this.museumRooms.Count;
        }
    }
}