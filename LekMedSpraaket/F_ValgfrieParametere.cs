namespace LekMedSpråket
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class F_ValgfrieParametere
    {
        /*
         
         Skriv /// over en klasse/funksjon/property for å generere dokumentasjon som vil dukke opp i intellisence.
         
         */

        /// <summary>
        /// Hjelpefunksjon for å slå sammen tekst
        /// </summary>
        /// <param name="tekst1">A</param>
        /// <param name="tekst2">B</param>
        /// <param name="prefix">-></param>
        /// <returns>En fin sammenslått tekst.</returns>
        private string SlåSammen(string tekst1, string tekst2, string prefix = null)
        {
            // ?? -> returner første ikke-null
            return (prefix ?? string.Empty) + tekst1 + tekst2;
        }

        [Test]
        public void KanLeggeTilPrefiksEllerLaVære()
        {
            SlåSammen("abc", "def").Should().Be("abcdef");
            SlåSammen("abc", "def", prefix: "-> ").Should().Be("-> abcdef");
        }

        [Test]
        public void KanNavngiDeForskjelligeParametereneForSikkerhetsSkyld()
        {
            SlåSammen(tekst1: "abc", tekst2: "def").Should().Be("abcdef");
            SlåSammen(tekst1: "abc", tekst2: "def", prefix: "-> ").Should().Be("-> abcdef");
        }

        [Test]
        public void KjekkÅBrukeForKonstruktørOverbelastningOgså()
        {
            // Arrange
            var test = new TestKlasse();
            var test2 = new TestKlasse("a");
            var test3 = new TestKlasse("a", "b");

            // Todo: Fjern 2 konstruktører fra 'TestKlasse' og sett defaultverdier slik at testene under fortsatt kjører.

            // Assert
            test.a.Should().Be("a");
            test.b.Should().Be("b");

            test2.a.Should().Be("a");
            test2.b.Should().Be("b");

            test3.a.Should().Be("a");
            test3.b.Should().Be("b");
        }

        class TestKlasse
        {
            public string a;
            public string b;

            public TestKlasse(string a = "a", string b = "b")
            {
                this.a = a;
                this.b = b;
            }
        }
    }
}