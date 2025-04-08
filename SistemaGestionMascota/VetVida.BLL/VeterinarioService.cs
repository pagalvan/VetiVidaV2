using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class VeterinarioService : IService<Veterinario>
    {
        private readonly VeterinarioRepository repoVeterinario;

        public VeterinarioService()
        {
            repoVeterinario = new VeterinarioRepository(Archivos.ARC_VETERINARIO);
        }

        public List<Veterinario> Consultar()
        {
            return repoVeterinario.Consultar();
        }

        public string Guardar(Veterinario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el veterinario no puede ser nulo");
                }

                if (string.IsNullOrEmpty(entity.Cedula))
                {
                    throw new ArgumentException("Error... la cédula no puede estar vacía");
                }

                var existente = repoVeterinario.ConsultarPorCedula(entity.Cedula);
                if (existente != null)
                {
                    throw new ArgumentException("Error... ya existe un veterinario con esa cédula");
                }

                return repoVeterinario.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar veterinario: {ex.Message}";
            }
        }

        public string Modificar(Veterinario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el veterinario no puede ser nulo");
                }

                if (string.IsNullOrEmpty(entity.Cedula))
                {
                    throw new ArgumentException("Error... la cédula no puede estar vacía");
                }

                var existente = repoVeterinario.ConsultarPorCedula(entity.Cedula);
                if (existente != null && existente.Id != entity.Id)
                {
                    throw new ArgumentException("Error... ya existe otro veterinario con esa cédula");
                }

                return repoVeterinario.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar veterinario: {ex.Message}";
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

                return repoVeterinario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar veterinario: {ex.Message}";
            }
        }

        public Veterinario ConsultarPorCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
            {
                throw new ArgumentException("Error... la cédula no puede estar vacía");
            }

            return repoVeterinario.ConsultarPorCedula(cedula);
        }

        public List<Veterinario> ConsultarPorEspecialidad(string especialidad)
        {
            if (string.IsNullOrEmpty(especialidad))
            {
                throw new ArgumentException("Error... la especialidad no puede estar vacía");
            }

            return repoVeterinario.ConsultarPorEspecialidad(especialidad);
        }
    }

}
