using HomeStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeStats.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ApiController : ControllerBase
    {
        HouseRepository repository = HouseRepository.Current;

        public ApiController(Context context)
        {
            repository.db = context;
        }

        [HttpGet("house")]
        public async Task<IEnumerable<House>> Get()
        {
            return await repository.GetAllHouses();
        }

        [HttpGet("house/{id}")]
        public async Task<House> Get(int Id)
        {
            return await repository.GetHouse(Id);
        }       
        
        [HttpPost("house")]
        public async Task<House> Create(House house)
        {
            return await repository.AddHouseAsync(house);
        }

        [HttpPost("counter")]
        public async Task<Counter> Create(Counter counter)
        {
            return await repository.AddCounterAsync(counter);
        }

        [HttpPut("house")]
        public async Task<bool> Update (House house)
        {
             return await repository.UpdateHouseAsync(house);
        }

        [HttpPut("counter")]
        public async Task<bool> Update(Counter counter)
        {
            return await repository.UpdateCounterAsync(counter);
        }

        [HttpDelete("house/{id}")]
        public async Task RemoveAsync (int Id)
        {
            await repository.RemoveHouseAsync(Id);
        }

        [HttpDelete("counter/{id}")]
        public async Task RemoveCounterAsync(int Id)
        {
            await repository.RemoveCounterAsync(Id);
        }

    }
}
