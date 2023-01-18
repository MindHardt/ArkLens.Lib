using ArkLens.Models.Alignments;

namespace ArkLens.Tests.Models.Alignments;

public class AlignmentTests
{
	[Fact]
	public void DistanceTests()
	{
		int one = Alignment.Neutral.DistanceTo(Alignment.NeutralGood);
		Assert.Equal(1, one);

		int zero = Alignment.LawfulEvil.DistanceTo(Alignment.LawfulEvil);
		Assert.Equal(0, zero);
	}
}
