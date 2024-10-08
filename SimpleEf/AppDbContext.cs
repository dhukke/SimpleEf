using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleEf;

public sealed class AppDbContext : DbContext
{
    internal DbSet<Detail> Details { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DetailConfiguration());
    }
}

public class Detail
{ 
    public Guid Id { get; set; }
    public string? Description { get; set; }

    protected Detail()
    {
    }

    public Detail(Guid id, string? description)
    {
        Id = id;
        Description = description;
    }
}

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        builder.ToTable("detail");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Description).HasMaxLength(2000);
    }
}
