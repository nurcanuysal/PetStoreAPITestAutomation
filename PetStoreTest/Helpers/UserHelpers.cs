using System;
using PetStoreAPI.Modals;
using PetStoreAPI.Helpers;

namespace PetStoreTest.Helpers
{
	public class UserHelpers
	{
        public static User PrepareUser(string firstName, string lastName, string userName)
        {
            return new User()
            {
                Id = int.Parse(Randomizer.GenerateRandomId()),
                FirstName = firstName,
                LastName = lastName,
                Username = userName,
                Email = Randomizer.GenerateRandomEmail(),
                Password = Randomizer.GenerateRandomString(),
                Phone = Randomizer.GenerateRandomPhoneNumber(),
                UserStatus = 1
            };
        }

        public User CreateUser(string firstName, string lastName, string userName, User user = null)
        {
            var userToCreate = user;
            if (userToCreate == null) userToCreate = PrepareUser(firstName, lastName, userName);
            return userToCreate;
        }
    }
}

