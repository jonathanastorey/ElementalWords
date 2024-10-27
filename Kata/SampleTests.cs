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
            //("hop", new[] { new[] { "Beryllium (Be)", "Actinium (Ac)", "Hydrogen (H)" } }),
            //("", new string[0][]),
            //("Yes", new[] { new[] { "Yttrium (Y)", "Einsteinium (Es)" } }),
            //("beach", new[] { new[] { "Beryllium (Be)", "Actinium (Ac)", "Hydrogen (H)" } }),
            
            
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

    [Test]
    public void SimpleCases2()
    {
        var work = "hop";
        Console.WriteLine(work[1..1]);
        
        
    }
}
