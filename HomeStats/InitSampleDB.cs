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
                House house1 = new House
                {
                    StreetName = "Groove Street",
                    HouseNumber = "228"
                };

                House house2 = new House
                {
                    StreetName = "Church Street",
                    HouseNumber = "666"
                };

                context.Houses.Add(house1);
                context.Houses.Add(house2);

                context.SaveChanges();

                context.Counters.AddRange(
                    new Counter
                    {
                        IdHouse = house1.IdHouse,
                        Serial = "AABB11",
                        Reading = 112233
                    },
                    new Counter
                    {
                        IdHouse = house1.IdHouse,
                        Serial = "BBCC22",
                        Reading = 554466
                    },
                    new Counter
                    {
                        IdHouse = house2.IdHouse,
                        Serial = "GGFF55",
                        Reading = 67487
                    }
                );

                context.SaveChanges();
            }

            
        }

    }
}
