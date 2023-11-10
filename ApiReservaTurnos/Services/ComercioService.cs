using ApiReservaTurnos.Domain.IRepositories;
using ApiReservaTurnos.Domain.IServices;
using ApiReservaTurnos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Services
{
    public class ComercioService : IComercioService
    {
        private readonly IComercioRepository _comercioRepository;
        public ComercioService(IComercioRepository loginRepository)
        {
            _comercioRepository = loginRepository;
        }

        public async Task GuardarComercio(Comercio comercio)
        {
            await _comercioRepository.GuardarComercio(comercio);
        }
    }
}
