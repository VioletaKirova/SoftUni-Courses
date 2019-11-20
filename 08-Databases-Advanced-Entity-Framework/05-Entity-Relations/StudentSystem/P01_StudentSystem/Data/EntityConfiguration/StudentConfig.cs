namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)");

            builder.Property(s => s.RegisteredOn)
                .IsRequired();

            builder.HasMany(s => s.CourseEnrollments)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);
        }
    }
}
