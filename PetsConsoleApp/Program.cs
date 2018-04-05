using Autofac;
using PetsConsoleApp.BusinessLogic.LogicInterface;
using PetsConsoleApp.Config;
using System;
using System.Linq;

namespace PetsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration application
            var container = Startup.ContainerConfig();

            using (var scope = container.BeginLifetimeScope())
            {
                //Resolve PetOwnerLogic from IOC
                var petOwnerLogic = scope.Resolve<IPetOwnerLogic>();

                try
                {
                    //Request data from Business logic
                    var catsByOwnerGender = petOwnerLogic.GetCatsByOwnerGender();

                    //If null or empty list is returned
                    //Display 'No Data Returned' message
                    //And exit application
                    if (catsByOwnerGender == null || !catsByOwnerGender.Any())
                    {
                        Console.WriteLine($"No data returned.");
                        Environment.Exit(0);
                    }

                    //Display owner gender and cat name alphabetically.
                    foreach (var item in catsByOwnerGender)
                    {
                        Console.WriteLine(item.Key);
                        foreach (var catName in item.Value)
                        {
                            Console.WriteLine("\t" + catName);
                        }
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error: ", exception);
                }

                Console.ReadLine();
            }


        }
    }
}
