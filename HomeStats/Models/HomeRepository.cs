using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HomeStats.Models
{
    public class HouseRepository
    {
        public Context db;

        public static HouseRepository Current { get; } = new HouseRepository();

        public IEnumerable<House> GetAll()
        {
            return db.Houses.Include(x=>x.Counters).Select(x => x).ToList();
        }

        public House Get(int Id)
        {
            return db.Houses.Include(x => x.Counters).Where(x => x.IdHouse == Id).FirstOrDefault();
        }

        public House Add(House house)
        {
            db.Houses.Add(house);
            db.SaveChanges();
            return house;
        }

        public void Remove(int id)
        {
            House house = Get(id);

            if (house != null)
            {
                db.Remove(house);
                db.SaveChanges();
            }
        }

        public bool Update(House house)
        {
            House currenthouse = Get(house.IdHouse);
            if (currenthouse != null)
            {
                db.Update(house);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
