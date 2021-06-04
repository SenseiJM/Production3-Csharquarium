using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCsharquarium {
    class Aquarium {

        public uint NbPoissons { get; private set; }
        public uint NbAlgues { get; private set; }
        public List<Poisson> ListPoissons { get; private set; }
        public List<Algue> ListAlgues { get; private set; }

        public string NomAquarium { get; private set; }

        public Aquarium(string nom, int nbPoissons, int nbAlgues) {
            NomAquarium = nom;
            ListPoissons = new List<Poisson>();

            for (int i = 0; i < nbPoissons; i++) {

                string nomPoisson;

                do {
                    Console.WriteLine($"Veuillez entrer le nom du {i+1}e poisson : ");
                    nomPoisson = Console.ReadLine();
                } while (nomPoisson == null || nomPoisson == "");

                nomPoisson = FirstToUpper(nomPoisson);

                int sexe = -1;
                do {
                    Console.WriteLine("Veuillez entrer le sexe du poisson (1 pour Mâle | 0 pour Femelle) : ");
                    int.TryParse(Console.ReadLine(), out sexe);
                } while (sexe != 0 && sexe != 1);

                string race;
                string regimeAlimentaire = "";

                do {

                    Console.WriteLine("Veuillez entrer la race du poisson parmi les races suivantes : ");
                    Console.WriteLine("HERBIVORES\n\t1.Sole\n\t2.Bar\n\t3.Carpe\nCARNIVORES\n\t4.Mérou\n\t5.Thon\n\t6.Poisson-Clown");
                    race = Console.ReadLine();

                    switch (race) {
                        case "Sole":
                            regimeAlimentaire = "Herbivore";
                            Sole s = new Sole(nomPoisson, sexe, race, this);
                            AjouterPoisson(s);
                            break;
                        case "Bar":
                            regimeAlimentaire = "Herbivore";
                            Bar b = new Bar(nomPoisson, sexe, race, this);
                            AjouterPoisson(b);
                            break;
                        case "Carpe":
                            regimeAlimentaire = "Herbivore";
                            Carpe c = new Carpe(nomPoisson, sexe, race, this);
                            AjouterPoisson(c);
                            break;
                        case "Mérou":
                            regimeAlimentaire = "Carnivore";
                            Merou m = new Merou(nomPoisson, sexe, race, this);
                            AjouterPoisson(m);
                            break;
                        case "Thon":
                            regimeAlimentaire = "Carnivore";
                            Thon t = new Thon(nomPoisson, sexe, race, this);
                            AjouterPoisson(t);
                            break;
                        case "Poisson-Clown":
                            regimeAlimentaire = "Herbivore";
                            PoissonClown pc = new PoissonClown(nomPoisson, sexe, race, this);
                            AjouterPoisson(pc);
                            break;
                        default:
                            Console.WriteLine("Entrée invalide. Veuillez réessayer... Attention à bien écrire la race !");
                            race = "";
                            break;
                    }

                } while (race == null || race == "");

            }

            ListAlgues = new List<Algue>();
            for (int i = 0; i < nbAlgues; i++) {
                Algue algue = new Algue();
                AjouterAlgue(algue);
            }
        }

        public void AjouterPoisson(Poisson poisson) {
            ListPoissons.Add(poisson);
            poisson.Habitat = this;
        }

        public void AjouterAlgue(Algue algue) {
            ListAlgues.Add(algue);
            algue.Habitat = this;
        }

        public void PasserLeTemps() {
            //int tour = 1; mettre à l'extérieur de la méthode
            Console.WriteLine($"Début du tour {tour}");
            NbAlgues = (uint)ListAlgues.Count;
            NbPoissons = (uint)ListPoissons.Count;

            foreach (Algue algue in ListAlgues) {
                algue.Grandir();
            }


            Console.WriteLine($"Nombre d'algues dans l'aquarium : {NbAlgues}");
            Console.WriteLine($"Nombre de poissons dans l'aquarium : {NbPoissons}");

            for (int i = 0; i < NbPoissons; i++) {
                Poisson p = ListPoissons[i];
                p.Evoluer();
                Console.WriteLine($"Poisson n.{i+1} : {p.Nom} ({p.Race} {p.Sexe}) - {p.PointsDeVie}PV");
            }

            //Boucle résumé foreach poisson dans liste --> c.write(($"Poisson n.{i+1} : {p.Nom} ({p.Race} {p.Sexe}) - {p.PointsDeVie}PV");

            if (ListAlgues.Count == 0) {
                Algue algue = new Algue();
                AjouterAlgue(algue);
            }

            NbAlgues = (uint)ListAlgues.Count;
            NbPoissons = (uint)ListPoissons.Count;

            tour++;

        }

        public string FirstToUpper(string message) {
            char[] firstLetter = message.ToCharArray();
            firstLetter[0] = char.ToUpper(firstLetter[0]);
            string result = new string(firstLetter);
            return result;
        }
    }
}
