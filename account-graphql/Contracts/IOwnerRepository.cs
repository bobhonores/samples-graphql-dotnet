using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sample.IdentityManagement.GraphQL.Entities;

namespace Sample.IdentityManagement.GraphQL.Contracts
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAll(CancellationToken cancellationToken);
        Task<Owner> GetById(Guid id, CancellationToken cancellationToken);
        Task<Owner> CreateOwner(Owner owner, CancellationToken cancellationToken);
        Task<Owner> UpdateOwner(Owner dbOwner, Owner owner, CancellationToken cancellationToken);
        Task DeleteOwner(Owner owner, CancellationToken cancellationToken);
    }
}