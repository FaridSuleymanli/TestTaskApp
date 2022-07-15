using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.Data;
using TestTaskApp.DTOs;
using TestTaskApp.Models;
using TestTaskApp.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll([FromQuery] GetAllRequestDto requestDto, CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAll(requestDto, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult> Save(CancellationToken cancellationToken)
        {
            string json = @"{ 

firstName: ‘Ivan’, 

lastName: ‘Petrov’, 

address: { 

 		city: ‘Kiev’, 

addressLine: prospect “Peremogy” 28/7

} 

}";

            await _repository.Save(json, cancellationToken);

            return Ok();
        }
    }
}
