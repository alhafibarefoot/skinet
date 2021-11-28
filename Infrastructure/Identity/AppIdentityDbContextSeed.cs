using System.Linq;
using System.Threading.Tasks;
using Core.Entities.identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Alhafi",
                    Email = "alhafi@test.com",
                    UserName = "alhafi@test.com",
                    Address = new Address
                    {
                        FirstName = "A.Raheim",
                        LastName = "Alhafi",
                        Street = "10 The street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "90210"
                    }
                };

                await userManager.CreateAsync(user, "P@$$w0rd");
            }
        }
    }
}