using ApiReservaTurnos.Domain.IServices;
using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiReservaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        public readonly IServicioService _servicioService;
        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }     
        [HttpPost("CrearServicio")]
        public async Task<IActionResult> CrearServicio([FromBody] Servicio servicio)
        {
            try
            {        
                await _servicioService.GuardarServicio(servicio);

                return Ok(new { message = "El servicio fue registrado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("ConsultarServicio")]
        [HttpPost]
        public ActionResult ConsultarServicio([FromBody] TurnoConsultaDTO turnoConsultaDTO)
        {
          try { 
                if (turnoConsultaDTO.fecha_inicio > turnoConsultaDTO.fecha_fin)
                {
                    return BadRequest("La Fecha de Inicio no puede ser mayor que la fecha fin");
                }

                var lista = _servicioService.ConsultarServicio(turnoConsultaDTO);
                                   //.Include(x => x.Servicio)
                                   //.Select(x => new
                                   //{
                                   //    x.id_turno,
                                   //    nom_servicio = x.Servicio.nom_servicio,
                                   //    x.fecha_turno,
                                   //    x.hora_inicio,
                                   //    x.hora_fin
                                   //}).ToListAsync();
                return Ok(lista);

          }catch (Exception ex)
          {
            return BadRequest(ex.Message);
          }
        }

    }
}
