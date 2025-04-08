using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetVida.DAL
{
    public abstract class FileRepository<T> where T : class
    {
        protected string ruta;

        public FileRepository(string ruta)
        {
            this.ruta = ruta;
        }

        public virtual string Guardar(T entity)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta, true);
                sw.WriteLine(entity.ToString());
                sw.Close();
                return "Guardado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al guardar: {ex.Message}";
            }
        }

        public abstract List<T> Consultar();

        public abstract T Mappear(string datos);

        public virtual string Modificar(T entity)
        {
            try
            {
                List<T> lista = Consultar();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!item.Equals(entity))
                    {
                        Guardar(item);
                    }
                }
                Guardar(entity);
                return "Modificado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al modificar: {ex.Message}";
            }
        }

        public virtual string Eliminar(int id)
        {
            try
            {
                List<T> lista = Consultar();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!GetId(item).Equals(id))
                    {
                        Guardar(item);
                    }
                }
                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        protected virtual int GetId(T entity)
        {
            var property = entity.GetType().GetProperty("Id");
            if (property != null)
            {
                return (int)property.GetValue(entity);
            }
            return 0;
        }
    }

}
