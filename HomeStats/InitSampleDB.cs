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
                context.Houses.Add(
                    new House
                    {
                        StreetName = "Groove Street",
                        HouseNumber = "228",
                        Serial = "AABB11",
                        Reading = 112233
                    }
                );
            }

            context.SaveChanges();
        }

    }
}
