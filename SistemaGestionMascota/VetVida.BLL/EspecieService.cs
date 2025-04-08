using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class EspecieService : IService<Especie>
    {
        private readonly EspecieRepository repoEspecie;

        public EspecieService()
        {
            repoEspecie = new EspecieRepository(Archivos.ARC_ESPECIE);
        }

        public List<Especie> Consultar()
        {
            return repoEspecie.Consultar();
        }

        public string Guardar(Especie entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoEspecie.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar especie: {ex.Message}";
            }
        }

        public string Modificar(Especie entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoEspecie.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar especie: {ex.Message}";
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                return repoEspecie.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar especie: {ex.Message}";
            }
        }
    }

}
