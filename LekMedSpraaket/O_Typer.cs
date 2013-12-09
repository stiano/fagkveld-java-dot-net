namespace LekMedSpråket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class O_Typer
    {
        [Test]
        public void Typer_KanFinnesPå2Måter()
        {
            Type v1 = typeof(string);
            Type v2 = "".GetType();

            v1.Should().Be(v2);
        }

        private IEnumerable<Type> testKlasser;

        [TestFixtureSetUp]
        public void Setup()
        {
            // Reflection m/Linq
            testKlasser = Assembly.GetExecutingAssembly()
                    .Types()
                    .ThatAreDecoratedWith<TestFixtureAttribute>()
                    .ToList();
        }

        [Test]
        public void ReflectionEksempel_FinnAlleKlasserSomErDekorertMedEtGittAttributt()
        {
            testKlasser.Should().Contain(new[]
            {
                typeof(A_Var),
                typeof(Base),
                typeof(O_Typer),
            });

            testKlasser.Count().Should().Be(12);
        }
    }
}