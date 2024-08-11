using Football.Data;
using Football.Model;

namespace Football
{
    public static class DbInitializer
    {
        public static void Initialize(FootballContext context)
        {
            context.Database.EnsureCreated();

            // Check if the database is empty
            if (context.Clubs.Any())
            {
                return; // DB has been seeded
            }

            var clubs = new Club[]
            {
            new Club { ClubName = "Arsenal" },
            new Club { ClubName = "Chelsea" }
            };

            foreach (var c in clubs)
            {
                context.Clubs.Add(c);
            }
            context.SaveChanges();
        }
    }
}
