using ArkLens.Core;
using System.Reflection;

namespace ArkLens.Extensions;

public static class SingletonHelper
{
	public static IList<object?> AllSingletons { get; }
		= GetSingletonValues();

	private static object?[] GetSingletonValues()
	{
		var prop = GetProperty().Name;
		var singletonTypes = GetSingletonTypes();
		return singletonTypes.Select(st => st.GetProperty(prop)!.GetValue(null)).ToArray();
	}
	private static PropertyInfo GetProperty() => typeof(ISingleton<>).GetProperties().Single();
	private static IEnumerable<Type> GetSingletonTypes() => Assembly.GetExecutingAssembly()
		.GetTypes()
		.Where(t => t.IsAssignableTo(typeof(ISingleton<>)));
}
