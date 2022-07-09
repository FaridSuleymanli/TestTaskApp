using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestTaskApp.DTOs;
using TestTaskApp.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddressDto address, CancellationToken cancellationToken)
        {
            await _repository.Save(address, cancellationToken);
            return Ok();
        }
    }
}
