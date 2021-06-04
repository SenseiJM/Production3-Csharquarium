namespace ProductionCsharquarium {
    class Algue {

        public ushort PointsDeVie { get; set; }
        public Aquarium Habitat { get; set; }
        public ushort Age { get; set; }

        public Algue() {
            PointsDeVie = 10;
            Age = 0;
        }

        public Algue(ushort PVParent) {
            PointsDeVie = PVParent;
            Age = 0;
        }

        public void Mourir() {
            Habitat.ListAlgues.Remove(this);
        }

        public void Grandir() {
            PointsDeVie += 1;
            Vieillir();
        }

        public void PerdreVie() {
            PointsDeVie -= 2;
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

        public void SeReproduire() {
            PointsDeVie = (ushort)(PointsDeVie / 2);
            ushort PointsDeVieParent = PointsDeVie;
            Algue enfant = new Algue(PointsDeVieParent);
            Habitat.ListAlgues.Add(enfant);
        }

    }
}