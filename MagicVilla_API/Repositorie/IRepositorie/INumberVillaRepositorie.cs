using MagicVilla_API.Models;

namespace MagicVilla_API.Repositorie.IRepositorie
{
    public interface INumberVillaRepositorie : IRepositorie<NumberVilla>
    {
        Task<NumberVilla> Update(NumberVilla entity);
    }
}
