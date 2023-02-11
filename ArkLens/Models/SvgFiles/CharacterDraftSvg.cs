using ArkLens.Models.Drafts;
using ArkLens.Properties;
using System.Text;

namespace ArkLens.Models.SvgFiles;

public partial class CharacterDraftSvg : DynamicSvg<CharacterDraft>
{
	public CharacterDraftSvg(CharacterDraft value, string? svg = default)
		: base(value, svg ?? Encoding.UTF8.GetString(Resources.CharacterFront))
	{
	}

	public static DynamicSvg<CharacterDraft> GetOrCreate(CharacterDraft draft)
		=> GetOrCreate(draft, d => new CharacterDraftSvg(d));

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
