using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BotanoDemoCardManagement.Persistence.EntityConfigurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards").HasKey(c => c.Id);
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CardName).IsRequired();
        builder.Property(c => c.ImageUrl);
        builder.Property(c => c.Description);
        builder.Property(c => c.Status).IsRequired();

        builder.HasOne(c => c.CardType)
            .WithMany(ct => ct.Cards)
            .HasForeignKey(c => c.CardTypeId);

        builder.HasMany(c => c.Questions)
            .WithOne(q => q.Card)
            .HasForeignKey(q => q.CardId);

        builder.HasMany(c => c.UserCardAnswers)
            .WithOne(uca => uca.Card)
            .HasForeignKey(uca => uca.CardId);
    }
}

