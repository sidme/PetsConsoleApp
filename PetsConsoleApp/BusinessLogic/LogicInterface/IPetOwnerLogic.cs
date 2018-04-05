using PetsConsoleApp.Model.Enum;
using System.Collections.Generic;

namespace PetsConsoleApp.BusinessLogic.LogicInterface
{
    public interface IPetOwnerLogic
    {
        Dictionary<Gender, List<string>> GetCatsByOwnerGender();
    }
}
