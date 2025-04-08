using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class MascotaService : IService<Mascota>
    {
        private readonly MascotaRepository repoMascota;

        public MascotaService()
        {
            repoMascota = new MascotaRepository(Archivos.ARC_MASCOTA);
        }

        public List<Mascota> Consultar()
        {
            return repoMascota.Consultar();
        }

        public string Guardar(Mascota entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la mascota no puede ser nula");
                }

                if (string.IsNullOrEmpty(entity.Nombre))
                {
                    throw new ArgumentException("Error... el nombre no puede estar vacío");
                }

                if (entity.Propietario == null)
                {
                    throw new ArgumentException("Error... el propietario no puede ser nulo");
                }

                if (entity.Raza == null)
                {
                    throw new ArgumentException("Error... la raza no puede ser nula");
                }

                return repoMascota.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar mascota: {ex.Message}";
            }
        }

        public string Modificar(Mascota entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la mascota no puede ser nula");
                }

                if (string.IsNullOrEmpty(entity.Nombre))
                {
                    throw new ArgumentException("Error... el nombre no puede estar vacío");
                }

                if (entity.Propietario == null)
                {
                    throw new ArgumentException("Error... el propietario no puede ser nulo");
                }

                if (entity.Raza == null)
                {
                    throw new ArgumentException("Error... la raza no puede ser nula");
                }

                return repoMascota.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar mascota: {ex.Message}";
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

                return repoMascota.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar mascota: {ex.Message}";
            }
        }

        public List<Mascota> ConsultarPorPropietario(int propietarioId)
        {
            if (propietarioId <= 0)
            {
                throw new ArgumentException("Error... el id del propietario debe ser mayor a cero");
            }

            return repoMascota.ConsultarPorPropietario(propietarioId);
        }
    }

}
