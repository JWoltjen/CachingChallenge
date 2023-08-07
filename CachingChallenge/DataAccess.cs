using System;
using System.Collections.Generic;
using System.Linq;

namespace CachingChallenge
{
    public class DataAccess
    {
        private Dictionary<int, PersonModel> personByIdCache = new Dictionary<int, PersonModel>();
        private Dictionary<string, List<PersonModel>> personByLastNameCache = new Dictionary<string, List<PersonModel>>();

        List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel{ Id = 1, FirstName = "Tim", LastName = "Corey" },
            new PersonModel{ Id = 2, FirstName = "Joe", LastName = "Jones" },
            new PersonModel{ Id = 3, FirstName = "Sue", LastName = "Storm" },
            new PersonModel{ Id = 4, FirstName = "Mary", LastName = "Jones" },
            new PersonModel{ Id = 5, FirstName = "Lisa", LastName = "Simmons" },
            new PersonModel{ Id = 6, FirstName = "Tom", LastName = "Smith" }
        };

        public List<PersonModel> SimulatedPersonListLookup()
        {
            Console.WriteLine("The database was accessed");
            return _people;
        }

        public PersonModel SimulatedPersonById(int id)
        {
            // if the dictionary contains the key, the id, then return the person from the cache
            if (personByIdCache.ContainsKey(id))
            {
                return personByIdCache[id];
            }
            
            // else access the database
            Console.WriteLine("The database was accessed for an individual lookup");
            // we add the results of the search to the cache so that next time the cache will be used instead of the database.
            var person = _people.FirstOrDefault(x => x.Id == id);
            personByIdCache[id] = person;
            return person;
        }

        public List<PersonModel> SimulatedPersonListByLastName(string lastName)
        {
            // if the dictionary contains the key, the string, then return the person from the cache
            if (personByLastNameCache.ContainsKey(lastName))
            {
                return personByLastNameCache[lastName];
            }

            // else access the database
            Console.WriteLine("The database was accessed for a last name query");
            var persons = _people.FindAll(x => x.LastName == lastName);
            personByLastNameCache[lastName] = persons;
            return persons;
        }
    }
}
