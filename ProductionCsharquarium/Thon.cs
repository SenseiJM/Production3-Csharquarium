using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCsharquarium {
    class Thon : Poisson, ICarnivore, IMonosexue {

        public Thon(int sexeAleatoire, Aquarium aquarium) : base() {
            if (sexeAleatoire == 0) {
                Sexe = "Femelle";
            } else {
                Sexe = "Mâle";
            }

            do {
                Console.WriteLine($"Veuillez entrer un nom à donner au nouveau poisson (Bar {Sexe}) : ");
                Nom = Console.ReadLine();
            } while (Nom == "");

            Habitat = aquarium;
            Nom = Habitat.FirstToUpper(Nom);
            RegimeAlimentaire = "Carnivore";
        }

        public Thon(string nom, int sexe, string race, Aquarium aquarium) : base() {
            if (sexe == 0) {
                Sexe = "Femelle";
            } else {
                Sexe = "Mâle";
            }

            Nom = nom;
            Habitat = aquarium;
            Race = race;
        }

        public void Manger(Poisson p) {
            Habitat.ListPoissons.Remove(p);
        }

        public void Manger() {
            Random random = new Random();
            int index = random.Next(Habitat.ListPoissons.Count);
            Poisson poisson = Habitat.ListPoissons[index];
            if (!(poisson is Thon)) {
                poisson.PerdreVie();
                PointsDeVie += 5;
            }
        }

        public override void Evoluer() {
            PointsDeVie--;
            if (PointsDeVie <= 5) {
                Manger();
            } else {
                SeReproduire();
            }
            Vieillir();
        }

        public void SeReproduire() {
            Random random = new Random();
            int index = random.Next(Habitat.ListPoissons.Count);
            Poisson poisson = Habitat.ListPoissons[index];
            if ((poisson is Thon) && (poisson.Sexe != this.Sexe)) {
                int sexeAleatoire = random.Next(1);
                Thon enfant = new Thon(sexeAleatoire, Habitat);
                Habitat.ListPoissons.Add(enfant);
            }
        }
    }
}
