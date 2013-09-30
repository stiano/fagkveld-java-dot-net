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
    
     Forklaring på bruk av dynamic ved å laste inn og kjøre pytonkode: 
     http://www.hanselman.com/blog/C4AndTheDynamicKeywordWhirlwindTourAroundNET4AndVisualStudio2010Beta1.aspx
     
     */

    [TestFixture]
    public class C_Dynamic
    {
        [Test]
        public void VilKompilere_MenKasterException()
        {
            // Arrange
            dynamic person = new Person
            {
                Navn = "Espen Askeladd"
            };

            // Assert
            Assert.Throws<RuntimeBinderException>(() => // lambda-funksjon
            {
                person.KanMålbindePrinsessen(true);
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
            
            int sum = kalkulator.add(5, 9);
            sum.Should().Be(12);
        }
    }
}