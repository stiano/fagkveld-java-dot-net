namespace LekMedSpråket
{
    using System;
    using System.Diagnostics;

    using FluentAssertions;
    using NUnit.Framework;

    /*
     
    Forklaring av syntaks: http://www.dotnetperls.com/lambda 
     
     */

    [TestFixture]
    public class E_Lambda
    {
        [Test]
        public void EllerAnonymeMetoder_GirIkkeAlltidMening()
        {
            // Arrage
            Predicate<Person> erMyndig = (pers) => // Predicate: Tar imot et sett med inputvariable og returnerer true/false.
            {
                return pers.Alder >= 18;
            };

            var person = new Person
            {
                Navn = "Espen Askeladd",
                Alder = 17
            };

            // Assert
            erMyndig(person).Should().Be(true);
        }

        [Test]
        public void KanBrukesForÅPakkeInnFunksjonalitetFraLugubreUtestbareApier()
        {
            // Arrage
            Action<string> loggfør = (s) => // Action: Tar imot et sett med inputvariable og returnerer void
            {
                Trace.WriteLine(s);
            };

            Action<string> loggførV2littMerKonsis = Console.WriteLine;

            // Assert
            loggfør("Skriver til testkonsollet");
            loggførV2littMerKonsis("litt mer konsist");

            // Sjekk output i konsollet!
        }

        [Test]
        public void KanBrukesForÅPakkeInnFunksjonalitetFraLugubreUtestbareApierV2()
        {
            Func<string, string, int> autentiserOgReturnerEvtSesjonsLengde = (brukernavn, passord) => // Func: Tar imot et sett med inputvariable og returnerer en verdi av typen til den siste inputverdien.
            {
                //FormsAuthentication.Authenticate(brukernavn, passord);
                return brukernavn == passord
                           ? 20
                           : 0;
            };

            autentiserOgReturnerEvtSesjonsLengde("un", "un").Should().Be(20);
            autentiserOgReturnerEvtSesjonsLengde("un", "pw").Should().Be(0);
        }
    }
}