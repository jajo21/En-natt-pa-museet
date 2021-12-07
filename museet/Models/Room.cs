using System;
using System.Collections.Generic;

namespace Museet.Models
{
    // TODO: Needs further work
    public class Room
    {
        string roomName;
        List<Art> artList;
        public Room(string roomName)
        {
            this.roomName = roomName;
            this.artList = new List<Art>();
        }

        public string GetRoomNameString()
        {
            return this.roomName;
        }
        public bool isArtListEmpty()
        {
            if (artList.Count == 0)
            {
                return true;
            }
            else return false;
        }
        public void AddArtToRoom(Art artToAdd)
        {
            if (artList.Count < 3)
            {
                artList.Add(artToAdd);
            }
            //else throw new Exception ("To many paintings"); // ? Ska detta va här?
        }
        public void DeleteArtFromRoom(Art artToDelete)
        {
            artList.Remove(artToDelete);
        }
        public int GetRoomArtListCount()
        {
            return artList.Count;
        }
        public List<Art> GetArtList()
        {
            return artList;
        }
        public string GetAllArtInRoomString()
        {
            string artString = "";
            int count = 1;
            if (isArtListEmpty())
            {
                artString += "Rummet är tomt";
            }
            else
            {
                foreach (var art in artList)
                {
                    artString += $"{count}: {art.GetArtInformationString()}\n";
                    count++;
                }
            }

            return artString;
        }

    }
}
