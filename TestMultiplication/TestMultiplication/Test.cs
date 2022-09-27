namespace TestMultiplication
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            Dollar product = five.Times(2);
            Assert.AreEqual(10, product.amount);
            product = five.Times(3);
            Assert.AreEqual(15, product.amount);
        }

        [TestMethod]
        public void TestEquality()
        {
            Assert.IsTrue(new Dollar(5).equals(new Dollar(5)));
            Assert.IsFalse(new Dollar(5).equals(new Dollar(6)));
        }
    }

    class Dollar
    {
        public int amount;

        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(amount * multiplier);
        }

        public bool equals(object @object)
        {
            Dollar dollar = (Dollar)@object;
            return amount == dollar.amount;
        }
    }
}
