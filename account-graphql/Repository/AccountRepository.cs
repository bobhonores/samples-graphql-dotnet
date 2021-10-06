using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.IdentityManagement.GraphQL.Contracts;
using Sample.IdentityManagement.GraphQL.Entities;
using Sample.IdentityManagement.GraphQL.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Sample.IdentityManagement.GraphQL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds, CancellationToken cancellationToken)
        {
            var accounts = await _context.Accounts.Where(x => ownerIds.Contains(x.OwnerId)).ToListAsync(cancellationToken);
            return accounts.ToLookup(x => x.OwnerId);
        }

        public Task<List<Account>> GetAllAccountsPerOwner(Guid ownerId, CancellationToken cancellationToken) =>
            _context.Accounts.Where(a => a.OwnerId.Equals(ownerId)).ToListAsync(cancellationToken);
    }
}