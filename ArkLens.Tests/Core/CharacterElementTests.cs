using ArkLens.Core;

namespace ArkLens.Tests.Core;

public class CharacterElementTests
{
	[Fact]
	public void EqualityTests()
	{
		CharacterElement one = new CharacterElementTest("1", "one");
		CharacterElement alsoOne = new CharacterElementTest("1", "one");
		CharacterElement two = new CharacterElementTest("2", "two");

		Assert.True(one == alsoOne);
		Assert.True(one.GetHashCode() == alsoOne.GetHashCode());
		Assert.False(one == two);
		Assert.False(one == null);
	}

	private class CharacterElementTest : CharacterElement
	{
		internal CharacterElementTest(string emoji, string name) : base(emoji, name)
		{
		}
	}
}
