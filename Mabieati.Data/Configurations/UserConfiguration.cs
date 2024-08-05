using Mabieati.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mabieati.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FullName).HasMaxLength(20).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(20).IsRequired();
            builder.Property<string>("Password").IsRequired();

            builder.HasData(new[]
            {
                new {Id = 1, UserName = "admin", FullName = "admin", Password = "admin"}
            } );
        }
    }
}
