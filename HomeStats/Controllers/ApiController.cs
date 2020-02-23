using HomeStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        [HttpGet]
        public IEnumerable<House> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public House Get(int Id)
        {
            return repository.Get(Id);
        }       
        
        [HttpPost]
        public House CreateHouse([FromBody]House house)
        {
               return repository.Add(house);
        }

        [HttpPut]
        public bool UpdateHouse (House house)
        {
             return repository.Update(house);
        }

        [HttpDelete("{id}")]
        public void RemoveHouse (int Id)
        {
            repository.Remove(Id);
        }

    }
}
