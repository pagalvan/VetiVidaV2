using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.Ents
{
    public class Mascota : NamedEntity
    {
        public Propietario Propietario { get; set; }
        public int Edad { get; set; }
        public Raza Raza { get; set; }

        public List<Consulta> HistorialConsultas { get; set; }

        public Mascota()
        {
            HistorialConsultas = new List<Consulta>();
        }

        public void AgregarConsulta(Consulta consulta)
        {
            if (consulta != null)
            {
                consulta.Mascota = this;
                HistorialConsultas.Add(consulta);
            }
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Propietario.Id};{Edad};{Raza.Id}";
        }
    }
}

}
