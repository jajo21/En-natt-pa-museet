
using System.Collections.Generic;

namespace Museet.Models
{
	// TODO: Needs further work
   public class Art
	{
		string title;
		string description;
		string artist;
		public Art(string title, string description, string artist)
		{
			this.title = title;
			this.description = description;
			this.artist = artist;
		}
		public string GetArtInformationString() {
			return $"{this.title}, {this.description}, {this.artist}";
		}
	}
}