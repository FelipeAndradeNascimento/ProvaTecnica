using Microsoft.EntityFrameworkCore;
using WebMvcMysql.Models;

namespace WebMvcMysql.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        { }

        public DbSet<Caminhao> Caminhao { get; set; }

    }
}
