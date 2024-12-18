using ItsmServices.Src.ObjectTypes.Domain;
using ItsmServices.Src.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItsmServices.Src.Users.Infrastructure.Persistence
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.ObjectTypeId)
                .HasColumnName("object_type_id")
                .IsRequired();

            builder.HasOne<ObjectType>()
               .WithMany()
               .HasForeignKey(e => e.ObjectTypeId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.Property(e => e.UserRightId)
                .HasColumnName("user_right_id")
                .IsRequired();

            builder.HasOne<ObjectType>()
               .WithMany()
               .HasForeignKey(e => e.UserRightId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(builder => builder.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            builder.Property(builder => builder.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

        }
    }
}
