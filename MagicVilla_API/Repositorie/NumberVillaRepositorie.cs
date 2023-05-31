using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorie.IRepositorie;

namespace MagicVilla_API.Repositorie
{
    public class NumberVillaRepositorie : Repositorie<NumberVilla>, INumberVillaRepositorie
    {
        private readonly ApplicationDbContext _db;

        public NumberVillaRepositorie(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<NumberVilla> Update(NumberVilla entity)
        {
            entity.DateUpdated = DateTime.Now;
            _db.NumberVilla.Update(entity);

            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
