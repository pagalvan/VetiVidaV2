using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.Ents;

namespace VetVida.DAL
{
    public class MascotaRepository : FileRepository<Mascota>
    {
        private PropietarioRepository propietarioRepository;
        private RazaRepository razaRepository;

        public MascotaRepository(string ruta) : base(ruta)
        {
            propietarioRepository = new PropietarioRepository(Archivos.ARC_PROPIETARIO);
            razaRepository = new RazaRepository(Archivos.ARC_RAZA);
        }

        public override List<Mascota> Consultar()
        {
            try
            {
                List<Mascota> lista = new List<Mascota>();

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

        public override Mascota Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Mascota mascota = new Mascota();
            mascota.Id = int.Parse(campos[0]);
            mascota.Nombre = campos[1];

            int propietarioId = int.Parse(campos[2]);
            mascota.Edad = int.Parse(campos[3]);
            int razaId = int.Parse(campos[4]);

            Propietario propietario = propietarioRepository.Consultar().FirstOrDefault(p => p.Id == propietarioId);
            Raza raza = razaRepository.Consultar().FirstOrDefault(r => r.Id == razaId);

            if (propietario != null)
            {
                mascota.Propietario = propietario;
            }

            if (raza != null)
            {
                mascota.Raza = raza;
            }

            return mascota;
        }

        public List<Mascota> ConsultarPorPropietario(int propietarioId)
        {
            return Consultar().Where(m => m.Propietario.Id == propietarioId).ToList();
        }
    }
}

