using System;
using System.Collections.Generic;
using System.Text;

namespace CachingChallenge
{
    public class PersonCache
    {
        private Dictionary<string, List<PersonModel>> cache = new Dictionary<string, List<PersonModel>>();

        public List<PersonModel> SimulatePersonListLookup(string key)
        {
            // Check if the cache contains the data
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            // Simulate database lookup
            List<PersonModel> persons = SimulatePersonListLookup(key);

            // Store the result in the cache 
            cache[key] = persons;

            return persons;
        }

        private List<PersonModel> SimulateDataBaseLookup(string key)
        {
            return new List<PersonModel>();
        }
    }
}
