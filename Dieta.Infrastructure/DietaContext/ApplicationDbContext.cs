﻿
using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dieta.Infrastructure.DietaContext

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Meal> Meals { get; set; }
        //public DbSet<Client> Clientes { get; set; }

        public DbSet<FoodsMeal> FoodsMeal { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);




            //modelBuilder.Entity<Diet>()
            //   .HasMany(x => x.Refeicoes)
            //   .WithMany(x => x.Dieta);


            //modelBuilder.Entity<Cliente>()
            //    .HasMany(c => c.Dieta)
            //    .WithMany(d => d.Cliente)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "ClienteDiet",
            //        j => j
            //            .HasOne<Diet>()
            //            .WithMany()
            //            .HasForeignKey("DietId")
            //            .HasConstraintName("FK_ClienteDiet_Dietas_DietId"),
            //        j => j
            //            .HasOne<Cliente>()
            //            .WithMany()
            //            .HasForeignKey("ClienteId")
            //            .HasConstraintName("FK_ClienteDiet_Clientes_ClienteId")
            //    );


            //modelBuilder.Entity<Diet>()
            //    .HasMany(x => x.Cliente)                
            //    .WithMany(x => x.Dieta);


            //modelBuilder.Entity<Refeicao>()
            //    .HasMany(x => x.Alimentos)
            //    .WithMany(x => x.Refeicao);


            //modelBuilder.Entity<Alimentos>()
            //    .HasMany(x => x.Refeicao)
            //    .WithMany(x => x.Alimentos);



            //modelBuilder.Entity<AlimentosRefeicao>()
            //    .HasKey(x => new { x.AlimentosId, x.RefeicaoId });




            ////////////////////////////////////////////////////////////////////////


            //modelBuilder.Entity<Diet>()
            //   .HasMany(x => x.Refeicoes)
            //   .WithMany(x => x.Dieta);


            //modelBuilder.Entity<Cliente>()
            //    .HasMany(c => c.Dieta)
            //    .WithMany(d => d.Cliente)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "ClienteDiet",
            //        j => j
            //            .HasOne<Diet>()
            //            .WithMany()
            //            .HasForeignKey("DietId")
            //            .HasConstraintName("FK_ClienteDiet_Dietas_DietId"),
            //        j => j
            //            .HasOne<Cliente>()
            //            .WithMany()
            //            .HasForeignKey("ClienteId")
            //            .HasConstraintName("FK_ClienteDiet_Clientes_ClienteId")
            //    );


            //modelBuilder.Entity<AlimentosRefeicao>()
            //  .HasOne(x => x.Refeicao)
            //  .WithMany(x => x.AlimentosRefeicoes)
            //  .HasForeignKey(x => x.RefeicaoId);

            //modelBuilder.Entity<AlimentosRefeicao>()
            //  .HasOne(x => x.Alimento)
            //  .WithMany(x => x.AlimentosRefeicoes)
            //  .HasForeignKey(x => x.AlimentosId);

            //modelBuilder.Entity<AlimentosRefeicao>()
            //    .HasKey(x => new { x.AlimentosId, x.RefeicaoId });

            modelBuilder.Entity<Diet>()
  .HasMany(x => x.Meals) // Dieta has many Refeicoes
  .WithMany(x => x.Diets);   // Refeicao has many Dietas (optional, depending on your needs)

            modelBuilder.Entity<ApplicationUser>()
              .HasMany(c => c.Diets)       
              .WithMany(d => d.Client)    
              .UsingEntity<Dictionary<string, object>>(  
                  "ClienteDiet",
                  j => j
                      .HasOne<Diet>()
                      .WithMany()
                      .HasForeignKey("DietId")
                      .HasConstraintName("FK_ClienteDiet_Dietas_DietId"),
                  j => j
                      .HasOne<ApplicationUser>()
                      .WithMany()
                      .HasForeignKey("Id")
                      .HasConstraintName("FK_ClienteDiet_Clientes_ClienteId")
              );

            modelBuilder.Entity<FoodsMeal>()  // Define AlimentosRefeicao entity
              .HasKey(x => new { x.FoodId, x.MealId }); // Composite key

            modelBuilder.Entity<FoodsMeal>()
              .HasOne(x => x.Food)
              .WithMany(x => x.FoodsMeals)
              .HasForeignKey(x => x.FoodId);
              

            modelBuilder.Entity<FoodsMeal>()
              .HasOne(x => x.Meal)
              .WithMany(x => x.FoodsMeals)
              .HasForeignKey(x => x.MealId);


           
                

        }
    }
}