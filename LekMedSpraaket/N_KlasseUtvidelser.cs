namespace LekMedSpråket
{
    using FluentAssertions;

    using NUnit.Framework;

    // Eksempel på en abstrakt baseklasse
    public abstract class Base
    {
        // kan kun settes i baseklassen. Endre til protected for at subklasse skal få tilgang.
        public int A { get; private set; }

        protected Base(int a)
        {
            A = a;
        }

        protected virtual void BaseKlasseMetoder(){ /*uten implementasjon*/ }
    }

    // Operatører, indexer og overriding.
    [TestFixture]
    public class N_KlasseUtvidelser : Base
    {
        private readonly string[] verdier = new string[100];
        public int Verdi { get; set; }

        public N_KlasseUtvidelser()
            : base(100)
        {
            Verdi = A;
        }

        public static N_KlasseUtvidelser operator +(N_KlasseUtvidelser a, N_KlasseUtvidelser b)
        {
            var widget = new N_KlasseUtvidelser
            {
                Verdi = a.Verdi + b.Verdi
            };

            return widget;
        }

        public static N_KlasseUtvidelser operator ++(N_KlasseUtvidelser a)
        {
            a.Verdi++;

            return a;
        }

        #region Operatør ==
       
        public static bool operator ==(N_KlasseUtvidelser a, N_KlasseUtvidelser b)
        {
            return a.Verdi == b.Verdi;
        }

        public static bool operator !=(N_KlasseUtvidelser a, N_KlasseUtvidelser b)
        {
            return !(a == b);
        }

        #endregion

        // Indexer
        public string this[int index]
        {
            get
            {
                return verdier[index];
            }
            set
            {
                /* set the specified index to value here */
            }
        }
        
        // Skriv 'override' og space for å en liste over tilgjengelige alternativer.
        public override string ToString()
        {
            return "Klasseutvidelser er kult.";
        }

        [Test]
        public void KanBrukesSlik()
        {
            var klasse = new N_KlasseUtvidelser();
            klasse[0] = "1";
            klasse[1] = "2";
            string indeksVerdi = klasse[0];

            klasse++;

            klasse.Verdi.Should().Be(101);

            var nyKlasse = klasse + new N_KlasseUtvidelser();
            nyKlasse.Verdi.Should().Be(201);

            (new N_KlasseUtvidelser() == new N_KlasseUtvidelser())
                .Should().BeTrue();
        }
    }
}