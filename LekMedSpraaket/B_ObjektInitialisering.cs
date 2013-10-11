namespace LekMedSpråket
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class B_ObjektInitialisering
    {
        [Test]
        public void FiffigSyntaksForÅInitialisereObjekter()
        {
            // Arrange
            var person1 = new Person() // Valgfritt med parenteser
            {
                Navn = "Espen Askeladd",
            };

            Person person2 = new Person();
            person2.Navn = "Espen Askeladd";

            // Assert
            person1.Navn.Should().Be(person2.Navn);
            person1.Should().NotBeSameAs(person2);
        }

        [Test]
        public void PropertieneSettesEtterKonstruktøren()
        {
            // Arrange
            var person = new Person("Pål Askeladd") 
            {
                Navn = "Espen Askeladd"
            };

            // Assert
            person.Navn.Should().Be("Espen Askeladd");
        }

        [Test]
        public void ErGreiÅBrukePåValgfrieParametere()
        {
            // Arrange
            var person = new Person("Espen Askeladd")
            {
                MellomNavn = "grøtspiser",
                Alder = 21,
                ErDod = false
            };

            // Assert
            person.ErDod.Should().Be(false);
        }
    }
}