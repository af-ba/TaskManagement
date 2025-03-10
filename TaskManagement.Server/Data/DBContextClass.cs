using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagement.Server.Models;

namespace TaskManagement.Server.Data
{
    public class DBContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DBContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<TaskModel> Tasks
        {
            get;
            set;
        }

        public DbSet<UserRegistrationModel> UserRegistrations
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure the task table
            modelBuilder.Entity<TaskModel>().ToTable("Tasks");

            modelBuilder.Entity<TaskModel>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<TaskModel>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<TaskModel>()
                .Property(b => b.Description);

            modelBuilder.Entity<TaskModel>()
            .Property(b => b.DueDate);

            modelBuilder.Entity<TaskModel>()
                .Property(b => b.IsCompleted);

            modelBuilder.Entity<TaskModel>()
                .HasOne(b => b.UserRegistration)
                .WithMany(p => p.Tasks)
                .HasForeignKey(b => b.UserId)
                .IsRequired();



            //Configure the user registration table
            modelBuilder.Entity<UserRegistrationModel>().ToTable("UserRegistrations");

            modelBuilder.Entity<UserRegistrationModel>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<UserRegistrationModel>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<UserRegistrationModel>()
                .Property(b => b.RegistrationDate);
        }



    }
}
