
using System;
using System.Collections.Generic;

namespace Museet.Models
{
   public class MuseumStorage
	{
        Dictionary<string, Museum> museumDictionary;
        string visiting;

        public MuseumStorage() {
            museumDictionary = new Dictionary<string, Museum>();
            this.visiting = "";
        }
        public void AddContent(Museum museum)
        {
            string museumName = museum.GetMuseumName();
            museumDictionary.Add(museumName, museum);
        } 
        public string GetAllMuseumNames()
        {
            string museumName = "";
            foreach(var museum in museumDictionary)
            {
                if(visiting == museum.Key) {
                    museumName += $"{museum.Key} [Du är här]\n";
                }
                else {
                   museumName += $"{museum.Key}\n"; 
                }
            }
            return museumName;
        }
        public void SetVisitingMuseum(string input) {
            foreach(var museum in museumDictionary)
            {
              if(museum.Key == input) 
              {
                  this.visiting = input;
              }
            }
        }
        public string GetVisitingMuseumName(){
            return this.visiting;
        }
        public Dictionary<string, Museum> GetMuseumDictionary () 
        {
            return museumDictionary;
        }
        public int GetMuseumCount() {
            return museumDictionary.Count;
        }
    }
}