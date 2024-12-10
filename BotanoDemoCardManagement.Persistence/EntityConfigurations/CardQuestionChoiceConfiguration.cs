using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BotanoDemoCardManagement.Persistence.EntityConfigurations;

public class CardQuestionChoiceConfiguration : IEntityTypeConfiguration<CardQuestionChoice>
{
    public void Configure(EntityTypeBuilder<CardQuestionChoice> builder)
    {
        builder.ToTable("CardQuestionChoices").HasKey(c => c.Id);
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Text).IsRequired();
        builder.Property(c => c.SortIndex).IsRequired();

        builder.HasOne(c => c.CardQuestion)
            .WithMany(q => q.Choices)
            .HasForeignKey(c => c.CardQuestionId);
    }
}