using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCsharquarium {
    class Merou : Poisson, ICarnivore, IHermaphroditeAge {

        public Merou(int sexeAleatoire, Aquarium aquarium) : base() {
            if (sexeAleatoire == 0) {
                Sexe = "Femelle";
            } else {
                Sexe = "Mâle";
            }

            do {
                Console.WriteLine($"Veuillez entrer un nom à donner au nouveau poisson (Merou {Sexe}) : ");
                Nom = Console.ReadLine();
            } while (Nom == "");

            Habitat = aquarium;
            Nom = Habitat.FirstToUpper(Nom);
            RegimeAlimentaire = "Carnivore";
        }

        public Merou(string nom, int sexe, string race, Aquarium aquarium) : base() {
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
            if (!(poisson is Merou)) {
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

            if (Age == 10) {
                ChangerSexe();
            }

            Vieillir();
        }

        public void SeReproduire() {
            Random random = new Random();
            int index = random.Next(Habitat.ListPoissons.Count);
            Poisson poisson = Habitat.ListPoissons[index];
            if ((poisson is Merou) && (poisson.Sexe != this.Sexe)) {
                int sexeAleatoire = random.Next(1);
                Merou enfant = new Merou(sexeAleatoire, Habitat);
                Habitat.ListPoissons.Add(enfant);
            }
        }

        public void ChangerSexe() {
            if (Sexe == "Femelle") {
                Sexe = "Mâle";
            } else {
                Sexe = "Femelle";
            }
        }
    }
}
