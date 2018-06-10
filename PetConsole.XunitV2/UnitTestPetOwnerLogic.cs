using NSubstitute;
using PetsConsoleApp.API.ApiInterface;
using PetsConsoleApp.BusinessLogic.LogicImplementation;
using PetsConsoleApp.BusinessLogic.LogicInterface;
using PetsConsoleApp.DTO;
using PetsConsoleApp.Model.Enum;
using System.Collections.Generic;
using Xunit;

namespace PetConsole.XunitV2
{
    /// <summary>
    /// Set of unit tests to test business logic.
    /// </summary>
    public class UnitTestPetOwnerLogic
    {
        private IPetOwnerService petOwnerServiceMock;
        private IPetOwnerLogic petOwnerLogic;

        /// <summary>
        /// Initialise test components.
        /// </summary>
        public UnitTestPetOwnerLogic()
        {
            petOwnerServiceMock = Substitute.For<IPetOwnerService>();
            petOwnerLogic = new PetOwnerLogic(petOwnerServiceMock);
        }

        /// <summary>
        /// Test Case 1: Testing when no data is received
        /// Expected Output: Null;
        /// </summary>
        [Fact]
        public void XGetCatsByOwnerGender_NullReceived_Pass()
        {
            //Arrange - Initialised
            petOwnerServiceMock.GetPetOwners().Returns((List<PetOwner>) null);

            //Act
            var result = petOwnerLogic.GetCatsByOwnerGender();

            //Assert
            Assert.True(result == null);
        }

        /// <summary>
        /// Test Case 2: Testing when empty list is receive
        /// Expected Output: Empty array
        /// </summary>
        [Fact]
        public void XGetCatsByOwnerGender_EmptyListReceived_Pass()
        {
            //Arrange - Initialised
            petOwnerServiceMock.GetPetOwners().Returns(new List<PetOwner>());

            //Act
            var result = petOwnerLogic.GetCatsByOwnerGender();

            //Assert
            Assert.True(result.Count == 0);
        }

        /// <summary>
        /// Test Case 3: Testing when no male pet owner returned
        /// Expected Output: no male pet owner in list
        /// </summary>
        [Fact]
        public void XGetCatsByOwnerGender_No_Male_Owner_Pass()
        {
            //Arrange - Initialised
            petOwnerServiceMock.GetPetOwners().Returns(new List<PetOwner>
            {
                new PetOwner {Age = 22, Gender = Gender.Female, Name = "Name 1", Pets = null},
                new PetOwner {Age = 25, Gender = Gender.Female, Name = "Name 2", Pets = null},

            });

            //Act
            var result = petOwnerLogic.GetCatsByOwnerGender();

            //Assert
            Assert.False(result.ContainsKey(Gender.Male));
        }
    }
}
