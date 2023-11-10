using ApiReservaTurnos.Domain.Models;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Domain.IServices
{
    public interface IComercioService
    {
        Task GuardarComercio(Comercio comercio);
    }
}
