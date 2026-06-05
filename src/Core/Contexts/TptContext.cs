using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Contexts;

public class TptContext : DbContext
{
    public TptContext(DbContextOptions<TptContext> options) : base(options) 
    { 
        
    }

    private const string defaultSchema = "dbo";

    public DbSet<Inquiry> Inquiries { get; set; }
    public DbSet<PersonalMedicalInquiry> PersonalMedicalInquiries { get; set; }
    public DbSet<CompanyMedicalInquiry> CompanyMedicalInquiries { get; set; }
    public DbSet<PersonalFinancalInquiry> PersonalFinancalInquiries { get; set; }
    public DbSet<CompanyFinancalInquiry> CompanyFinancalInquiries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inquiry>(entity =>
        {
            entity.ToTable("Inquiries", defaultSchema);
            entity.HasKey(i => i.Id);
        });

        modelBuilder.Entity<PersonalMedicalInquiry>(entity =>
        {
            entity.ToTable("PersonalMedicalInquiries", defaultSchema);
            entity.HasOne<Inquiry>().WithOne().HasForeignKey<PersonalMedicalInquiry>(m => m.Id).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CompanyMedicalInquiry>(entity =>
        {
            entity.ToTable("CompanyMedicalInquiries", defaultSchema);
            entity.HasOne<Inquiry>().WithOne().HasForeignKey<CompanyMedicalInquiry>(m => m.Id).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PersonalFinancalInquiry>(entity =>
        {
            entity.ToTable("PersonalFinancalInquiries", defaultSchema);
            entity.HasOne<Inquiry>().WithOne().HasForeignKey<PersonalFinancalInquiry>(m => m.Id).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CompanyFinancalInquiry>(entity =>
        {
            entity.ToTable("CompanyFinancalInquiries", defaultSchema);
            entity.HasOne<Inquiry>().WithOne().HasForeignKey<CompanyFinancalInquiry>(m => m.Id).OnDelete(DeleteBehavior.Cascade);
        });
    }
}

public abstract class Inquiry
{
    public required Guid Id { get; set; }
    public required int Status { get; set; }
    public required DateTime LastModifiedAt { get; set; }
    
    // derived display prop.
    public abstract string DisplayName { get; }
}

public class PersonalMedicalInquiry : Inquiry, IPersonalInquiry
{
    public required Guid PersonId { get; set; }
    public required string Titel { get; set; }
    public override string DisplayName { get { return Titel; }}
}

public class CompanyMedicalInquiry : Inquiry
{
    public required Guid CompanyId { get; set; }
    public required string Company { get; set; }
    public required string Titel { get; set; }
    public override string DisplayName { get { return $"{Company} - {Titel}"; }}
}

public class PersonalFinancalInquiry : Inquiry, IPersonalInquiry
{
    public required Guid PersonId { get; set; }
    public required string Titel { get; set; }
    public override string DisplayName { get { return Titel; } }
}

public class CompanyFinancalInquiry : Inquiry
{
    public required Guid CompanyId { get; set; }
    public required string Company { get; set; }
    public required string Titel { get; set; }
    public override string DisplayName { get { return $"{Company} - {Titel}"; } }
}
