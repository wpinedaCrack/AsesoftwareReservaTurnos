using ApiReservaTurnos.Domain.Models;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Domain.IRepositories
{
    public interface IComercioRepository
    {
        Task GuardarComercio(Comercio comercio);
    }
}
