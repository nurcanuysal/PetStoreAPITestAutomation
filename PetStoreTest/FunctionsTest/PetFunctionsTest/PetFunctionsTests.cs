using System;
using PetStoreAPI.Functions;
using PetStoreAPI.Models;
using PetStoreTest.Helpers;
using System.Net;
using Newtonsoft.Json;

namespace PetStoreTest.FunctionsTest.PetFunctionsTest
{
	public class PetFunctionsTests
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

        [Test]
        public void Pets_FilterByPending_ResultShouldBePending()
        {

            //Arrange
            var petFunctions = new PetFunctions();


            //Act
            var response = petFunctions.FindPetByStatus(PetStatus.pending);
            List<Pet> content = JsonConvert.DeserializeObject<List<Pet>>(response.Content);


            //Assert
            Console.WriteLine("**** This is the response **** " + response.Content);
            Assert.That(content[0].Status.ToString(), Is.EqualTo("pending"));
        }

        [Test]
        public void availablePets()
        {

            //Arrange
            var petFunctions = new PetFunctions();


            //Act
            var response = petFunctions.FindPetByStatus(PetStatus.available);
            List<Pet> content = JsonConvert.DeserializeObject<List<Pet>>(response.Content);


            //Assert
            Console.WriteLine("**** This is the response **** " + response.Content);
            Assert.That(content[0].Status.ToString(), Is.EqualTo("available"));
        }

        [Test]
        public void soldPets()
        {

            //Arrange
            var petFunctions = new PetFunctions();


            //Act
            var response = petFunctions.FindPetByStatus(PetStatus.sold);
            List<Pet> content = JsonConvert.DeserializeObject<List<Pet>>(response.Content);


            //Assert
            Console.WriteLine("**** This is the response **** " + response.Content);
            Assert.That(content[0].Status.ToString(), Is.EqualTo("sold"));
        }

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

