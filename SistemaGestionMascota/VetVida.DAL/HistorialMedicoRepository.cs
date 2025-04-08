using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.Ents;

namespace VetVida.DAL
{
    public class HistorialMedicoRepository : FileRepository<HistorialMedico>
    {
        private MascotaRepository mascotaRepository;
        private ConsultaRepository consultaRepository;

        public HistorialMedicoRepository(string ruta) : base(ruta)
        {
            mascotaRepository = new MascotaRepository(Archivos.ARC_MASCOTA);
            consultaRepository = new ConsultaRepository(Archivos.ARC_CONSULTA);
        }

        public override List<HistorialMedico> Consultar()
        {
            try
            {
                List<HistorialMedico> lista = new List<HistorialMedico>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(Mappear(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override HistorialMedico Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            HistorialMedico historial = new HistorialMedico();
            historial.Id = int.Parse(campos[0]);

            int mascotaId = int.Parse(campos[1]);
            historial.MascotaId = mascotaId;

            historial.FechaCreacion = DateTime.Parse(campos[2]);
            historial.Observaciones = campos[3];

            Mascota mascota = mascotaRepository.Consultar().FirstOrDefault(m => m.Id == mascotaId);
            if (mascota != null)
            {
                historial.Mascota = mascota;
            }

            // Cargar consultas relacionadas
            List<Consulta> consultas = consultaRepository.ConsultarPorMascota(mascotaId);
            foreach (var consulta in consultas)
            {
                historial.AgregarConsulta(consulta);
            }

            return historial;
        }

        public HistorialMedico ConsultarPorMascota(int mascotaId)
        {
            return Consultar().FirstOrDefault(h => h.MascotaId == mascotaId);
        }
    }

}
