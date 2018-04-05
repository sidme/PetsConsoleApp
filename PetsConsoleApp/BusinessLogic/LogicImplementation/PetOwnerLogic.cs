using PetsConsoleApp.API.ApiInterface;
using PetsConsoleApp.BusinessLogic.LogicInterface;
using PetsConsoleApp.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetsConsoleApp.BusinessLogic.LogicImplementation
{
    /// <summary>
    /// PetOwnerLogic class is responsible for getting data from PetOwnerService, prepare DTO and hand it over to client.
    /// This class implements IPetOwnerLogic. 
    /// Uses IOC to resolve dependencies.
    /// </summary>
    public class PetOwnerLogic:IPetOwnerLogic
    {
        private readonly IPetOwnerService _petOwnerService;

        public PetOwnerLogic(IPetOwnerService petOwnerService)
        {
            this._petOwnerService = petOwnerService;
        }

        /// <summary>
        /// Get pet owner gender and cat's name
        /// </summary>
        /// <returns>Dictionary object</returns>
        public Dictionary<Gender, List<string>> GetCatsByOwnerGender()
        {
            try
            {
                var petOwners = _petOwnerService.GetPetOwners();

                //Return null if petOwners is null otherwise linq query result
                var results = petOwners?.GroupBy(x => x.Gender)
                    .Select(x => new
                    {
                        Gender = x.Key,
                        CatNames = x.Where(p => p.Pets != null)
                            .SelectMany(p => p.Pets)
                            .Where(p => p.Type == PetType.Cat)
                            .Select(p => p.Name)
                            .OrderBy(p => p).ToList()
                    }).ToDictionary(x => x.Gender, x => x.CatNames);

                return results;
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to list of pet owners. See inner exception for details.", exception);
            }
        }
    }
}
