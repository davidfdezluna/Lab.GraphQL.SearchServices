using System.Collections;
using System.Collections.Generic;

namespace Lab.GraphQL.SearchServices.Data
{
    public class People
    {
        public int Id;
        public string Name;
        public IEnumerable<int> Organizations;
    }
}