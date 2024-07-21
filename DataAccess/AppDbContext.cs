using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Task = DataAccess.Entities.Task;

namespace DataAccess;

public class AppDbContext: DbContext
{
    public DbSet<Task> Tasks = null!;
    public DbSet<Status> Statuses = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasOne(t => t.Status)
            .WithMany(st => st.Tasks)
            .HasForeignKey("StatusId")
            .IsRequired();
    }
}