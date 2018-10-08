using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Domain;
using PetShop.Core.Entity;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Data.SQLRepositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public Pet AddPet(Pet pet)
        {
            var added = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return added;
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter.CurrentPage<1 || filter.ItemsPrPage<1)
            {
                return _ctx.Pets.Include(p => p.PreviousOwner);
            }

                return _ctx.Pets.Skip(filter.CurrentPage - 1 * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).FirstOrDefault(p => p.Id == id);
        }

        public Pet UpdatePet(Pet pet)
        {
            var updated = _ctx.Pets.Update(pet).Entity;
            _ctx.SaveChanges();
            return updated;
        }

        public Pet DeletePet(Pet deletePet)
        {
            var removed = _ctx.Remove(deletePet).Entity;
            _ctx.SaveChanges();
            return removed;
        }
    }
}