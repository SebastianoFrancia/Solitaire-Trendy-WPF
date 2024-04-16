using Solitaire_Trendy_WPF;

namespace Solitaire_Treandy_Test
{
    [TestClass]
    public class TestCards
    {
        [TestMethod]
        public void SuitWithInvalidValue()
        {
            Assert.ThrowsException<ArgumentException>(() => new Card((TypeSuit)4, 8));

        }

        [TestMethod]
        public void ValueWithInvalidValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card(TypeSuit.Denara, 11));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card(TypeSuit.Denara, 0));

        }
    }
}
