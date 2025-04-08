using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.Ents;

namespace VetVida.DAL
{
    public class VeterinarioRepository : FileRepository<Veterinario>
    {
        public VeterinarioRepository(string ruta) : base(ruta)
        {
        }

        public override List<Veterinario> Consultar()
        {
            try
            {
                List<Veterinario> lista = new List<Veterinario>();

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

        public override Veterinario Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Veterinario veterinario = new Veterinario();
            veterinario.Id = int.Parse(campos[0]);
            veterinario.Cedula = campos[1];
            veterinario.Nombres = campos[2];
            veterinario.Apellidos = campos[3];
            veterinario.Telefono = campos[4];
            if (campos.Length > 5)
            {
                veterinario.Especialidad = campos[5];
            }
            return veterinario;
        }

        public Veterinario ConsultarPorCedula(string cedula)
        {
            return Consultar().FirstOrDefault(v => v.Cedula == cedula);
        }

        public List<Veterinario> ConsultarPorEspecialidad(string especialidad)
        {
            return Consultar().Where(v => v.Especialidad.Contains(especialidad)).ToList();
        }
    }

}
