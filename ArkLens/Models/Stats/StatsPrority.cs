namespace ArkLens.Models.Stats;

/// <summary>
/// Contains all stats ordered from best to worst 
/// for specific <see cref="Classes.Class"/>.
/// </summary>
public class StatsPrority
{
	private readonly Type[] _types;
	public IReadOnlyList<Type> Types => _types;

	/// <summary>
	/// Gets the zero-based priority of <paramref name="stat"/>.
	/// Lower value means higher priority.
	/// </summary>
	/// <param name="stat"></param>
	/// <returns></returns>
	public int PriorityOf(Stat stat)
		=> Array.IndexOf(_types, stat);

	public StatsPrority(params Stat[] stats)
		=> _types = stats.Select(s => s.GetType()).ToArray();
	private StatsPrority(Type[] types) 
		=> _types = types;

	/// <summary>
	/// A generic variant of <see cref="StatsPrority(Stat[])"/>.
	/// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <returns></returns>
	public static StatsPrority Create<T1, T2, T3, T4, T5, T6>()
		where T1 : Stat
		where T2 : Stat
		where T3 : Stat
		where T4 : Stat
		where T5 : Stat
		where T6 : Stat
	=> new(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), });

}
