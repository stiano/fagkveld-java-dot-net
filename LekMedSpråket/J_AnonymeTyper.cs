namespace LekMedSpråket
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class J_AnonymeTyper
    {
        [Test]
        public void TrengerViEgentligEnKlasse()
        {
            var figur = new
            {
                Navn = "Donald",
                Alder = 103
            };

            figur.Alder.Should().Be(103);
            figur.Navn.Should().Be("Donald");
        }
    }

    /*
     
     Dette blir egentlig mer interessant med en gang vi begynner å se på LINQ...
     
     */
}