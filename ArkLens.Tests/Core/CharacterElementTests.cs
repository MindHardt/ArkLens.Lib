using ArkLens.Core;

namespace ArkLens.Tests.Core;

public class CharacterElementTests
{
	[Fact]
	public void EqualityTests()
	{
		ArklensElement one = new CharacterElementTest("1", "one");
		ArklensElement alsoOne = new CharacterElementTest("1", "one");
		ArklensElement two = new CharacterElementTest("2", "two");

		Assert.True(one == alsoOne);
		Assert.True(one.GetHashCode() == alsoOne.GetHashCode());
		Assert.False(one == two);
		Assert.False(one == null);
	}

	private class CharacterElementTest : ArklensElement
	{
		internal CharacterElementTest(string emoji, string name) : base(emoji, name)
		{
		}
	}
}
