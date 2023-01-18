using ArkLens.Core;
using ArkLens.Models.Races.Common;
using System.Reflection;

namespace ArkLens.Models.Races;

public abstract class Race : CharacterElement, ICharacterElementEnumeration<Race>
{
	protected Race(string emoji, string name) : base(emoji, name)
	{
	}

	/// <summary>
	/// Contains all possible <see cref="Race"/>s
	/// </summary>
	public static IReadOnlyList<Race> PossibleValues { get; } = GetAllRaces();


	/// <summary>
	/// Gets <see cref="RaceStatInfluence"/> of this <see cref="Race"/> or 
	/// <see langword="null"/> if other behavior is expected.
	/// </summary>
	public abstract RaceStatInfluence? StatInfluence { get; }

	private static Race[] GetAllRaces()
		=> Assembly.GetAssembly(typeof(Race))!
			.GetTypes()
			.Where(t => t.IsAssignableTo(typeof(Race)) && !t.IsAbstract)
			.Select(t => t.GetProperty(nameof(ISingleton<Human>.Value))!)
			.Select(p => (Race)p.GetValue(null)!)
			.ToArray();
}
