using Sample.IdentityManagement.GraphQL.Entities;
using GraphQL.Types;

namespace Sample.IdentityManagement.GraphQL.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object";
        }
    }
}