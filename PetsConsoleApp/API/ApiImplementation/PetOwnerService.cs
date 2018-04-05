using PetsConsoleApp.API.ApiInterface;
using PetsConsoleApp.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PetsConsoleApp.API.ApiImplementation
{
    /// <summary>
    /// This is implementation of IPetOwnerService interface. This class also inherits from ApiClient abstract class.
    /// </summary>
    public class PetOwnerService : ApiClient, IPetOwnerService
    {
        /// <summary>
        /// URL of API to use.
        /// </summary>
        private readonly string apiUrl;

        /// <summary>
        /// Initialise PetOwnerServie and specify API URL to use.
        /// </summary>
        public PetOwnerService()
        {
            apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        }

        /// <summary>
        /// Get list of pet owners. 
        /// Returns an Exception if API Url is empty or null.
        /// </summary>
        /// <returns>Payload or Exception</returns>
        public List<PetOwner> GetPetOwners()
        {
            if (string.IsNullOrEmpty(apiUrl)) throw new Exception("Invalid API Url");
            return Get<List<PetOwner>>(apiUrl);
        }
    }
}
