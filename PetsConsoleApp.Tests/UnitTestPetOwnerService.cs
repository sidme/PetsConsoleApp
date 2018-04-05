
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsConsoleApp.API.ApiImplementation;
using System;

namespace PetsConsoleApp.Tests
{
    /// <summary>
    /// Set of unit tests to test consumption of API via PetOwnerService.
    /// Because ApiClient is an abstract class it is also tested via PetOwnerService. 
    /// </summary>
    [TestClass]
    public class UnitTestPetOwnerService
    {
        /// <summary>
        /// Test Case 1: Test to see if API URL is valid. Exception is thrown if URL is null or empty.
        /// Expected Output: If Exception with message is returned, test fails.
        /// Additional Comments: A better approach would be to create a custom exception class (inheriting from System.Exception) and throw that.
        /// Test can than be modified to expect an exception.
        /// </summary>
        [TestMethod]
        public void GetPetOwners_IsApiUrlValid_ExceptionThrownIfNot()
        {
            //Arrange
            PetOwnerService petOwnerService = new PetOwnerService();

            //Act
            Exception exception = new Exception();
            try
            {
                var result = petOwnerService.GetPetOwners();
            }
            catch (Exception e)
            {
                exception = e;
            }


            //Assert
            Assert.IsFalse(exception.Message.Equals("Invalid API Url"));

        }


        /// <summary>
        /// Test Case 2: Test to see if any data is returned from API via PetOwnerService.
        /// Expected Output: Test passes of data or empy array is returned. Fails if null is returned.
        /// </summary>
        [TestMethod]
        public void GetPetOwners_ReturnNotNull_Pass()
        {
            //Arrange
            PetOwnerService petOwnerService = new PetOwnerService();

            //Act
            var result  = petOwnerService.GetPetOwners();

            //Assert
            Assert.IsNotNull(result);

        }

        
    }


}
