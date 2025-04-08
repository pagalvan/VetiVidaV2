using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.Ents;

namespace VetVida.DAL
{
    public class EspecieRepository : FileRepository<Especie>
    {
        public EspecieRepository(string ruta) : base(ruta)
        {
        }

        public override List<Especie> Consultar()
        {
            try
            {
                List<Especie> lista = new List<Especie>();

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

        public override Especie Mappear(string datos)
        {
            Especie especie = new Especie();
            especie.Id = int.Parse(datos.Split(';')[0]);
            especie.Nombre = datos.Split(';')[1];
            return especie;
        }
    }

}
