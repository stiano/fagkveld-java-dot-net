namespace LekMedSpråket
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class G_Utvidelsesmetoder
    {
        [Test]
        public void KanKalleUtvidelsesMetode()
        {
            string t = null;

            "".NullEllerTom().Should().Be(true);
            t.NullEllerTom().Should().Be(true);
            
            "lang prosa tekst".NullEllerTom().Should().Be(false);
        }

    }

    /// <summary>
    /// Statisk metode i en statisk klasse hvor første parameter prefikses med 'this'. Dette blir da klassen som utvides.
    /// </summary>
    public static class StringUtvidelser
    {
        public static bool NullEllerTom(this string verdi)
        {
            return string.IsNullOrEmpty(verdi);
        }
    }
}