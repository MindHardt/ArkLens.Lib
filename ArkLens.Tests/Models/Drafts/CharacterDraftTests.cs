using ArkLens.Models.Builders;
using System.ComponentModel;

namespace ArkLens.Tests.Models.Drafts;

public class CharacterDraftTests
{
    [Fact]
    public void TestEvents()
    {
        CharacterBuilder draft = new();

        draft.PropertyChanged += (s, e) =>
        {
            Assert.True(e.PropertyName is nameof(draft.Name));
        };

        draft.Name = "Test";
    }
}
