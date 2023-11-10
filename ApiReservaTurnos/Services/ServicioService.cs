
using ApiReservaTurnos.Domain.IRepositories;
using ApiReservaTurnos.Domain.IServices;
using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;
        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public List<Turnos> ConsultarServicio(TurnoConsultaDTO turnoConsultaDTO)
        {
            return _servicioRepository.ConsultarServicio(turnoConsultaDTO);
        }

        public async Task GuardarServicio(Servicio servicio)
        {
            await _servicioRepository.GuardarServicio(servicio);
        }
       

        
    }
}
