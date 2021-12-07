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
        public void AddContent(Art artToAdd)
        {
            if (artList.Count < 3)
            {
                artList.Add(artToAdd);
            }
        }
        public void DeleteContent(Art artToDelete)
        {
            artList.Remove(artToDelete);
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
		public bool isArtListFull()
		{
			if (artList.Count == 3)
            {
                return true;
            }
            else return false;
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
