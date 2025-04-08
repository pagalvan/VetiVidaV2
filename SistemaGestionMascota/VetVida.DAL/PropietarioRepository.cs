using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.Ents;

namespace VetVida.DAL
{
    public class PropietarioRepository : FileRepository<Propietario>
    {
        public PropietarioRepository(string ruta) : base(ruta)
        {
        }

        public override List<Propietario> Consultar()
        {
            try
            {
                List<Propietario> lista = new List<Propietario>();

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

        public override Propietario Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Propietario propietario = new Propietario();
            propietario.Id = int.Parse(campos[0]);
            propietario.Cedula = campos[1];
            propietario.Nombres = campos[2];
            propietario.Apellidos = campos[3];
            propietario.Telefono = campos[4];
            return propietario;
        }

        public Propietario ConsultarPorCedula(string cedula)
        {
            return Consultar().FirstOrDefault(p => p.Cedula == cedula);
        }
    }

}
