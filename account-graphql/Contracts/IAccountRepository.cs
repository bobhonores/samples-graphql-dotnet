using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sample.IdentityManagement.GraphQL.Entities;

namespace Sample.IdentityManagement.GraphQL.Contracts
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccountsPerOwner(Guid ownerId, CancellationToken cancellationToken);
        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds, CancellationToken cancellationToken);
    }
}