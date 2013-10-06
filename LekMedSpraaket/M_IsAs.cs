namespace LekMedSpråket
{
    using NUnit.Framework;

    class A : IInterfaceAEllerB
    {
         
    }

    class B : IInterfaceAEllerB
    {
         
    }

    interface IInterfaceAEllerB
    {
         
    }

    [TestFixture]
    public class M_IsAs
    {
        // Casting med is/as
        // Les mer: http://stackoverflow.com/questions/3786361/difference-between-is-and-as-keyword

        [Test]
        public void IsOgAsKanBenyttesForÅCasteMellomTyper()
        {
            IInterfaceAEllerB a = new A();

            if (a is A)
            {
                A ny = a as A;

            }
            else if(a is B)
            {
                B b = a as B;
            }
        }
    }
}
