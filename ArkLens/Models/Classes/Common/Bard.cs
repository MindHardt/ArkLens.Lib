using ArkLens.Models.Stats;
using ArkLens.Models.Stats.Primary;

namespace ArkLens.Models.Classes.Common;

public class Bard : Class
{
	public Bard()
		: base("🪕", "Бард")
	{
	}

	public override int HpGain => 8;

	public override int SkillPoints => 5;

	public override StatsPrority StatsPrority { get; } =
		StatsPrority.Create<Charisma, Dexterity, Intelligence, Wisdom, Constitution, Strength>();
}
