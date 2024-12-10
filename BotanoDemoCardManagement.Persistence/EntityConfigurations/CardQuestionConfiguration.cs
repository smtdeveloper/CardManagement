using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BotanoDemoCardManagement.Persistence.EntityConfigurations;
public class CardQuestionConfiguration : IEntityTypeConfiguration<CardQuestion>
{
    public void Configure(EntityTypeBuilder<CardQuestion> builder)
    {
        builder.ToTable("CardQuestions").HasKey(c => c.Id);
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(q => q.Text).IsRequired();
        builder.Property(q => q.SortIndex).IsRequired();

        builder.HasOne(q => q.Card)
            .WithMany(c => c.Questions)
            .HasForeignKey(q => q.CardId);

        builder.HasMany(q => q.Choices)
            .WithOne(c => c.CardQuestion)
            .HasForeignKey(c => c.CardQuestionId);
    }
}