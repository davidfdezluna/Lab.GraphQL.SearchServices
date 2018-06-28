using GraphQL.Types;
using Lab.GraphQL.SearchServices.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab.GraphQL.SearchServices.App.Types
{
    public class PeopleGraphType : ObjectGraphType<People>
    {
        public PeopleGraphType(IDataPersons data)
        {
            Name = "Peoples";
            Description = "Entity that represents the people of an organization";
            Field(x => x.Name).Description("Name of person");
            Field<ListGraphType<OrganizationGraphType>>("Organizations", resolve: context =>
            {
                return data.GetOrganizations().Where(org => org.People.Contains(context.Source.Id));

            });
        }
    }
}
