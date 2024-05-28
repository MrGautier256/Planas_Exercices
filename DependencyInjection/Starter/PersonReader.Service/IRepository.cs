using Common;
using System.Collections.Generic;

namespace PersonReader.Service
{
    public interface IRepository
    {
        IReadOnlyCollection<Person> GetPeople();
        Person GetPerson(int id);
    }
}