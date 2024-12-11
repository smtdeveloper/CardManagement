using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BotanoDemoCardManagement.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(_user => _user.Id);
        builder.Property(_user => _user.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(_user => _user.Id).HasColumnName("Id").IsRequired();
        builder.Property(_user => _user.Username).IsRequired();
        builder.Property(_user => _user.Email).IsRequired();
        builder.Property(_user => _user.PasswordHash).IsRequired();

        builder.HasMany(_user => _user.UserCardAnswers)
               .WithOne(_userAnswer => _userAnswer.User)
               .HasForeignKey(_userAnswer => _userAnswer.UserId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}