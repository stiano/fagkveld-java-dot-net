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

            "".NullEllerTom().Should().Be(false);
            t.NullEllerTom().Should().Be(false);
            "lang prosa tekst".NullEllerTom().Should().Be(true);
        }

        [Test]
        public void KanOgsåLagesMotEgneTyperellerInterfacer()
        {
            IDemo demo = new Demo(); // Kan naturligvis bruke var her også!
            var svar = demo.UtvidelsesMetode1("input");
            svar.Should().Be("returneres");
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

        // Andre eksempler på utvidelsesmetoder

        public static bool IkkeNullEllerTom(this string verdi)
        {
            return !string.IsNullOrEmpty(verdi);
        }

        public static string Right(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
        }

        public static string Left(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(0, length) : value;
        }
    }

    public static class DemoUtvidelser
    {
        public static string UtvidelsesMetode1(this IDemo demo, string verdi)
        {
            return verdi;
        }
    }

    public interface IDemo
    {
        // Tom
    }

    public class Demo : IDemo
    {
        // Tom
    }
}