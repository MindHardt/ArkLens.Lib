using ArkLens.Core.Throws.Dice.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ArkLens.Core.Throws.Dice.Default;

public static class IServiceCollectionExtensions
{
	/// <summary>
	/// Adds scoped <see cref="DefaultDiceSet"/> to the <paramref name="collection"/>.
	/// If <paramref name="randomOverride"/> is <see langword="null"/> then
	/// <see cref="Random"/> method tries to inject it from service provider, otherwise
	/// <see cref="Random.Shared"/> is used.
	/// </summary>
	/// <param name="collection"></param>
	/// <param name="randomOverride">
	/// The <see cref="Random"/> object used for throws. 
	/// If none is provided then <see cref="Random.Shared"/> is used
	/// </param>
	/// <returns></returns>
	public static IServiceCollection AddDefaultDiceSet(
		this IServiceCollection collection,
		Random? randomOverride = null)
		=> collection.AddScoped<DiceSet>(provider 
			=> new DefaultDiceSet(randomOverride ?? provider.GetService<Random>()));
}
