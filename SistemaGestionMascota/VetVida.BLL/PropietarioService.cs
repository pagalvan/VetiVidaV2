using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class PropietarioService : IService<Propietario>
    {
        private readonly PropietarioRepository repoPropietario;

        public PropietarioService()
        {
            repoPropietario = new PropietarioRepository(Archivos.ARC_PROPIETARIO);
        }

        public List<Propietario> Consultar()
        {
            return repoPropietario.Consultar();
        }

        public string Guardar(Propietario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }

                if (string.IsNullOrEmpty(entity.Cedula))
                {
                    throw new ArgumentException("Error... la cédula no puede estar vacía");
                }

                var existente = repoPropietario.ConsultarPorCedula(entity.Cedula);
                if (existente != null)
                {
                    throw new ArgumentException("Error... ya existe un propietario con esa cédula");
                }

                return repoPropietario.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar propietario: {ex.Message}";
            }
        }

        public string Modificar(Propietario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }

                if (string.IsNullOrEmpty(entity.Cedula))
                {
                    throw new ArgumentException("Error... la cédula no puede estar vacía");
                }

                var existente = repoPropietario.ConsultarPorCedula(entity.Cedula);
                if (existente != null && existente.Id != entity.Id)
                {
                    throw new ArgumentException("Error... ya existe otro propietario con esa cédula");
                }

                return repoPropietario.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar propietario: {ex.Message}";
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

                return repoPropietario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar propietario: {ex.Message}";
            }
        }

        public Propietario ConsultarPorCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
            {
                throw new ArgumentException("Error... la cédula no puede estar vacía");
            }

            return repoPropietario.ConsultarPorCedula(cedula);
        }
    }

}
