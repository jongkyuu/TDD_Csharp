namespace TestMultiplication
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMultiplication()
        {
            Dollor five = new Dollor(5);
            five.Times(2);
            Assert.AreEqual(10, five.amount);
        }
    }

    class Dollor
    {
        public int amount;

        public Dollor(int amount)
        {
            this.amount = amount;
        }

        public void Times(int multiplier)
        {
            amount *= multiplier;
        }
    }
}
