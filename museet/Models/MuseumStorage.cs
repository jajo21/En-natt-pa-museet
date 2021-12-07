
using System;
using System.Collections.Generic;

namespace Museet.Models
{
	// TODO: Needs further work
   public class MuseumStorage
	{
        Dictionary<string, Museum> museumDictionary;
        string visiting;

        public MuseumStorage() {
            museumDictionary = new Dictionary<string, Museum>();
            this.visiting = "";
        }
        public void AddMuseumToDictionary(Museum museum)
        {
            string museumName = museum.GetMuseumName();
            museumDictionary.Add(museumName, museum);
        } 

        public string GetAllMuseumNames()
        {
            string museumName = "";
            foreach(var museum in museumDictionary)
            {
               museumName += $"{museum.Key}\n";
            }
            return museumName;
        }
        public int GetMuseumCount(){
            return museumDictionary.Count;
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
    }
}