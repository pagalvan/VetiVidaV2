using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.Ents
{
    public class Veterinario : Persona
    {
        public string Especialidad { get; set; }
        public override string NombreCompleto()
        {
            return $"Dr: {Nombres} {Apellidos}";
        }

        public override string ToString()
        {
            return $"{Id};{Cedula};{Nombres};{Apellidos};{Telefono}";
        }
    }

}
