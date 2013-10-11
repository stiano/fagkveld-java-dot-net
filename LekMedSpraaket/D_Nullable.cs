namespace LekMedSpråket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class D_Nullable
    {
        /*
         
         Primitive typer kan ikke være null, derfor kan man wrappe de som nullbare ved Nullable<T> eller ?.
         
         */
        [Test]
        public void ValueTypesKanNåOgsåVaereNull()
        {
            // Etter å ha lest ut en rad fra db...
            Nullable<int> vennerPåFacebook = null;
            
            // Assert
            vennerPåFacebook.HasValue.Should().Be(false);
        }

        [Test]
        public void KonsisSyntaks()
        {
            // Arrange
            int? vennerPåFacebook = null;

            // Assert
            vennerPåFacebook.HasValue.Should().Be(false);
        }

        [Test]
        public void KanNaturligvisOgsåFåSattVerdi()
        {
            int? vennerPåFacebook = 6;

            vennerPåFacebook.HasValue.Should().Be(true);
            vennerPåFacebook.Value.Should().Be(6);

            vennerPåFacebook.Should().NotBe(3);
        }

        [Test]
        public void KanSendInnNullSomParametereTilFunksjon()
        {
            var liste = Paging(null, null);
            liste.Should().Contain(0);
        }

        private IEnumerable<int> Paging(int? side, int? størrelse)
        {
            // ?? : http://en.wikipedia.org/wiki/Null_coalescing_operator#C.23

            // Sett standardverdier
            side = side ?? 0;
            størrelse = størrelse ?? 10;

            // Generer sekvens
            return Enumerable.Range(side.Value * størrelse.Value, størrelse.Value);
        }
    }
}