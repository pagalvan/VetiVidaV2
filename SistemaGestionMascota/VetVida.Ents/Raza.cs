using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.Ents
{
    public class Raza : NamedEntity
    {
        public Especie Especie { get; private set; }

        public void AsignarEspecie(Especie especie)
        {
            if (Especie == null)
            {
                Especie = especie;
            }
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Especie.Id}";
        }
    }

}
