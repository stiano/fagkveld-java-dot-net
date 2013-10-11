namespace LekMedSpråket
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using FluentAssertions;
    using NUnit.Framework;

    /*
     
    Forklaring av syntaks: http://www.dotnetperls.com/lambda 
    
    Les gjerne litt om delegater (funksjonspekere) her: http://zetcode.com/lang/csharp/delegates/
     
     */

    [TestFixture]
    public class E_Lambda
    {
        public bool ErMyndig(Person p)
        {
            return p.Alder >= 18;
        }

        [Test]
        public void AnonymeMetoder_HerNavngittLokalt()
        {
            // Predicate: Tar imot et sett med inputvariable (generiske) og returnerer true/false.
            Predicate<Person> erMyndig = (pers) => 
            {
                return pers.Alder >= 18;
            };

            // kan også peke på eksisterende funksjoner. Merk at metodesignaturene må stemme overens.
            Predicate<Person> myndig2 = ErMyndig;

            var person = new Person
            {
                Navn = "Espen Askeladd",
                Alder = 17
            };

            erMyndig(person)
                .Should().Be(false);
        }

        [Test]
        public void KanBrukesForÅPakkeInnFunksjonalitetFraLugubreUtestbareApier()
        {
            // Action: Tar imot et sett med inputvariable og returnerer void
            Action<string> loggfør = (s) => 
            {
                Trace.WriteLine(s);
            };

            Action<string> loggførV2LittMerKonsis = Console.WriteLine;

            loggfør("Skriver til testkonsollet");
            loggførV2LittMerKonsis("litt mer konsist");

            // Todo: Sjekk output i konsollet!
        }

        [Test]
        public void KanBrukesForÅPakkeInnFunksjonalitetFraLugubreUtestbareApierV2()
        {
            // Func: Tar imot et sett med inputvariable og returnerer en verdi av typen til den siste inputverdien.
            Func<string, string, int> autentiserOgReturnerEvtSesjonsLengde = (brukernavn, passord) => 
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