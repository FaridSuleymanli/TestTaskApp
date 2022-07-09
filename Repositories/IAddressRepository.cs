using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.DTOs;

namespace TestTaskApp.Repositories
{
    public interface IAddressRepository
    {
        public Task<string> GetAll(CancellationToken cancellationToken);

        Task Save(AddressDto address, CancellationToken cancellationToken);
    }
}
