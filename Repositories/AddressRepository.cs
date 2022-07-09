using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.Common;
using TestTaskApp.DTOs;
using TestTaskApp.Models;

namespace TestTaskApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IBaseEfRepository<Address> _repository;

        public AddressRepository(IBaseEfRepository<Address> repository)
        {
            _repository = repository;
        }

        public Task<string> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Save(AddressDto address, CancellationToken cancellationToken)
        {
            var adres = new Address
            {
                City = address.City,
                AddressLine = address.AddressLine
            };

            await _repository.Add(adres, cancellationToken);
        }
    }
}
