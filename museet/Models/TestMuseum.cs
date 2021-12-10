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
            museumStorage.AddContent(bilmuseum);
            bilmuseum.AddContent(room1);
            bilmuseum.AddContent(room2);
            bilmuseum.AddContent(room3);
            room1.AddContent(new Art("Hunden", "En hund bakom ratten", "Mercedes"));
            room1.AddContent(new Art("Katten", "En katt i baksätet", "Volvo"));
            room1.AddContent(new Art("Giraffen", "En giraff i takluckan", "Audi"));
            room2.AddContent(new Art("Råttan", "En råtta i avgasröret", "BMW"));
            room2.AddContent(new Art("Sengångaren", "En sengångare på gaspedalen", "Opel"));
            room3.AddContent(new Art("Sköldpaddan", "En sköldpadda på karossen", "Tesla"));
        }

    }
}