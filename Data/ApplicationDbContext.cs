using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCCoreIdentityDemo.Data
{
    //Create and run the migrations
    //Code first approach to generate tables for Identity
    //Inherit from IdentityDbContext
    //Create this class in Data folder
    //Go to Package Manager Console and run the following commands:
    // Add-Migration InitialCreate
    // Update-Database
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
