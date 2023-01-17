using ArkLens.Models.Races;
using ArkLens.Models.Races.Common;
using System.Linq;

namespace ArkLens.Tests.Models.Races;

public class RaceTests
{
	[Fact]
	public void EnumerationTests()
	{
		Assert.NotNull(Race.PossibleValues);
		Assert.Contains(Human.Value, Race.PossibleValues);
		Assert.Contains(Elf.Value, Race.PossibleValues);
		Assert.Contains(Dwarf.Value, Race.PossibleValues);
		Assert.Contains(Kitsune.Value, Race.PossibleValues);
		Assert.Contains(Minas.Value, Race.PossibleValues);
		Assert.Contains(Serpent.Value, Race.PossibleValues);
	}

	[Fact]
	public void InfluencesTest()
	{
		Assert.Null(Human.Value.StatInfluence);
		foreach (Race race in Race.PossibleValues.Except(new[] { Human.Value }))
		{
			Assert.NotNull(race.StatInfluence);
		}
	}
}
