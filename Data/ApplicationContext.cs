using Microsoft.EntityFrameworkCore;

namespace SchoolManagementD.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {    
        }
    }
}
