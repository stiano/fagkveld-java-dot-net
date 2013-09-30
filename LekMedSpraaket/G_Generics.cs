namespace LekMedSpråket
{
    using System.Collections.Generic;

    using FluentAssertions;

    using NUnit.Framework;

     [TestFixture]
    public class G_Generics
    {
        [Test]
        public void TypeSikreListerErAlltidEnVinner()
        {
            // Collection initialization
            var personer = new List<Person>
            {
                new Person("A"),
                new Person("B"),
                new Person("C"), // komma til slutt er ok, da er det enklere å sette inn neste element senere
            };

            personer.Add(new Person("D"));

            personer.Count.Should().Be(3);
        }

        /// <typeparam name="TId">Typen til det generiske argumentet</typeparam>
        class Entitet<TId>
        {
            public TId Id { get; set; }
        }

        /// <summary>
        /// Entitet med long som identifikator.
        /// </summary>
        class Konto : Entitet<long>
        {
            public string Kontonummer { get; set; }
        }

        [Test]
        public void KanBenyttesPåEgneTyper()
        {
            var konto = new Konto
            {
                Id = 123L, // L indikerer long.
                Kontonummer = "12312 12 1232"
            };

            konto.Id.Should().Be(123L);
        }
    }
}