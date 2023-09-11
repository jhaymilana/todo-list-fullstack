using Microsoft.EntityFrameworkCore;
using MVC_Final_Project.Models;

namespace MVC_Final_Project.Data
{
    public class MVCFinalDbContext : DbContext
    {
        public MVCFinalDbContext(DbContextOptions<MVCFinalDbContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Final_Project.Models.List> List { get; set; } = default!;
        public DbSet<MVC_Final_Project.Models.Task> Task { get; set; } = default!;
    }
}