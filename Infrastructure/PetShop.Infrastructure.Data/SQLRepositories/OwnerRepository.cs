using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.SQLRepositories
{
    public class OwnerRepository : IOwnerRepository
    {

        private readonly PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner AddOwner(Owner owner)
        {
            var added = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return added;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner UpdateOwner(Owner owner)
        {  
            var updated = _ctx.Owners.Update(owner).Entity;
            _ctx.SaveChanges();
            return updated;
        }

        public Owner DeleteOwner(Owner owner)
        {
            var removed = _ctx.Remove(owner).Entity;
            _ctx.SaveChanges();
            return removed;
        }
    }
}