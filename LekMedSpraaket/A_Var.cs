﻿namespace LekMedSpråket
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using NUnit.Framework;

    /*
     
     Hurtigtaster:
     -Kjør unit test: Ctrl u+r 
     -Debug unit test: Ctrl u+d
      
     Diskusjon rundt bruken av var-nøkkelordet: http://stackoverflow.com/questions/41479/use-of-var-keyword-in-c-sharp
     
     */

    [TestFixture]
    public class A_Var
    {
        [Test]
        public void TrengerIkkeSkriveType()
        {
            


            const string TING = "TANG";






            // Arrage
            //int magisk = 43;
            var magisk = 43;

            // Act
            var type = magisk.GetType();

            // Assert
            type.Should().Be(typeof(double));

            // NB: FluentAssertions er et abstraksjonslag over NUnit (og andre unittestrammeverk) som gir deg Should().Be() syntaks. 
            //     Man kan evt gjøre slik, men det høres ikke like sexy ut dersom uttrykket leses høyt.

            Assert.AreEqual(typeof(double), type);
        }

        [Test]
        public void TrengerIkkeSkriveTypePåKompleksStruktur()
        {
            // Arrage
            //Dictionary<string, Dictionary<string,object>> tilfeldigStruktur = new Dictionary<string, Dictionary<string,object>>();
            var tilfeldigStruktur = new Dictionary<string, Dictionary<string,object>>();

            // Act
            var type = tilfeldigStruktur.GetType();

            // Assert
            type.Should().Be(typeof(Dictionary<string, Dictionary<string, string>>));
        }

        /*
         
         Snarvei: Marker curser på et klassenavn (Pers|on) og trykk på F12 for å navigere til implementasjonen.
         
         */

        [Test]
        public void FungererOgsåPåEgneTyper()
        {
            // Arrage
            //Person person = new Person();
            var person = new Person();

            // Act
            var type = person.GetType();

            // Assert
            type.Should().Be(typeof(object));
        }

        [Test]
        public void FungererNaturligvisOgsåPåLister()
        {
            // Arrage
            var personer = Enumerable.Empty<Person>(); // Tom liste

            // Act
            var type = personer.GetType();

            // Assert
            type.Should().Be(typeof(List<Person>));
        }
    }
}