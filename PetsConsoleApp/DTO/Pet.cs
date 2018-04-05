using PetsConsoleApp.Model.Enum;

namespace PetsConsoleApp.DTO
{
    /// <summary>
    /// This is DTO for Pets
    /// </summary>
    public class Pet
    {
        /// <summary>Name property.</summary> 
        /// <value>Name of pet.Example: Garfield</value>
        public string Name { get; set; }

        /// <summary>Type property.</summary> 
        /// <value>Type of pet.Example: Cat, Dog, Fish etc.</value>
        public PetType Type { get; set; }

    }
}
