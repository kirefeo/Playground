using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories
{
    public class PersonRepository
    {
        private AdventureWorks2017Entities db = new AdventureWorks2017Entities();

        public List<Person> GetPersons()
        {
            return db.Person.ToList();
        }
    }
}
