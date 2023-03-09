using ArkLens.Core;
using System.Reflection;

namespace ArkLens.Extensions;

/// <summary>
/// A class that contains all <see cref="ISingleton{TSelf}.Static"/> values.
/// </summary>
public static class SingletonHelper
{
	/// <summary>
	/// Contains all <see cref="ISingleton{TSelf}"/> values
	/// casted to <see cref="object"/>?.
	/// </summary>
	public static IList<object?> AllSingletons { get; }
		= GetSingletonValues();

	private static object?[] GetSingletonValues()
	{
		var prop = GetProperty().Name;
		var singletonTypes = GetSingletonTypes();
		return singletonTypes
			.Select(st => st.GetProperty(prop)!.GetValue(null))
			.ToArray();
	}
	private static PropertyInfo GetProperty() => typeof(ISingleton<>).GetProperties().Single();
	private static IEnumerable<Type> GetSingletonTypes() => Assembly.GetExecutingAssembly()
		.GetTypes()
		.Where(t => t.IsAssignableTo(typeof(ISingleton<>)));
}
