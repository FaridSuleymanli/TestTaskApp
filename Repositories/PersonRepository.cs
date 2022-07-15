using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.Common;
using TestTaskApp.Models;
using TestTaskApp.Services;
using System.Text.Json.Serialization;
using System.Text.Json;
using TestTaskApp.DTOs;

namespace TestTaskApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IBaseEfRepository<Person> _repository;

        public PersonRepository(IBaseEfRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<string> GetAll(GetAllRequestDto requestDto, CancellationToken cancellationToken)
        {
            var person = await _repository.GetListWithIncludingAsQueryable(cancellationToken, x => x.Address);

            if (!string.IsNullOrEmpty(requestDto.FirstName))
            {
                person = person.Where(x => x.FirstName == requestDto.FirstName);
            }

            if (!string.IsNullOrEmpty(requestDto.LastName))
            {
                person = person.Where(x => x.LastName == requestDto.LastName);
            }

            if (!string.IsNullOrEmpty(requestDto.City))
            {
                person = person.Where(x => x.Address.City == requestDto.City);
            }

            var obj = new JsonObject
            {
                People = person.ToList()
            };

            string json = obj.ToString();

            return json;
        }

        public async Task Save(string json, CancellationToken cancellationToken)
        {
            var person = new Person();
            person.JsonParse(json);

            await _repository.Add(person, cancellationToken);
        }
    }
}
