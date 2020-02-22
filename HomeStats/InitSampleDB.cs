using HomeStats.Models;
using System.Linq;

namespace HomeStats
{
    public static class InitSampleDB
    {
        public static void Initialize(Context context)
        {
            if(!context.Houses.Any())
            {
                House house = new House
                {
                    StreetName = "Groove Street",
                    HouseNumber = "228"
                };


                context.Houses.Add(house);

                context.SaveChanges();

                context.Counters.Add(
                    new Counter
                    {
                        IdHouse = house.IdHouse,
                        Serial = "AABB11",
                        Reading = 112233
                    }
                );

                context.SaveChanges();
            }

            
        }

    }
}
