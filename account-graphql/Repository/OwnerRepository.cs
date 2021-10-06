using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.IdentityManagement.GraphQL.Contracts;
using Sample.IdentityManagement.GraphQL.Entities;
using Sample.IdentityManagement.GraphQL.Entities.Context;

namespace Sample.IdentityManagement.GraphQL.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Owner> CreateOwner(Owner owner, CancellationToken cancellationToken)
        {
            owner.Id = Guid.NewGuid();
            await _context.AddAsync(owner, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return owner;
        }

        public Task DeleteOwner(Owner owner, CancellationToken cancellationToken)
        {
            _context.Remove(owner);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task<List<Owner>> GetAll(CancellationToken cancellationToken) => _context.Owners.ToListAsync(cancellationToken);

        public Task<Owner> GetById(Guid id, CancellationToken cancellationToken) => _context.Owners.SingleOrDefaultAsync(o => o.Id.Equals(id), cancellationToken);

        public async Task<Owner> UpdateOwner(Owner dbOwner, Owner owner, CancellationToken cancellationToken)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            await _context.SaveChangesAsync(cancellationToken);
            return dbOwner;
        }
    }
}