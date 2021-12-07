
using System.Collections.Generic;

namespace Museet.Models
{
	// TODO: Needs further work
   public class Art
	{
		/* int artId; */
		string title;
		string description;
		string artist;
		public Art(/* int artId,  */string title, string description, string artist)
		{
			/* this.artId = artId; */
			this.title = title;
			this.description = description;
			this.artist = artist;
		}
		public string GetArtInformationString() {
			return $"{this.title}, {this.description}, {this.artist}";
		}
	}
}