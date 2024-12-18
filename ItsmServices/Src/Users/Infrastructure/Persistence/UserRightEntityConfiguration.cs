using ItsmServices.Src.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItsmServices.Src.Users.Infrastructure.Persistence
{
    public class UserRightEntityConfiguration : IEntityTypeConfiguration<UserRight>
    {
        public void Configure(EntityTypeBuilder<UserRight> builder)
        {
            builder.ToTable("user_right");
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Value)
                .HasColumnName("value")
                .IsRequired();

        }
    }
}
