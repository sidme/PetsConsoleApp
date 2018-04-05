using PetsConsoleApp.Model.Enum;
using System.Collections.Generic;

namespace PetsConsoleApp.DTO
{
    /// <summary>
    /// This is DTO for PetOwner object. 
    /// </summary>
    public class PetOwner
    {
        /// <summary>Name property.</summary> 
        /// <value>Pet owner's name. Example: John</value>
        public string Name { get; set; }

        /// <summary>Gender property.</summary> 
        /// <value>Pet owner's gender.Example: Male or Female</value>
        public Gender Gender { get; set; }

        /// <summary>Age property.</summary> 
        /// <value>Pet owner's age</value>
        public int Age { get; set; }

        /// <summary>Pets property.</summary> 
        /// <value>List of all the pets a pet owner has. Null if an owner has no pets. </value>
        public List<Pet> Pets { get; set; }
    }
}
