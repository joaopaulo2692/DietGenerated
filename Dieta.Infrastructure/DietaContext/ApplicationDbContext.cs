﻿
using AutoMapper;
using Dieta.Core.Entities;
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
        public DbSet<FoodsMeal> FoodsMeal { get; set; }
        public DbSet<TotalDiet> TotalDiets { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


            modelBuilder.Entity<Diet>()
              .HasMany(x => x.Meals) // Dieta has many Refeicoes
              .WithMany(x => x.Diets);   // Refeicao has many Dietas (optional, depending on your needs)

            //modelBuilder.Entity<ApplicationUser>()
            //  .HasMany(c => c.Diets)       
            //  .WithMany(d => d.Client)    
            //  .UsingEntity<Dictionary<string, object>>(  
            //      "ClienteDiet",
            //      j => j
            //          .HasOne<Diet>()
            //          .WithMany()
            //          .HasForeignKey("DietId")
            //          .HasConstraintName("FK_ClienteDiet_Dietas_DietId"),
            //      j => j
            //          .HasOne<ApplicationUser>()
            //          .WithMany()
            //          .HasForeignKey("Id")
            //          .HasConstraintName("FK_ClienteDiet_Clientes_ClienteId")
            //  );

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Diets)
                .WithMany(d => d.Client)
                .UsingEntity(j => j.ToTable("ClientDiet"));

            modelBuilder.Entity<FoodsMeal>()
                .HasKey(fm => fm.FoodsMealId);

            modelBuilder.Entity<FoodsMeal>()
             .HasOne(x => x.Food)
             .WithMany(x => x.FoodsMeals)
             .HasForeignKey(x => x.FoodsId);


            modelBuilder.Entity<FoodsMeal>()
              .HasOne(x => x.Meal)
              .WithMany(x => x.FoodsMeals)
              .HasForeignKey(x => x.MealsId)
              .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<TotalDiet>()
                .HasOne(x => x.Diet)
                .WithOne(x => x.TotalDiet)
                .HasForeignKey<TotalDiet>(p => p.DietId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
