using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
    public interface IOwnerRepository
    {
        Owner AddOwner(Owner owner);

        IEnumerable<Owner> ReadOwners();

        Owner ReadById(int id);

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(Owner deleteOwner);
    }
}