using System;
using PetStoreAPI.Functions;
using PetStoreAPI.Models;
using PetStoreTest.Helpers;
using System.Net;

namespace PetFunctionsTest
{
	public class AddNewPetToStoreTest
	{
        [Test]
        public void Pets_AddNewPet_Successful()
        {

            //Arrange
            var petFunctions = new PetFunctions();
            var pet = PetHelpers.PreparePetData("Doogie", PetStatus.pending);

            //Act
            var response = petFunctions.AddNewPetToStore(pet);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Pets_AddNewPetWithPendingStatus_TheSameStatus()
        {

            //Arrange
            var petFunctions = new PetFunctions();
            var pet = PetHelpers.PreparePetData("Doogie", PetStatus.pending);
            var responsePet = new Response<Pet>();

            //Act
            var addResponse = petFunctions.AddNewPetToStore(pet);
            var newAddedPet = responsePet.GetResponseContent<Pet>(addResponse);
            var getResponse = petFunctions.FindPetById(newAddedPet.Id);
            var newAddedPetData = responsePet.GetResponseContent<Pet>(getResponse);

            //Assert
            Assert.That(newAddedPetData.Status, Is.EqualTo(newAddedPet.Status));
        }
    }
}

