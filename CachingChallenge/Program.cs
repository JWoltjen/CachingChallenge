using System;
using System.Linq;

namespace CachingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess= new DataAccess();

            Console.WriteLine("Enter an ID or Lastname of a person to lookup");

            string input = Console.ReadLine();

            // Check if the input is an integer
            if (int.TryParse(input, out int id))
            {
                PersonModel person = dataAccess.SimulatedPersonById(id);
                if (person != null)
                {
                    Console.WriteLine($"Found person with Id {id}: {person.FirstName} {person.LastName}");
                }
                else
                {
                    Console.WriteLine($"No person found with ID {id}");
                }
            }
            else // assume the input is a last name
            {
                string lastName = input;
                var persons = dataAccess.SimulatedPersonListByLastName(lastName);
                if(persons.Any())
                {
                    Console.WriteLine($"Found {persons.Count} persons(s) with last name {lastName}");
                    foreach (var person in persons)
                    {
                        Console.WriteLine($"-{person.FirstName} {person.LastName}");
                    }
                }
                else
                {
                    Console.WriteLine($"No persons found with last name {lastName}");
                }
            }

        }
    }
}
