namespace LekMedSpråket
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using IronPython.Hosting;

    using Microsoft.CSharp.RuntimeBinder;
    using Microsoft.Scripting.Hosting;
    using NUnit.Framework;

    /*
      
     Dynamic -> Alt kompilerer compiletime, men runtime kan det gå skeis dersom ting ikke er på stell.
    
     Forklaring på bruk av dynamic ved å laste inn og kjøre pytonkode: 
     http://www.hanselman.com/blog/C4AndTheDynamicKeywordWhirlwindTourAroundNET4AndVisualStudio2010Beta1.aspx
     
     */

    [TestFixture]
    public class C_Dynamic
    {
        [Test]
        public void VilKompilere_MenKasterException()
        {
            // Og slik lages konstanter. 
            const string EspenAskeladd = "Espen Askeladd";

            // Arrange
            dynamic person = new Person
            {
                Navn = EspenAskeladd
            };

            // Assert
            Assert.Throws<RuntimeBinderException>(() => // lambda-funksjon
            {
                // Kompilerer, men feiler runtime.
                person.KanMålbindePrinsessen();
            });
        }

        [Test]
        public void KanLeseInnPythonFilOgKjøreDen()
        {
            // For å hente ned avhengigheter måtte jeg åpne View -> Other Windows -> Package Manager Console
            // PM> Install-Package IronPython
            // Se packages.config for installerte avhengigheter

            ScriptRuntime py = Python.CreateRuntime();
            dynamic kalkulator = py.UseFile("calculator.py");
            
            int sum = kalkulator.add(5, 4);
            sum.Should().Be(9);
        }
    }
}