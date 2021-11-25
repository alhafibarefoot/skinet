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
                    DisplayName = "A.Raheim Alhafi",
                    Email = "alhafi@alhafi.org",
                    UserName = "alhafi@alhafi.org",
                    Address = new Address
                    {
                        FirstName = "A.Raheim",
                        LastName = "Alhafi",
                        Street = "2004",
                        City = "Manama",
                        State = "BAH",
                        ZipCode = "50999"
                    }
                };

                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}