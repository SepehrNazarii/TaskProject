using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Entities;



namespace TaskProject.DataLayer.DataContext
{
    public class TaskDataContext : DbContext
    {
        #region Ctor
        public TaskDataContext(DbContextOptions<TaskDataContext> option) : base(option)
        {
            
        }
        #endregion

        #region DbSet
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        #endregion

        #region SeedData
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Degrees
            modelBuilder.Entity<Domain.Entities.Task>().HasData(
                new Domain.Entities.Task 
                { 
                    ID = Guid.NewGuid(),
                    Title = "FirstTask",
                    Description = "First Task Description",
                    IsComplited = false,
                    DueDate = DateTime.Now,
                },
                 new Domain.Entities.Task
                 {
                     ID = Guid.NewGuid(),
                     Title = "SecondTask",
                     Description = "Second Task Description",
                     IsComplited = false,
                     DueDate = DateTime.Now
                 },
                  new Domain.Entities.Task
                  {
                      ID = Guid.NewGuid(),
                      Title = "ThirdTask",
                      Description = "third Task Description",
                      IsComplited = false,
                      DueDate = DateTime.Now
                  }

            );
        }
        #endregion
    }
}
