using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Domain.IRepositories
{
    public interface IServicioRepository
    {
        Task GuardarServicio(Servicio servicio);
        List<Turnos> ConsultarServicio(TurnoConsultaDTO turnoConsultaDTO);
    }
}
