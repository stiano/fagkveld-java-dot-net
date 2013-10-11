namespace LekMedSpråket
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using FluentAssertions;

    using NUnit.Framework;

    class RessurskrevendeType : IDisposable
    {
        public object t;
        public void KjørProssess()
        {
            // Benytter ressurs    
            t = null;
            Trace.WriteLine("Prosess kjørt");
        }

        public void Dispose()
        {
            // Rydd opp ressursbruk

            Trace.WriteLine("Dispose kjørt");
        }
    }

    [TestFixture]
    public class H_Usings
    {
        [Test]
        public void DyrebareRessurserKanHåndteresManuelt()
        {
            var type = new RessurskrevendeType();

            try
            {
                type.KjørProssess();
            }
            finally
            {
                type.Dispose();
            }

            type.t.Should().BeNull();
        }

        [Test]
        public void EllerAutomatiskGjennomEtUsingStatement()
        {
            // using krever at typen implementerer IDisposible.
            using (var type = new RessurskrevendeType())
            {
                type.KjørProssess();
            }
            // Todo: sjekk output for å verifisere at dispose ble kjørt.
        }

        [Test]
        public void BenyttesGjerneMedStrømmerEtc()
        {
            var tilfeldigFilbane = Path.GetTempFileName();

            using (var stream = File.OpenWrite(tilfeldigFilbane))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("Første linje");
            }

            Trace.Write(tilfeldigFilbane);

            // Verifiserer innholdet.
            File.ReadAllText(tilfeldigFilbane)
                //.TrimEnd()
                .Should().Be("Første linje\r\n");

            // Todo: Åpne fil og verifiser innholdet
        }
    }
}