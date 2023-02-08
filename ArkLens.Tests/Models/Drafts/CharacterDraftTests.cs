using ArkLens.Models.Drafts;
using System.ComponentModel;

namespace ArkLens.Tests.Models.Drafts;

public class CharacterDraftTests
{
    [Fact]
    public void TestEvents()
    {
        CharacterDraft draft = new();

        draft.PropertyChanged += (s, e) =>
        {
            Assert.True(e.PropertyName is nameof(draft.Name));
        };

        draft.Name = "Test";
    }
}
