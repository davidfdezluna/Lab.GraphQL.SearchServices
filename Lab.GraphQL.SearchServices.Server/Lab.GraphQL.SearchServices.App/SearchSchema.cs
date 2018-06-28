using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.GraphQL.SearchServices.App
{
    public class SearchSchema : Schema
    {
        public SearchSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<SearchQuery>();
        }
    }
}
