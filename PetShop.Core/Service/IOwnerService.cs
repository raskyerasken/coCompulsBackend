using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Service
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        Owner CreateOwner(Owner owner);
        Owner ReadById(int id);
        Owner UpdateOwner(Owner owner, int id);
        Owner DeleteOwner(int id);
    }
}