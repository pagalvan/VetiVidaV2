using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.Ents
{
    public class Especie : NamedEntity
    {
        public override string ToString()
        {
            return $"{Id};{Nombre}";
        }
        public string Serializar()
        {
            return $"{Id};{Nombre}";
        }
    }

}
