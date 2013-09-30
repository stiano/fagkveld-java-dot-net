namespace LekMedSpråket
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    /*
     Intro: http://dotnetpost.blogspot.no/2008/10/linq-explained-part-1.html
     
     101 eksempler på syntaks: http://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
     
     */

    [TestFixture]
    public class L_Linq
    {
        private List<Person> personer;
 
        // Initialiserer alle tester
        public L_Linq()
        {
            personer = new List<Person>()
            {
                new Person("A"){ Alder = 35},
                new Person("B"){ Alder = 25},
                new Person("C"){ Alder = 10},
                new Person("D"){ Alder = 35},
                new Person("E"){ Alder = 100},
            };
        }

        [Test]
        public void DenYngstePersonenEr()
        {
            // One-liner for å finne laveste alder
            var yngst = personer.Min(person => person.Alder);

            yngst.Should().Be(10);
        }

        [Test]
        public void DenEldstrePersonenEr()
        {
            int eldst = 0;

            // Todo: one-liner for å finne høyeste alder

            eldst.Should().Be(100);
        }

        [Test]
        public void HvorMangeEr35()
        {
            int antall = 0;

            antall = personer
                .Where(person => person.Alder == 35)
                .Count();

            antall.Should().Be(0);
        }

        [Test]
        public void HvaErSnittet()
        {
            double snittAlder = 0;

            // Todo: one-liner for å finne snittalder

            snittAlder.Should().Be(41);
        }

        [Test]
        public void HvaMedEnAnnenMerSqlLignendeSyntaks()
        {
            var resultat = from person in personer
                           let alder = person.Alder
                           where alder == 35
                           select person;

            resultat.Count().Should().Be(2);
        }

        [Test]
        public void OgHvordanErFordelingen()
        {
            var resultat = from person in personer
                           group person by person.Alder into gruppe 
                           select new
                           {
                               Alder = gruppe.Key,
                               Antall = gruppe.Count()
                           };

            resultat.ToList().ForEach(obj => Trace.WriteLine(string.Format("{0}:{1}", obj.Antall, obj.Alder)));

            resultat.Count(gruppering => gruppering.Antall > 1)
                .Should().Be(1);
            // Det finnes èn gruppe med 2 elementer i seg (Alder 35).
        }

        [Test]
        public void TellAntallPartall()
        {
            Enumerable.Range(0, 1000 * 1000)
                .Where(i => i % 2 == 0)
                .Count()
                .Should().Be(500 * 1000);
        }

        [Test]
        public void HvordanKalleEgneUtvidelsesmetoder()
        {
            Enumerable.Range(1, 10)
                .Append(11) // Egen metode.
                .ToList()
                .ForEach(i => Trace.WriteLine(i));
        }
    }

    /// <summary>
    /// Egne extension metoder som opererer mot objekter i minnet.
    /// 
    /// Yield: http://msdn.microsoft.com/en-us/library/vstudio/9k7k7cf0.aspx
    /// </summary>
    public static class LinqExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> ie, T element)
        {
            foreach (T t in ie)
                yield return t;
            yield return element;
        }

        public static IEnumerable<T> Exclude<T>(this IEnumerable<T> ie, T element)
        {
            foreach (T t in ie)
                if (!t.Equals(element))
                    yield return t;
        }
    }
}