using GraphQL.Types;
using Lab.GraphQL.SearchServices.App.Types;
using Lab.GraphQL.SearchServices.Data;

namespace Lab.GraphQL.SearchServices.App
{
    public class SearchQuery : ObjectGraphType
    {
        public SearchQuery(IDataPersons data)
        {
            Name = "Query";
            Field<StringGraphType>("Ping", resolve: context => "Ping ok");
            Field<ListGraphType<PeopleGraphType>>("People", resolve: context => {
                return data.GetPeople();
            });
            Field<ListGraphType<OrganizationGraphType>>("Organizations", resolve: context => {
                return data.GetOrganizations();
            });
        }
    }
}