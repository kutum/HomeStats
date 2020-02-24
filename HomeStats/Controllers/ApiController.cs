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
        public IEnumerable<House> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("house/{id}")]
        public House Get(int Id)
        {
            return repository.Get(Id);
        }       
        
        [HttpPost("house")]
        public House Create(House house)
        {
            return repository.Add(house);
        }

        [HttpPut("house")]
        public bool Update (House house)
        {
             return repository.Update(house);
        }

        [HttpDelete("house/{id}")]
        public void Remove (int Id)
        {
            repository.Remove(Id);
        }

    }
}
