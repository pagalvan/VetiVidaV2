using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.Ents
{
    public class HistorialMedico : BaseEntity
    {
        public Mascota Mascota { get; set; }
        public int MascotaId { get; set; }
        public List<Consulta> Consultas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Observaciones { get; set; }

        public HistorialMedico()
        {
            Consultas = new List<Consulta>();
            FechaCreacion = DateTime.Now;
        }

        public HistorialMedico(int id, int mascotaId, string observaciones)
        {
            Id = id;
            MascotaId = mascotaId;
            Observaciones = observaciones;
            Consultas = new List<Consulta>();
            FechaCreacion = DateTime.Now;
        }

        public void AgregarConsulta(Consulta consulta)
        {
            if (consulta != null)
            {
                Consultas.Add(consulta);
            }
        }
    }

}
