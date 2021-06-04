using System;

namespace ProductionCsharquarium {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Bienvenue dans ce simulateur d'aquarium !");
            Console.Write("Veuillez entrer le nom de votre permier aquarium : ");
            string nomAquarium = Console.ReadLine();
            if (nomAquarium == "") {
                nomAquarium = "Aquarium1";
            }
            Console.Write("Veuillez maintenant entrer le nombre de poissons à mettre dans l'aquarium : ");
            bool nbPoissonsValide = int.TryParse(Console.ReadLine(), out int nbPoissons);

            while (nbPoissonsValide == false) {
                Console.WriteLine("Valeur Incorrecte. Veuillez introduire une valeur numérique.");
                Console.Write("Veuillez maintenant entrer le nombre de poissons à mettre dans l'aquarium : ");
                nbPoissonsValide = int.TryParse(Console.ReadLine(), out nbPoissons);
            }

            Console.Write("Veuillez maintenant entrer le nombre d'algues présentes dans l'aquarium : ");
            bool nbAlguesValide = int.TryParse(Console.ReadLine(), out int nbAlgues);

            while (nbAlguesValide == false) {
                Console.WriteLine("Valeur Incorrecte. Veuillez introduire une valeur numérique.");
                Console.Write("Veuillez maintenant entrer le nombre d'algues présentes dans l'aquarium : ");
                nbAlguesValide = int.TryParse(Console.ReadLine(), out nbAlgues);
            }

            Aquarium aquarium = new Aquarium(nomAquarium, nbPoissons, nbAlgues);
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
            aquarium.PasserLeTemps();
        }
    }
}
