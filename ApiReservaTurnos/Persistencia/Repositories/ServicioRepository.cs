using ApiReservaTurnos.Domain.IRepositories;
using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.DTO;
using ApiReservaTurnos.Migrations;
using ApiReservaTurnos.Persistencia.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Persistencia.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AplicationDbContext _context;
        public ServicioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public Task ConsultarServicio(int idservicio)
        {
            throw new NotImplementedException();
        }

        public List<Turnos> ConsultarServicio(TurnoConsultaDTO turnoConsultaDTO)
        {
            var parametros = new[] { new SqlParameter("@idServicio", turnoConsultaDTO.id_Servicio),
                                     new SqlParameter("@fechaInicio", turnoConsultaDTO.fecha_inicio),
                                     new SqlParameter("@fechaFin", turnoConsultaDTO.fecha_fin)};

            var listaTurnos =  _context.Turnos.FromSqlRaw("EXEC sp_consultaTurnos @idServicio, @fechaInicio,@fechaFin", parametros).ToList();


            return listaTurnos;
        }

        public async Task GuardarServicio(Servicio servicio)
        {
            _context.Add(servicio);
            await _context.SaveChangesAsync();
        }

    }
}