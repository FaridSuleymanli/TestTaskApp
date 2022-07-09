using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.DTOs;
using TestTaskApp.Models;

namespace TestTaskApp.Repositories
{
    public interface IPersonRepository
    {
        public Task<string> GetAll(GetAllRequestDto requestDto, CancellationToken cancellationToken);

        Task Save(string json, CancellationToken cancellationToken);
    }
}
