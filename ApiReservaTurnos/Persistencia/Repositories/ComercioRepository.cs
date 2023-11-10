using ApiReservaTurnos.Domain.IRepositories;
using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.Persistencia.Context;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Persistencia.Repositories
{
    public class ComercioRepository : IComercioRepository
    {
        private readonly AplicationDbContext _context;
        public ComercioRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task GuardarComercio(Comercio comercio)
        {
            _context.Add(comercio);
            await _context.SaveChangesAsync();
        }
    }
}
