using Microsoft.EntityFrameworkCore;
using riwiwi.Models;

namespace riwiwi.data;

public class MysqlDbContext : DbContext
{
    public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
    {
        
    } 
    
    public DbSet<dashboard> dashboard { get; set; }
}