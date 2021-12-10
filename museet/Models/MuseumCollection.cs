using System.Collections.Generic;

namespace Museet.Models
{
    // MuseumCollection är en klass som tar hand om lagringen av nyskapade museum i en dictionary och dess nödvändiga metoder.
    public class MuseumCollection
    {
        Dictionary<string, Museum> museumDictionary;
        string visiting;

        public MuseumCollection()
        {
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
            foreach (var museum in museumDictionary)
            {
                if (visiting == museum.Key)
                {
                    museumName += $"{museum.Key} [Du är här]\n";
                }
                else
                {
                    museumName += $"{museum.Key}\n";
                }
            }
            return museumName;
        }
        public void SetVisitingMuseum(string input)
        {
            foreach (var museum in museumDictionary)
            {
                if (museum.Key == input)
                {
                    this.visiting = input;
                }
            }
        }
        public string GetVisitingMuseumName()
        {
            return this.visiting;
        }
        public Dictionary<string, Museum> GetDictionary()
        {
            return museumDictionary;
        }
        public int GetDictionaryCount()
        {
            return museumDictionary.Count;
        }
    }
}