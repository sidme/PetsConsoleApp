using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsConsoleApp.API.ApiInterface;
using PetsConsoleApp.BusinessLogic.LogicImplementation;
using PetsConsoleApp.BusinessLogic.LogicInterface;
using PetsConsoleApp.DTO;
using PetsConsoleApp.Model.Enum;
using Rhino.Mocks;
using System.Collections.Generic;

namespace PetsConsoleApp.Tests
{
    /// <summary>
    /// Set of unit tests to test business logic.
    /// </summary>
    [TestClass]
    public class UnitTestPetOwnerLogic
    {
        private IPetOwnerService petOwnerServiceMock;
        private IPetOwnerLogic petOwnerLogic;

        /// <summary>
        /// Initialise test components.
        /// </summary>
        [TestInitialize]
        public void Initialise()
        {
            petOwnerServiceMock = MockRepository.GenerateMock<IPetOwnerService>();
            petOwnerLogic = new PetOwnerLogic(petOwnerServiceMock);
        }

        /// <summary>
        /// Test Case 1: Testing when no data is received
        /// Expected Output: Null;
        /// </summary>
        [TestMethod]
        public void GetCatsByOwnerGender_NullReceived_Pass()
        {
            //Arrange - Initialised
            petOwnerServiceMock.Expect(x => x.GetPetOwners()).Return(null);

            //Act
            var result = petOwnerLogic.GetCatsByOwnerGender();

            //Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Test Case 2: Testing when empty list is receive
        /// Expected Output: Empty array
        /// </summary>
        [TestMethod]
        public void GetCatsByOwnerGender_EmptyListReceived_Pass()
        {
            //Arrange - Initialised
            petOwnerServiceMock.Expect(x => x.GetPetOwners()).Return(new List<PetOwner>());

            //Act
            var result = petOwnerLogic.GetCatsByOwnerGender();

            //Assert
            Assert.IsTrue(result.Count == 0);
        }

        /// <summary>
        /// Test Case 3: Testing when no male pet owner returned
        /// Expected Output: no male pet owner in list
        /// </summary>
        [TestMethod]
        public void GetCatsByOwnerGender_No_Male_Owner_Pass()
        {
            //Arrange - Initialised
            petOwnerServiceMock.Expect(x => x.GetPetOwners()).Return(new List<PetOwner>
            {
                new PetOwner {Age = 22, Gender = Gender.Female, Name = "Name 1", Pets = null},
                new PetOwner {Age = 25, Gender = Gender.Female, Name = "Name 2", Pets = null},

            });

            //Act
            var result = petOwnerLogic.GetCatsByOwnerGender();

            //Assert
            Assert.IsFalse(result.ContainsKey(Gender.Male));
        }
    }
}
