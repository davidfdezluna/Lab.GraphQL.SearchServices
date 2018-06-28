using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.GraphQL.SearchServices.Data
{
    public class DataPersonsMock : IDataPersons
    {
        private static List<People> peopleMock => new List<People>() {
            new People(){Id=1,  Name = "Person 1" , Organizations = new List<int>(){1,3 } },
            new People(){Id=2,  Name = "Person 2" , Organizations = new List<int>(){1,2 } },
            new People(){Id=3,  Name = "Person 3" , Organizations = new List<int>(){3,4 } },
            new People(){Id=4,  Name = "Person 4" , Organizations = new List<int>(){2 } },
        };

        private static List<Organization> organizationsMock => new List<Organization>() {
            new Organization(){Id=1,  Name = "Organization 1", People = new List<int>(){1,2 } },
            new Organization(){Id=2,  Name = "Organization 2" , People = new List<int>(){2,4 } },
            new Organization(){Id=3,  Name = "Organization 3" , People = new List<int>(){1,3 } },
            new Organization(){Id=4,  Name = "Organization 4" , People = new List<int>(){3 } },
        };

        public IEnumerable<People> GetPeople()
        {
            return peopleMock;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return organizationsMock;
        }
    }
}
