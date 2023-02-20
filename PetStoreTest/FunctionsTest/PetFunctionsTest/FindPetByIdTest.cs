using System.Net;
using PetStoreAPI.Functions;
using PetStoreAPI.Models;
using PetStoreTest.Helpers;


namespace PetFunctionsTest
{
    public class FindPetByIdTest
    {
        [Test]
        public void Pets_FilterById_Successful()
        {

            //Arrange
            var petFunctions = new PetFunctions();


            //Act
            var response = petFunctions.FindPetById(1);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Pets_FilterById_TheSameId()
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
            Assert.That(newAddedPetData.Id, Is.EqualTo(newAddedPet.Id));
        }
    }
}



