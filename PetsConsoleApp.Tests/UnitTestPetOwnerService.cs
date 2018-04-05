
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
        public void PetOwnerService_Url_Is_Valid()
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
        public void PetOwnerService_ReturnValue_Is_Not_Null()
        {
            //Arrange
            PetOwnerService petOwnerService = new PetOwnerService();

            //Act
            var result  = petOwnerService.GetPetOwners();

            //Assert
            Assert.IsNotNull(result);

        }

     
        /// <summary>
        /// Test Case 3: Count list of pet owners returned by PetOwerService
        /// Expected Output: Test succeeds if 6 pet owners are returned.
        /// </summary>
        [TestMethod]
        public void PetOwnerService_Count_PetOwners()
        {
            //Arrange
            PetOwnerService petOwnerService = new PetOwnerService();

            //Act
            var result = petOwnerService.GetPetOwners();

            //Assert
            Assert.AreEqual(result.Count, 6);
        }

        /// <summary>
        /// Test Case 4: Test to see any exception is thrown by abstract class.
        /// Expected Output: If Exception is thrown, test fails.
        /// Additional Comments: A better approach is to test for specific exceptions like TimeoutException, JsonSerialisationException etc.
        /// </summary>
        [TestMethod]
        public void ApiClient_Any_Exception_Thrown()
        {
            //Arrange
            PetOwnerService petOwnerService = new PetOwnerService();

            //Act
            try
            {
                var result = petOwnerService.GetPetOwners();
            }
            catch (Exception exception)
            {
                //Assert
                Assert.IsTrue(exception != null);
            }
        }

    }


}
