using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class RazaService : IService<Raza>
    {
        private readonly RazaRepository repoRaza;

        public RazaService()
        {
            repoRaza = new RazaRepository(Archivos.ARC_RAZA);
        }

        public List<Raza> Consultar()
        {
            return repoRaza.Consultar();
        }

        public string Guardar(Raza entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la raza no puede ser nula");
                }

                if (entity.Especie == null)
                {
                    throw new NullReferenceException("Error... la especie de la raza no puede ser nula");
                }

                return repoRaza.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar raza: {ex.Message}";
            }
        }

        public string Modificar(Raza entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la raza no puede ser nula");
                }

                if (entity.Especie == null)
                {
                    throw new NullReferenceException("Error... la especie de la raza no puede ser nula");
                }

                return repoRaza.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar raza: {ex.Message}";
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

                return repoRaza.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar raza: {ex.Message}";
            }
        }

        public List<Raza> ConsultarPorEspecie(int especieId)
        {
            return repoRaza.ConsultarPorEspecie(especieId);
        }
    }

}
