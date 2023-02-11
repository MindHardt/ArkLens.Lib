using ArkLens.Core.CharacterDraftElement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArkLens.Models.Drafts;

public class CharacterDraftTypeConfiguration : IEntityTypeConfiguration<CharacterDraft>
{
	public void Configure(EntityTypeBuilder<CharacterDraft> builder)
	{
		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();
		builder
			.HasKey(x => x.Id);

		builder
			.HasIndex(x => x.Name)
			.IsUnique();

		builder
			.Property(x => x.Race)
			.HasConversion<CharacterDraftElementConverter<Races.Race>>()
			.IsRequired(false);
		builder
			.Property(x => x.Alignment)
			.HasConversion<CharacterDraftElementConverter<Alignments.Alignment>>()
			.IsRequired(false);
		builder
			.Property(x => x.Sex)
			.HasConversion<CharacterDraftElementConverter<Sex>>()
			.IsRequired(false);
	}
}
