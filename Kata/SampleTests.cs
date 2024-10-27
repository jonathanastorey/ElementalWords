using NUnit.Framework;

namespace Kata;

[TestFixture]
class SampleTests
{
    [Test]
    public void SimpleCases()
    {
        var cases = new[]
        {
            ("", new string[0][]),
            ("hop", new[]
            {
                new[] { "Hydrogen (H)", "Oxygen (O)", "Phosphorus (P)" },
                new [] { "Holmium (Ho)", "Phosphorus (P)"}
            }),
            ("Yes", new[] { new[] { "Yttrium (Y)", "Einsteinium (Es)" } }),
            ("beach", new[] { new[] { "Beryllium (Be)", "Actinium (Ac)", "Hydrogen (H)" } }),
            ("snack", new[]
            {
                new[] { "Sulfur (S)", "Nitrogen (N)", "Actinium (Ac)", "Potassium (K)" },
                new[] { "Sulfur (S)", "Sodium (Na)", "Carbon (C)", "Potassium (K)" },
                new[] { "Tin (Sn)", "Actinium (Ac)", "Potassium (K)" }
            }),
        };
        foreach (var (word, expected) in cases)
        {
            var actual = ElementalWords.ElementalForms(word);
            Assert.That(actual, Is.EquivalentTo(expected), $"Unexpected result for word: {word}");
        }
    }
}
