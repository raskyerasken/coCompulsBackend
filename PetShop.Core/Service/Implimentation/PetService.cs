using PetShop.Core.Domain;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PetShop.Core.Service.Implimentation
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;
        readonly IOwnerService _ownerService;

        public PetService(IPetRepository petRepository, IOwnerService ownerService)
        {
            _petRepository = petRepository;
            _ownerService = ownerService;
        }

        public Pet CreatePet(Pet pet)
        {
            if (pet.PreviousOwner == null)
            {
                throw new InvalidDataException("FUCK");
            }

            if (_ownerService.ReadById(pet.PreviousOwner.Id) == null)
            {
                throw new InvalidDataException("Owner does not exist");
            }
            return SavePet(pet);
        }

        public Pet DeletePet(int id)
        {
            var deletePet = _petRepository.ReadById(id);
            return _petRepository.DeletePet(deletePet);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            return _petRepository.ReadPets(filter).ToList();
        }

        public List<Pet> GetCheapest()
        {
            var list = _petRepository.ReadPets();
            var query = list.OrderBy(pet => pet.Price);
            return query.Take(5).ToList();
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            pet.Id = id;
            return _petRepository.UpdatePet(pet);
        }

        public Pet GetPetById(int id)
        {
            var pet = _petRepository.ReadPets().FirstOrDefault(p => p.Id == id);
            //pet.PreviousOwner = _ownerService.ReadById(pet.PreviousOwner.Id);
            return pet;
        }

        public List<Pet> GetPetsByPrice()
        {
            var list = _petRepository.ReadPets();
            var query = list.OrderBy(pet => pet.Price);
            return query.ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            var list = _petRepository.ReadPets();
            var query = list.Where(pet => pet.Type.ToLower().Equals(type.ToLower()));
            if(query.ToList().Count > 0)
            {
                return query.ToList();
            }
            return null;
        }

        Pet SavePet(Pet pet)
        {
            return _petRepository.AddPet(pet);
        }
        
    }
}
