using ApiReservaTurnos.Domain.IServices;
using ApiReservaTurnos.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace ApiReservaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        private readonly IComercioService _comercioService;
        public ComercioController(IComercioService comercioService)
        {
            _comercioService = comercioService;
        }
        [HttpPost("CrearComercio")]
        public async Task<IActionResult> CrearComercio([FromBody] Comercio comercio)
        {
            try
            {
                await _comercioService.GuardarComercio(comercio);

                return Ok(new { message = "El comercio fue registrado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
