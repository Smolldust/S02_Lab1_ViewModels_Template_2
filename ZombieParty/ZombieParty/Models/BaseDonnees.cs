using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ZombieParty.Models
{
    public class BaseDonnees
    {
        public List<ZombieType> ZombieTypes { get; set; }
        public List<Zombie> Zombies { get; set; }
        public List<Weapon> Weapons { get; set; }

        public BaseDonnees()
        {
            //Initialiser des listes vides
            Zombies = new List<Zombie>();
            ZombieTypes = new List<ZombieType>();
            Weapons = new List<Weapon>();

            {
                new ZombieType() { TypeName = "Virus", Id = 1 };
                new ZombieType() { TypeName = "Contact", Id = 2 };
                new ZombieType() { TypeName = "Radioactif", Id = 3 };
            }
            ;

            //Remplir la liste des Zombies
            Zombies.Add(new Zombie() { Name = "LeChuck", Point = 5, ZombieTypeId = 2 });
            Zombies.Add(new Zombie() { Name = "Lenore", Point = 4, ZombieTypeId = 2 });
            Zombies.Add(new Zombie() { Name = "Draugr", Point = 2, ZombieTypeId = 3 });
            Zombies.Add(new Zombie() { Name = "Ragamuffin", Point = 5, ZombieTypeId = 1 });
            Zombies.Add(new Zombie() { Name = "Taxidermy", Point = 1, ZombieTypeId = 2 });
            Zombies.Add(new Zombie() { Name = "Chien", Point = 7, ZombieTypeId = 1 });
            Zombies.Add(new Zombie() { Name = "Avogadro", Point = 9, ZombieTypeId = 3 });

            //Remplir la liste des Weapons
            Weapons.Add(new Weapon() { Name = "Leopold", Description = "This is to cut your friendly zombies", Force = 200, Image = "https://i.ibb.co/y5nCnXT/dagger-gfce31e967-1920.png", Price = 421, Qty = 21, QtyBought = 3, CreatedDate = new DateTime(1999, 01, 1) });
            Weapons.Add(new Weapon() { Name = "Master Shield", Description = "An awesome Stainless Steel Shield", Force = 10, Image = "https://publicdomainvectors.org/photos/Shield-ClassicMedieval1.png", Price = 500, Qty = 30, QtyBought = 1, CreatedDate = new DateTime(1999, 01, 1) });
        }



    }
}
