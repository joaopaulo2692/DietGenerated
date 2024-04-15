using Blazor_MestreDetalhes.Data;
using Microsoft.EntityFrameworkCore;

namespace Blazor_API.Data
{
    public class DietaContext2: DbContext
    {
        public DietaContext2(DbContextOptions<DietaContext2> opts) 
            :base(opts)
        {
            
        }

        public DbSet<Diet> Dietas { get; set; }

        public DbSet<Alimentos> Alimentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dieta>()
                .HasMany(a => a.Refeicao1)
                .WithOne(a => a.Dieta);
               

         

            base.OnModelCreating(modelBuilder);





        }

    }
}
