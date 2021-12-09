using System.Collections.Generic;

namespace Museet.Models
{
    // Klassen Room innehåller ett rumsnamn och en lista på konst som finns i rummet
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
            if (!isArtListFull())
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
        public int GetArtListCount()
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
                artString += "-- Rummet är tomt -- \n";
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
