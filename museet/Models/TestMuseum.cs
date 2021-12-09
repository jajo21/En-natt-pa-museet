namespace Museet.Models
{
	// Testmuseum som är fritt fram att använda om man inte orkar lägga till alla testdelar själv. 
    // Har enbart gjort en konstruktor som lägger till alla delarna för enkelhetens skull.
   public class TestMuseum
	{
		public TestMuseum(MuseumCollection museumStorage)
		{
			var bilmuseum = new Museum("bilmuseum");
            var room1 = new Room("baksätet");
            var room2 = new Room("bakluckan");
            var room3 = new Room("motorhuven");
            var artwork1 = new Art("Hunden", "En hund bakom ratten", "Mercedes");
            var artwork2 = new Art("Katten", "En katt i baksätet", "Volvo");
            var artwork3 = new Art("Giraffen", "En giraff i takluckan", "Audi");
            var artwork4 = new Art("Råttan", "En råtta i avgasröret", "BMW");
            var artwork5 = new Art("Sengångaren", "En sengångare på gaspedalen", "Opel");
            var artwork6 = new Art("Sköldpaddan", "En sköldpadda på karossen", "Tesla");
            museumStorage.AddContent(bilmuseum);
            bilmuseum.AddContent(room1);
            bilmuseum.AddContent(room2);
            bilmuseum.AddContent(room3);
            room1.AddContent(artwork1);
            room1.AddContent(artwork2);
            room1.AddContent(artwork3);
            room2.AddContent(artwork4);
            room2.AddContent(artwork5);
            room3.AddContent(artwork6);
		}

	}
}