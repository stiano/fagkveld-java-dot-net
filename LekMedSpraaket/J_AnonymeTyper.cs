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

        [Test]
        public void KanSendeAnonymKlasseTilDynamiskFunksjon()
        {
            var anon = new
            {
                A = 55,
                B = "Demo"
            };

            // En slik type kan godt benyttes til output av json :)

            var resultat = DynamiskMetode1(anon);

            resultat.Should().Be(55);
        }

        private int DynamiskMetode1(dynamic dyn)
        {
            return dyn.CD;
        }
    }


    /*
     
     Men dette blir egentlig mer interessant med en gang vi begynner å se på LINQ...
     
     */
}