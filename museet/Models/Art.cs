namespace Museet.Models
{
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
		public string GetArtString() {
			return $"{this.title}, {this.description}, {this.artist}";
		}
	}
}