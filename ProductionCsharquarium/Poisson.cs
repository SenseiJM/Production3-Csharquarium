using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCsharquarium {
    abstract class Poisson : IPoisson {

        public string Nom { get; set; }
        public string Sexe { get; set; }
        public Aquarium Habitat { get; set; }
        public string RegimeAlimentaire { get; set; }
        public string Race { get; set; }
        public ushort PointsDeVie { get; set; }
        public ushort Age { get; set; }

        public Poisson() {
            PointsDeVie = 10;
            Age = 0;
        }

        public void Mourir() {
            Habitat.ListPoissons.Remove(this);
        }

        public void PerdreVie() {
            PointsDeVie -= 4;
            if (PointsDeVie <= 0) {
                Mourir();
            }
        }

        public void Vieillir() {
            Age++;
            if (Age > 20) {
                Mourir();
            }
        }

        public abstract void Evoluer();
    }
}
