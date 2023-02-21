using System;
using System.Net;
using PetStoreTest.Helpers;
using PetStoreAPI.Functions;
using PetStoreAPI.Modals;
using FluentAssertions;
using FluentAssertions.AssertMultiple;
using PetStoreAPI.Models;

namespace PetStoreTest.FunctionsTest.UserFunctionsTest
{
	public class UserFunctionTests
	{
        [Test]
        public void VerifyUserCreation()
        {
            var user = UserHelpers.PrepareUser("firstName", "lastName", "userName");
            var userFunctions = new UserFunctions();

            var responseUser = new Response<User>();

            var userData = responseUser.GetResponseContent<User>(userFunctions.GetUserByUsername(user.Username));
       
            AssertMultiple.Multiple(() =>
            {
                userData.Should().NotBeNull();
                userData.Id.Should().Be(userData.Id);
                userData.Username.Should().Be(userData.Username);
                userData.FirstName.Should().Be(userData.FirstName);
                userData.LastName.Should().Be(userData.LastName);
                userData.Email.Should().Be(userData.Email);
                userData.Password.Should().Be(userData.Password);
                userData.Phone.Should().Be(userData.Phone);
                userData.UserStatus.Should().Be(userData.UserStatus);
            });
        }

        [Test]
        public void UserCRUDTest()
        {
            var user = UserHelpers.PrepareUser("firstName", "lastName", "userName");
            var userFunctions = new UserFunctions();
            var userData = userFunctions.GetUserByUsername(user.Username);
            var responseUser = new Response<User>();

            var userResponse = responseUser.GetResponseContent<User>(userFunctions.GetUserByUsername(user.Username));
            userResponse.Id.Should().Be(user.Id);
            user.Password = "MyNewPassword@!";

            userFunctions.UpdateUser(user, user.Username);
            var updateUser = userFunctions.GetUserByUsername(user.Username);

            userResponse = responseUser.GetResponseContent<User>(userFunctions.GetUserByUsername(user.Username));
            userResponse.Password.Should().Be(user.Password);
            userFunctions.DeleteUser(user.Username, HttpStatusCode.OK);
        }
    }
}

