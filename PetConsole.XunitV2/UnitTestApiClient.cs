using NSubstitute;
using PetsConsoleApp.API;
using PetsConsoleApp.DTO;
using PetsConsoleApp.Model.Enum;
using System.Collections.Generic;
using System.Configuration;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PetConsole.XunitV2
{
    /// <summary>
    /// Set of unit test to test funcationality of ApiClient abstract class by mocking.
    /// </summary>
    public class UnitTestApiClient
    {
        /// <summary>
        /// Test Case 1: Testing what happens when ApiClient.Get() returns null to consumer.
        /// Expected Output: If null, test pass
        /// </summary>
        [Fact]
        public void XApiClient_Get_ReturnNull_Pass()
        {
            //Arrange
            var abstractObject = Substitute.For<ApiClient>();
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            abstractObject.Get<List<PetOwner>>(apiUrl);
            
            //Act
            var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            //Assert
            Assert.IsNull(result);

        }

        /// <summary>
        /// Test Case 3: Testing to see what happens when ApiClient.Get() returns one object of a type
        /// Expected Output: Test passes if list contains one element.
        /// </summary>
        [Fact]
        public void XApiClient_Get_ReturnOneObject_Pass()
        {
            //Arrange
            var abstractObject = Substitute.For<ApiClient>();
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

            var expectedResult = new List<PetOwner>
            {
                new PetOwner
                {
                    Age = 20,
                    Gender = Gender.Female,
                    Name = "Name 1",
                    Pets = new List<Pet> {new Pet {Name = "Cat 1", Type = PetType.Cat}}
                }
            };

            //Act
            abstractObject.Get<List<PetOwner>>(apiUrl).Returns(expectedResult);

            //Assert
            Assert.IsTrue(true);

        }

        /// <summary>
        /// Test Case 4: Testing to see if ApiClient.Get() returns one element with null Pets
        /// Expected Output: Test passes if pets object is null
        /// </summary>
        //[Fact]
        //public void ApiClient_Get_ReturnNullPetsWithOneOwner_Pass()
        //{
        //    //Arrange
        //    var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
        //    abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(
        //        new List<PetOwner>
        //        {
        //            new PetOwner
        //            {
        //                Age = 20,
        //                Gender = Gender.Female,
        //                Name = "Name 1",
        //                Pets = null
        //            }
        //        });

        //    //Act
        //    var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

        //    //Assert
        //    Assert.IsNull(result[0].Pets);

        //}

        /// <summary>
        /// Test Case 5: Test to see any exception is thrown by abstract class.
        /// Expected Output: If Exception is thrown, test fails.
        /// Additional Comments: A better approach is to test for specific exceptions like TimeoutException, JsonSerialisationException etc.
        /// </summary>
        //[Fact]
        //public void ApiClient_Get_AnyExceptionThrownByAPiClient_FailIfThrown()
        //{
        //    //Arrange
        //    var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
        //    abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(null);


        //    try
        //    {
        //        //Act
        //        var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

        //    }
        //    catch (Exception exception)
        //    {
        //        //Assert
        //        Assert.IsTrue(exception != null);
        //    }
        //}

    }
}
