using Speedrun.Models;

namespace Speedrun.Data
{
    public class Seeder
    {
        public static void Seed(Context context)
        {
            if (context.Tari.Any() || context.Orase.Any()) return;

            var tari = new Tara[]
            {
                new Tara {Denumire="România", Continent="Europa"},
                new Tara {Denumire="Moldova", Continent="Europa"},
                new Tara {Denumire="China", Continent="Asia"},
            };
            context.Tari.AddRange(tari);
            context.SaveChanges();

            var orase = new Oras[]
            {
                new Oras {Denumire="București", NumarulLocuitori=12345, CodTara=1},
                new Oras {Denumire="Chișinău", NumarulLocuitori=4321, CodTara=2},
                new Oras {Denumire="Beijing", NumarulLocuitori=99999, CodTara=3},
            };
            context.Orase.AddRange(orase);
            context.SaveChanges();
        }
    }
}
