namespace TestMultiplication
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            Assert.AreEqual(new Dollar(10), five.Times(2));
            Assert.AreEqual(new Dollar(15), five.Times(3));
        }

        [TestMethod]
        public void TestEquality()
        {
            Assert.IsTrue(new Dollar(5).Equals(new Dollar(5)));
            Assert.IsFalse(new Dollar(5).Equals(new Dollar(6)));
            Assert.IsTrue(new Franc(5).Equals(new Franc(5)));
            Assert.IsFalse(new Franc(5).Equals(new Franc(6)));
            Assert.IsFalse(new Franc(5).Equals(new Dollar(5)));
        }

        //[TestMethod]
        //public void TestFrancMultiplication()
        //{
        //    Franc five = new Franc(5);
        //    Assert.AreEqual(new Franc(10), five.Times(2));
        //    Assert.AreEqual(new Franc(15), five.Times(3));
        //}
    }

    class Money
    {
        internal int amount;

        public override bool Equals(object obj)
        {
            //if (obj == null || !this.GetType().Equals(obj.GetType()))
            //{
            //    return false;
            //}

            Money money = (Money)obj;
            return amount == money.amount && GetType().Equals(money.GetType());
        }
    }

    class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(amount * multiplier);
        }
    }


    class Franc : Money
    {
        public Franc(int amount)
        {
            this.amount = amount;
        }

        public Franc Times(int multiplier)
        {
            return new Franc(amount * multiplier);
        }
    }
}
