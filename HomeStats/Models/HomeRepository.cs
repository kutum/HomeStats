using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeStats.Models
{
    public class HouseRepository
    {
        public Context db;

        public static HouseRepository Current { get; } = new HouseRepository();

        public async Task<IEnumerable<House>> GetAllHouses()
        {
            return await db.Houses.Include(x=>x.Counters).Select(x => x).ToListAsync();
        }

        public async Task<House> GetHouse(int Id)
        {
            return await db.Houses.AsNoTracking().Include(x => x.Counters).Where(x => x.IdHouse == Id).FirstOrDefaultAsync();
        }

        public async Task<Counter> GetCounter(int Id)
        {
            return await db.Counters.AsNoTracking().Where(x => x.IdCounter == Id).FirstOrDefaultAsync();
        }

        public async Task<House> GetMaxHouse()
        {
            var IdHouse = await db.Counters.MaxAsync(x => x.Reading);

            return await db.Houses.Where(x => x.IdHouse == IdHouse).FirstOrDefaultAsync();
        }

        public async Task<House> GetMinHouse()
        {
            var IdHouse = await db.Counters.MinAsync(x => x.Reading);

            return await db.Houses.Where(x => x.IdHouse == x.Counters.Max(y => y.Reading)).FirstOrDefaultAsync();
        }

        public async Task<House> AddHouseAsync(House house)
        {
            await db.Houses.AddAsync(house);
            await db.SaveChangesAsync();

            return house;
        }

        public async Task<Counter> AddCounterAsync(Counter counter)
        {
            await db.Counters.AddAsync(counter);
            await db.SaveChangesAsync();

            return counter;
        }

        public async Task RemoveHouseAsync(int id)
        {
            House house = await GetHouse(id);

            if (house != null)
            {
                db.Remove(house);
                await db.SaveChangesAsync();
            }
        }

        public async Task RemoveCounterAsync(int id)
        {
            Counter counter = await GetCounter(id);

            if(counter != null)
            {
                db.Remove(counter);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateHouseAsync(House house)
        {
            House currenthouse = await GetHouse(house.IdHouse);

            house.Counters = currenthouse.Counters;
            if (currenthouse != null)
            {
                db.Update(house);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateCounterAsync(Counter counter)
        {
            Counter currentcounter = await GetCounter(counter.IdCounter);

            if (currentcounter != null)
            {
                db.Update(counter);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
