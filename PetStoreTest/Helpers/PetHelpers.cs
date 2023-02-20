using System;
using PetStoreAPI.Models;
using PetStoreAPI.Helpers;

namespace PetStoreTest.Helpers
{
    public class PetHelpers
    {
        public static Pet PreparePetData(string name, PetStatus petStatus)
        {
            return new Pet()
            {
                Id = 0,
                Name = name,
                Status = petStatus.ToString(),
                Category = new Category()
                {
                    Id = 0,
                    Name = Randomizer.GenerateRandomString()
                }
            };
        }
    }
}

