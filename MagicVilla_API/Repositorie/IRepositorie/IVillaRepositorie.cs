using MagicVilla_API.Models;

namespace MagicVilla_API.Repositorie.IRepositorie
{
    public interface IVillaRepositorie : IRepositorie<Villa>
    {
        Task<Villa> Update(Villa entity);
    }
}
