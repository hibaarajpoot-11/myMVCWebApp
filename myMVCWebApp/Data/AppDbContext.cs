using Microsoft.EntityFrameworkCore;
using myMVCWebApp.Models;

namespace myMVCWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) :DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
