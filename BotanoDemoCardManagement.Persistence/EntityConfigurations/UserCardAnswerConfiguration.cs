using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BotanoDemoCardManagement.Persistence.EntityConfigurations;

public class UserCardAnswerConfiguration : IEntityTypeConfiguration<UserCardAnswer>
{
    public void Configure(EntityTypeBuilder<UserCardAnswer> builder)
    {
        builder.ToTable("UserCardAnswers").HasKey(_answer => _answer.Id);
        builder.Property(_answer => _answer.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(_answer => _answer.Id).HasColumnName("Id").IsRequired();

        builder.Property(_answer => _answer.UserId).IsRequired();
        builder.Property(_answer => _answer.CardId).IsRequired();
        builder.Property(_answer => _answer.CardQuestionId).IsRequired();
        builder.Property(_answer => _answer.CardQuestionChoiceId).IsRequired();
       
        builder.HasOne(_answer => _answer.User)
               .WithMany(_user => _user.UserCardAnswers)
               .HasForeignKey(_answer => _answer.UserId)
               .OnDelete(DeleteBehavior.Cascade);
       
        builder.HasOne(_answer => _answer.Card)
               .WithMany()
               .HasForeignKey(_answer => _answer.CardId)
               .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(_answer => _answer.CardQuestion)
               .WithMany()
               .HasForeignKey(_answer => _answer.CardQuestionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(_answer => _answer.CardQuestionChoice)
               .WithMany()
               .HasForeignKey(_answer => _answer.CardQuestionChoiceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}