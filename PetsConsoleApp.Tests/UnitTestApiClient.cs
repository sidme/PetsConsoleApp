using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsConsoleApp.API;
using PetsConsoleApp.DTO;
using PetsConsoleApp.Model.Enum;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PetsConsoleApp.Tests
{
    /// <summary>
    /// Set of unit test to test funcationality of ApiClient abstract class by mocking.
    /// </summary>
    [TestClass]
    public class UnitTestApiClient
    {
        /// <summary>
        /// Test Case 1: Testing what happens when ApiClient.Get() returns null to consumer.
        /// Expected Output: If null, test pass
        /// </summary>
        [TestMethod]
        public void ApiClient_Get_ReturnNull_Pass()
        {
            //Arrange
            var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
            abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(null);

            //Act
            var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            //Assert
            Assert.IsNull(result);

        }

        /// <summary>
        /// Test Case 2: Testing what happens when ApiClient.Get() returns an empty list to consumer.
        /// Expected Output: Test passes if empty list is returned
        /// </summary>
        [TestMethod]
        public void ApiClient_Get_ReturnEmtpyArray_Pass()
        {
            //Arrange
            var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
            abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(new List<PetOwner>());

            //Act
            var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            //Assert
            Assert.IsTrue(result.Count == 0);

        }

        /// <summary>
        /// Test Case 3: Testing to see what happens when ApiClient.Get() returns one object of a type
        /// Expected Output: Test passes if list contains one element.
        /// </summary>
        [TestMethod]
        public void ApiClient_Get_ReturnOneObject_Pass()
        {
            //Arrange
            var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
            abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(
                new List<PetOwner>
                {
                    new PetOwner
                    {
                        Age = 20,
                        Gender = Gender.Female,
                        Name = "Name 1",
                        Pets = new List<Pet> {new Pet {Name = "Cat 1", Type = PetType.Cat}}
                    }
                });

            //Act
            var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            //Assert
            Assert.IsTrue(result.Count == 1);

        }

        /// <summary>
        /// Test Case 4: Testing to see if ApiClient.Get() returns one element with null Pets
        /// Expected Output: Test passes if pets object is null
        /// </summary>
        [TestMethod]
        public void ApiClient_Get_ReturnNullPetsWithOneOwner_Pass()
        {
            //Arrange
            var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
            abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(
                new List<PetOwner>
                {
                    new PetOwner
                    {
                        Age = 20,
                        Gender = Gender.Female,
                        Name = "Name 1",
                        Pets = null
                    }
                });

            //Act
            var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            //Assert
            Assert.IsNull(result[0].Pets);

        }

        /// <summary>
        /// Test Case 5: Test to see any exception is thrown by abstract class.
        /// Expected Output: If Exception is thrown, test fails.
        /// Additional Comments: A better approach is to test for specific exceptions like TimeoutException, JsonSerialisationException etc.
        /// </summary>
        [TestMethod]
        public void ApiClient_Get_AnyExceptionThrownByAPiClient_FailIfThrown()
        {
            //Arrange
            var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
            abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(null);

            
            try
            {
                //Act
                var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            }
            catch (Exception exception)
            {
                //Assert
                Assert.IsTrue(exception != null);
            }
        }


    }
}
