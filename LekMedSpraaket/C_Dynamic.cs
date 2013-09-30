namespace LekMedSpråket
{
    using System;
    using Microsoft.CSharp.RuntimeBinder;
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
    }
}