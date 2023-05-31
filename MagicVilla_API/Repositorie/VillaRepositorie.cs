using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorie.IRepositorie;

namespace MagicVilla_API.Repositorie
{
    public class VillaRepositorie : Repositorie<Villa>, IVillaRepositorie
    {

        private readonly ApplicationDbContext _db;

        public VillaRepositorie(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Villa> Update(Villa entity)
        {
            entity.DateUpdated = DateTime.Now;
            _db.Villas.Update(entity);

            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
