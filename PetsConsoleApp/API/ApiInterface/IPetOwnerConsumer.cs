using PetsConsoleApp.DTO;
using System.Collections.Generic;

namespace PetsConsoleApp.API.ApiInterface
{
    /// <summary>
    /// Interface defining contract for extraction of PetOwner data from API.
    /// </summary>
    public interface IPetOwnerService
    {
        /// <summary>
        /// Get list of pet owners.
        /// </summary>
        /// <returns></returns>
        List<PetOwner> GetPetOwners();
    }
}
