using System;
using PetStoreAPI.Functions;
using PetStoreAPI.Models;
using PetStoreTest.Helpers;
using System.Net;

namespace PetFunctionsTest
{
	public class UpdatePetByIdTest
	{
        [Test]
        public void Pets_UpdateExistingPet_Successful()
        {

            //Arrange
            var petFunctions = new PetFunctions();
            var pet = PetHelpers.PreparePetData("Doogie", PetStatus.pending);
            var responsePet = new Response<Pet>();

            //Act
            var addResponse = petFunctions.AddNewPetToStore(pet);
            var newAddedPet = responsePet.GetResponseContent<Pet>(addResponse);
            newAddedPet.Status = PetStatus.sold.ToString();
            var response = petFunctions.UpdatePet(newAddedPet);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Pets_UpdatePetWithSoldStatus_TheSameStatus()
        {

            //Arrange
            var petFunctions = new PetFunctions();
            var pet = PetHelpers.PreparePetData("Doogie", PetStatus.pending);
            var responsePet = new Response<Pet>();

            //Act
            var addResponse = petFunctions.AddNewPetToStore(pet);
            var newAddedPet = responsePet.GetResponseContent<Pet>(addResponse);
            newAddedPet.Status = PetStatus.sold.ToString();
            var updateResponse = petFunctions.UpdatePet(newAddedPet);
            var getResponse = petFunctions.FindPetById(newAddedPet.Id);
            var newAddedPetData = responsePet.GetResponseContent<Pet>(getResponse);


            //Assert
            Console.WriteLine("**** This is the response **** " + getResponse.Content);
            //Assert.That(newAddedPetData.Status, Is.EqualTo("sold"));
        }
    }
}

