using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.Ents
{
    public class Propietario : Persona
    {
        public override string NombreCompleto()
        {
            return $"Sr: {Nombres} {Apellidos}";
        }

        public override string ToString()
        {
            return $"{Id};{Cedula};{Nombres};{Apellidos};{Telefono}";
        }
    }

}
