using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Configurattions
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("UserId");
            builder.Property(x => x.CreatedDate).HasColumnName("CreateTime");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.UserName).HasColumnName("UserName");
            builder.Property(x => x.Password).HasColumnName("Password");


            builder
                .HasMany(x => x.Posts)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Comments)
                .WithOne(X => X.User)
                .HasForeignKey(X => X.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
