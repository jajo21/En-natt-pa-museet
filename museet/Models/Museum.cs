
using System;
using System.Collections.Generic;

namespace Museet.Models
{
	// TODO: Needs further work
   public class Museum
	{
        List<Room> museumRooms;
        string museumName;

        public Museum(string museumName) 
        {
            this.museumName = museumName;
            this.museumRooms = new List<Room>();
        }
        public void AddRoomToMuseum(Room room) {
            this.museumRooms.Add(room);
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
        public string GetArtStringsFromRoom(Room room)
        {
            string artString = "";
            foreach(var artRoom in this.museumRooms)
            {
                if(artRoom == room) {
                    artString += artRoom.GetAllArtInRoomString();
                }
            }
            return artString;
        }

        public int GetRoomsListCount()
        {
            return this.museumRooms.Count;
        }
        public void DeleteRoomInMuseum(Room roomToDelete)
        {
            if(roomToDelete.GetRoomArtListCount() < 1)
            {
               this.museumRooms.Remove(roomToDelete); 
            }
        }
        public string GetRoomName()
        {
            string roomName = "";
            foreach(var room in this.museumRooms)
            {
                roomName = $"{room.GetRoomNameString()}";
            }
            return roomName;
        }
    }
}