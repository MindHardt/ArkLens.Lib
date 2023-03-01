using ArkLens.Abstractions;
using ArkLens.Models.Races;
using ArkLens.Models.Races.Common;
using System.Text.Json;

namespace ArkLens.Tests.Core;

public class CharacterDraftElementTests
{
	[Fact]
	public void AdjustTests()
	{
		ArklensBuilderElement<Race> draft = new();

		Assert.Null(draft.Name);
		Assert.Null(draft.Value);

		Race race = Dwarf.Value;
		draft.Name = race.Name;

		Assert.Equal(draft.Value, race);

		ArklensBuilderElement<Race> other = new()
		{
			Value = race
		};

		Assert.Equal(other.Name, race.Name);
		Assert.Equal(draft, other);
	}

	[Fact]
	public void JsonTests()
	{
		ArklensBuilderElement<Race> draft = new()
		{
			Value = Dwarf.Value,
		};

		string json = JsonSerializer.Serialize(draft);
		var deserialized = JsonSerializer.Deserialize<ArklensBuilderElement<Race>>(json);

		Assert.Equal(draft, deserialized);
		// CharacterDraftElements are serialized by names so they must not contain emoji
		Assert.DoesNotContain(draft.Value.Emoji, json);
	}

	[Fact]
	public void StringCastTests()
	{
		Race race = Dwarf.Value;

		ArklensBuilderElement<Race> draft = race.Name;

		Assert.NotNull(draft);
		Assert.Equal(race.Name, draft.Name);
		Assert.Equal(race, draft.Value);
	}
}
