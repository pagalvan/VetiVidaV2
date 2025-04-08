using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.Ents;

namespace VetVida.DAL
{
    public class ConsultaRepository : FileRepository<Consulta>
    {
        private MascotaRepository mascotaRepository;
        private VeterinarioRepository veterinarioRepository;

        public ConsultaRepository(string ruta) : base(ruta)
        {
            mascotaRepository = new MascotaRepository(Archivos.ARC_MASCOTA);
            veterinarioRepository = new VeterinarioRepository(Archivos.ARC_VETERINARIO);
        }

        public override List<Consulta> Consultar()
        {
            try
            {
                List<Consulta> lista = new List<Consulta>();

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

        public override Consulta Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Consulta consulta = new Consulta();
            consulta.Id = int.Parse(campos[0]);
            consulta.Fecha = DateTime.Parse(campos[1]);

            int veterinarioId = int.Parse(campos[2]);
            int mascotaId = int.Parse(campos[3]);

            consulta.Diagnostico = campos[4];
            consulta.Tratamiento = campos[5];

            Veterinario veterinario = veterinarioRepository.Consultar().FirstOrDefault(v => v.Id == veterinarioId);
            Mascota mascota = mascotaRepository.Consultar().FirstOrDefault(m => m.Id == mascotaId);

            if (veterinario != null)
            {
                consulta.Veterinario = veterinario;
            }

            if (mascota != null)
            {
                consulta.Mascota = mascota;
            }

            return consulta;
        }

        public List<Consulta> ConsultarPorMascota(int mascotaId)
        {
            return Consultar().Where(c => c.Mascota.Id == mascotaId).ToList();
        }

        public List<Consulta> ConsultarPorVeterinario(int veterinarioId)
        {
            return Consultar().Where(c => c.Veterinario.Id == veterinarioId).ToList();
        }

        public List<Consulta> ConsultarPorFecha(DateTime fecha)
        {
            return Consultar().Where(c => c.Fecha.Date == fecha.Date).ToList();
        }
    }

}
