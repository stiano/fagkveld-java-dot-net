namespace LekMedSpråket
{
    public partial class Person
    {
        public Person()
        {
        }

        partial void EndreNavn(string nyttNavn);

        public Person(string navn)
        {
            Navn = navn;
        }

        public string Navn { get; set; }
        public string MellomNavn { get; set; }
        public bool ErDod { get; set; }

        public int Alder { get; set; }
    }

    // Ikke så veldig godt eksempel på bruk av partial klasse og funksjon. 
    // Typisk bruksscenario kan være tilpassing av generert kode, der den genererte koden ikke skal røres.
    // Les mer om hvordan: http://stackoverflow.com/questions/3601901/why-use-partial-classes
    public partial class Person
    {
        partial void EndreNavn(string nyttNavn)
        {
            Navn = nyttNavn;
        }
    }
}