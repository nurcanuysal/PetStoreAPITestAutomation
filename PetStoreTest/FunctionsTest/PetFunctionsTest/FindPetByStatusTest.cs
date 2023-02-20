using System.Net;
using Newtonsoft.Json;
using PetStoreAPI.Functions;
using PetStoreAPI.Models;

namespace PetFunctionsTest;

public class FindPetByStatusTest
{


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
}


