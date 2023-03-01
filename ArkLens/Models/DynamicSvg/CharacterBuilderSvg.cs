using ArkLens.Models.Builders;
using ArkLens.Properties;
using System.Text;

namespace ArkLens.Models.DynamicSvg;

public partial class CharacterBuilderSvg : DynamicSvg<CharacterBuilder>
{
	public CharacterBuilderSvg(CharacterBuilder value, string? svg = default)
		: base(value, svg ?? Encoding.UTF8.GetString(Resources.CharacterFront))
	{
	}

	public static DynamicSvg<CharacterBuilder> GetOrCreate(CharacterBuilder draft)
		=> GetOrCreate(draft, d => new CharacterBuilderSvg(d));

	protected override void MapActions()
	{
		MapHeader();
	}

	private void MapHeader()
	{
		string name = nameof(Value.Name);
		AddFillAction(name, d => d.Name);

		string race = nameof(Value.Race);
		AddFillAction(race, d => d.Race.Value?.ToString());

		string alignment = nameof(Value.Alignment);
		AddFillAction(alignment, d => d.Alignment.Value?.ToString());

		string sex = nameof(Value.Sex);
		AddFillAction(sex, d => d.Sex.Value?.ToString());
	}


}
