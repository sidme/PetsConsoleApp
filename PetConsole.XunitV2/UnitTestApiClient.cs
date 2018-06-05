using NSubstitute;
using PetsConsoleApp.API;
using PetsConsoleApp.DTO;
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
            //var abstractObject = MockRepository.GeneratePartialMock<ApiClient>();
            //abstractObject.Stub(x => x.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"])).Return(null);

            //Act
            var result = abstractObject.Get<List<PetOwner>>(ConfigurationManager.AppSettings["ApiUrl"]);

            //Assert
            Assert.IsNull(result);

        }
    }
}
