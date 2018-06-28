using System.Collections.Generic;

namespace Lab.GraphQL.SearchServices.Data
{
    public interface IDataPersons
    {
        IEnumerable<Organization> GetOrganizations();
        IEnumerable<People> GetPeople();
    }
}