using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Service
{
    public interface IPetService
    {
       
        Pet CreatePet(Pet pet);
        List<Pet> GetAllPets();
        List<Pet> GetFilteredPets(Filter filter);
        Pet GetPetById(int id);
        Pet DeletePet(int id);
        Pet UpdatePet(int id, Pet name);
      
    }
}
