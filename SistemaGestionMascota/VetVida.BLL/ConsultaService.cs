using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class ConsultaService : IService<Consulta>
    {
        private readonly ConsultaRepository repoConsulta;

        public ConsultaService()
        {
            repoConsulta = new ConsultaRepository(Archivos.ARC_CONSULTA);
        }

        public List<Consulta> Consultar()
        {
            return repoConsulta.Consultar();
        }

        public string Guardar(Consulta entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la consulta no puede ser nula");
                }

                if (entity.Veterinario == null)
                {
                    throw new ArgumentException("Error... el veterinario no puede ser nulo");
                }

                if (entity.Mascota == null)
                {
                    throw new ArgumentException("Error... la mascota no puede ser nula");
                }

                if (string.IsNullOrEmpty(entity.Diagnostico))
                {
                    throw new ArgumentException("Error... el diagnóstico no puede estar vacío");
                }

                return repoConsulta.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar consulta: {ex.Message}";
            }
        }

        public string Modificar(Consulta entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la consulta no puede ser nula");
                }

                if (entity.Veterinario == null)
                {
                    throw new ArgumentException("Error... el veterinario no puede ser nulo");
                }

                if (entity.Mascota == null)
                {
                    throw new ArgumentException("Error... la mascota no puede ser nula");
                }

                if (string.IsNullOrEmpty(entity.Diagnostico))
                {
                    throw new ArgumentException("Error... el diagnóstico no puede estar vacío");
                }

                return repoConsulta.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar consulta: {ex.Message}";
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

                return repoConsulta.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar consulta: {ex.Message}";
            }
        }

        public List<Consulta> ConsultarPorMascota(int mascotaId)
        {
            if (mascotaId <= 0)
            {
                throw new ArgumentException("Error... el id de la mascota debe ser mayor a cero");
            }

            return repoConsulta.ConsultarPorMascota(mascotaId);
        }

        public List<Consulta> ConsultarPorVeterinario(int veterinarioId)
        {
            if (veterinarioId <= 0)
            {
                throw new ArgumentException("Error... el id del veterinario debe ser mayor a cero");
            }

            return repoConsulta.ConsultarPorVeterinario(veterinarioId);
        }

        public List<Consulta> ConsultarPorFecha(DateTime fecha)
        {
            return repoConsulta.ConsultarPorFecha(fecha);
        }
    }

}
