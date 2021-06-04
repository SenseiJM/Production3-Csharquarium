using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionCsharquarium {
    interface IPoisson {

        public string Nom { get; }
        public string Sexe { get; }
        public Aquarium Habitat { get; }
        public string RegimeAlimentaire { get; }

    }
}
