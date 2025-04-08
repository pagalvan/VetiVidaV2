using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetVida.DAL;
using VetVida.Ents;

namespace VetVida.BLL
{
    public class HistorialMedicoService : IService<HistorialMedico>
    {
        private HistorialMedicoRepository repository;

        public HistorialMedicoService()
        {
            repository = new HistorialMedicoRepository(Archivos.ARC_HISTORIAL_MEDICO);
        }

        public string Guardar(HistorialMedico entity)
        {
            try
            {
                repository.Guardar(entity);
                return "Historial médico guardado exitosamente";
            }
            catch (Exception ex)
            {
                return "Error al guardar el historial médico: " + ex.Message;
            }
        }

        public List<HistorialMedico> Consultar()
        {
            return repository.Consultar();
        }

        public string Modificar(HistorialMedico entity)
        {
            try
            {
                repository.Modificar(entity);
                return "Historial médico modificado exitosamente";
            }
            catch (Exception ex)
            {
                return "Error al modificar el historial médico: " + ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                repository.Eliminar(id);
                return "Historial médico eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el historial médico: " + ex.Message;
            }
        }

        public HistorialMedico ConsultarPorMascota(int mascotaId)
        {
            return repository.ConsultarPorMascota(mascotaId);
        }
    }

}
