using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Task = DataAccess.Entities.Task;

namespace DataAccess;

public class AppDbContext: DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Persist Security Info=False;Trusted_Connection=True;TrustServerCertificate=True;Initial Catalog=ToDoListDB;Data Source=LAPTOP-373K3L6J\\SQLEXPRESS;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasOne(t => t.Status)
            .WithMany(st => st.Tasks)
            .HasForeignKey("StatusId")
            .IsRequired();
    }
}