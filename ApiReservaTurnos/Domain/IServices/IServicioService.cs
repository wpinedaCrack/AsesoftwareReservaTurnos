using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Domain.IServices
{
    public interface IServicioService
    {
        Task GuardarServicio(Servicio servicio);
        List<Turnos> ConsultarServicio(TurnoConsultaDTO turnoConsultaDTO);
    }
}
