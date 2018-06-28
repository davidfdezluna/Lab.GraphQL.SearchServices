using GraphQL.Types;
using Lab.GraphQL.SearchServices.Data;
using System.Linq;

namespace Lab.GraphQL.SearchServices.App.Types
{
    public class OrganizationGraphType : ObjectGraphType<Organization>
    {
        public OrganizationGraphType(IDataPersons data)
        {
            Name = "Organization";
            Description = "Entity that represents an organization";
            Field(x => x.Name).Description("Name of organization");
            Field<ListGraphType<PeopleGraphType>>("People", resolve: context => {
                return data.GetPeople().Where(p => p.Organizations.Contains(context.Source.Id));
            });
        }
    }
}