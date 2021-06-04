using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCsharquarium {
    class Sole : Poisson, IHerbivore, IHermaphroditeOpportuniste {

        public Sole(int sexeAleatoire, Aquarium aquarium) : base() {
            if (sexeAleatoire == 0) {
                Sexe = "Femelle";
            } else {
                Sexe = "Mâle";
            }

            do {
                Console.WriteLine($"Veuillez entrer un nom à donner au nouveau poisson (Sole {Sexe}) : ");
                Nom = Console.ReadLine();
            } while (Nom == "");

            Habitat = aquarium;
            Nom = Habitat.FirstToUpper(Nom);
            RegimeAlimentaire = "Herbivore";

        }

        public Sole(string nom, int sexe, string race, Aquarium aquarium) : base() {
            if (sexe == 0) {
                Sexe = "Femelle";
            } else {
                Sexe = "Mâle";
            }

            Nom = nom;
            Habitat = aquarium;
            Race = race;
        }

        public void Manger(Algue a) {
            Habitat.ListAlgues.Remove(a);
        }

        public void Manger() {
            Random random = new Random();
            int index = random.Next(Habitat.ListAlgues.Count);
            Algue algue = Habitat.ListAlgues[index];
            algue.PerdreVie();
            PointsDeVie += 3;
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
            if ((poisson is Sole) && (poisson.Sexe != this.Sexe)) {
                int sexeAleatoire = random.Next(1);
                Sole enfant = new Sole(sexeAleatoire, Habitat);
                Habitat.ListPoissons.Add(enfant);
            } else if ((poisson is Sole) && (poisson.Sexe == this.Sexe)) {
                ChangerSexe();
                int sexeAleatoire = random.Next(1);
                Sole enfant = new Sole(sexeAleatoire, Habitat);
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
