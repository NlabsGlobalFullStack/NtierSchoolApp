using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.DataAccess.Context;
public sealed class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<StudentClassRoom> StudentClassRooms { get; set; }
    public DbSet<StudentLesson> StudentLessons { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherAddress> TeacherAddresses { get; set; }
    public DbSet<TeacherClassRoom> TeacherClassRooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasQueryFilter(filter => !filter.IsDeleted);
        modelBuilder.Entity<ClassRoom>().HasQueryFilter(filter => !filter.IsDeleted);

        modelBuilder.Entity<StudentClassRoom>()
            .HasKey(scr => new { scr.StudentId, scr.ClassRoomId });
        modelBuilder.Entity<TeacherClassRoom>()
            .HasKey(tcr => new { tcr.TeacherId, tcr.ClassRoomId });

        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
        modelBuilder.Ignore<IdentityUserRole<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();
        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityRole<Guid>>();
    }
}
