namespace TestMultiplication
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMultiplication()
        {
            Money five = Money.Dollar(5); // Factory Method 도입
            Assert.AreEqual(Money.Dollar(10), five.Times(2));
            Assert.AreEqual(Money.Dollar(15), five.Times(3));
        }

        [TestMethod]
        public void TestEquality()
        {
            Assert.IsTrue(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.IsFalse(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.IsTrue(Money.Franc(5).Equals(Money.Franc(5)));
            Assert.IsFalse(Money.Franc(5).Equals(Money.Franc(6)));
            Assert.IsFalse(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [TestMethod]
        public void TestFrancMultiplication()   
        {
            Money five = Money.Franc(5);
            Assert.AreEqual(Money.Franc(10), five.Times(2));
            Assert.AreEqual(Money.Franc(15), five.Times(3));
        }

        [TestMethod]
        public void TestCurrency()
        {
            Assert.AreEqual("USD", Money.Dollar(1).Currency());
            Assert.AreEqual("CHF", Money.Franc(1).Currency());
        }

        [TestMethod]
        public void TestDifferentClassEquality()
        {
            Assert.IsTrue(new Money(10, "CHF").Equals(new Franc(10, "CHF")));
        }
    }

    class Money
    {
        internal int _amount;
        internal string _currency;

        public Money(int amount, string currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public string Currency()
        {
            return _currency;
        }

        //public abstract Money Times(int multiplier);
        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, _currency);
        }


        public static Money Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }

        public override bool Equals(object obj)
        {
            //if (obj == null || !this.GetType().Equals(obj.GetType()))
            //{
            //    return false;
            //}

            Money money = (Money)obj;
            return _amount == money._amount && Currency().Equals(money.Currency());
        }
    }

    class Dollar : Money
    {
        public Dollar(int amount, string currency) : base(amount, currency)
        {
        }


        //public Money Times(int multiplier)
        //{
        //    //return Money.Dollar(_amount * multiplier);
        //    return new Money(_amount * multiplier, _currency);
        //}
    }


    class Franc : Money
    {
        public Franc(int amount, string currency) : base(amount, currency)
        {
        }

        //public Money Times(int multiplier)
        //{
        //    //return Money.Franc(_amount * multiplier);
        //    return new Money(_amount * multiplier, _currency);
        //}
    }
}
