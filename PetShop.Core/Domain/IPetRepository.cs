using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Domain
{
    public interface IPetRepository
    {
        Pet AddPet(Pet pet);

        IEnumerable<Pet> ReadPets(Filter filter = null);

        Pet ReadById(int id);

        Pet UpdatePet(Pet pet);

        Pet DeletePet(Pet deletePet);
    }
}
