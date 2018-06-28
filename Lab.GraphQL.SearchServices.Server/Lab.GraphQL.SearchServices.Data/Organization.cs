using System.Collections.Generic;

namespace Lab.GraphQL.SearchServices.Data
{
    public class Organization
    {
        public int Id;
        public string Name;

        public IEnumerable<int> People;
    }
}