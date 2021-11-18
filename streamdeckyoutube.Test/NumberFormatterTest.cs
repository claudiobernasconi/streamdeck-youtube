using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace streamdeckyoutube.Test
{
    [TestClass]
    public class NumberFormatterTest
    {
        private NumberFormatter _numberFormatter;

        public NumberFormatterTest()
        {
            _numberFormatter = new NumberFormatter();
        }

        [TestMethod]
        public void FormatNumber_0()
        {
            var result = _numberFormatter.FormatNumber(0);
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void FormatNumber_1()
        {
            var result = _numberFormatter.FormatNumber(1);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void FormatNumber_999()
        {
            var result = _numberFormatter.FormatNumber(999);
            Assert.AreEqual("999", result);
        }

        [TestMethod]
        public void FormatNumber_1000()
        {
            var result = _numberFormatter.FormatNumber(1000);
            Assert.AreEqual("1000", result);
        }

        [TestMethod]
        public void FormatNumber_1001()
        {
            var result = _numberFormatter.FormatNumber(1001);
            Assert.AreEqual("1.00K", result);
        }

        [TestMethod]
        public void FormatNumber_1010()
        {
            var result = _numberFormatter.FormatNumber(1010);
            Assert.AreEqual("1.01K", result);
        }

        [TestMethod]
        public void FormatNumber_1100()
        {
            var result = _numberFormatter.FormatNumber(1100);
            Assert.AreEqual("1.10K", result);
        }

        [TestMethod]
        public void FormatNumber_2990()
        {
            var result = _numberFormatter.FormatNumber(2990);
            Assert.AreEqual("2.99K", result);
        }

        [TestMethod]
        public void FormatNumber_9999()
        {
            var result = _numberFormatter.FormatNumber(9999);
            Assert.AreEqual("9.99K", result);
        }

        [TestMethod]
        public void FormatNumber_10000()
        {
            var result = _numberFormatter.FormatNumber(10_000);
            Assert.AreEqual("10.0K", result);
        }

        [TestMethod]
        public void FormatNumber_99_999()
        {
            var result = _numberFormatter.FormatNumber(99_999);
            Assert.AreEqual("99.9K", result);
        }

        [TestMethod]
        public void FormatNumber_100_000()
        {
            var result = _numberFormatter.FormatNumber(100_000);
            Assert.AreEqual("100K", result);
        }

        [TestMethod]
        public void FormatNumber_101_000()
        {
            var result = _numberFormatter.FormatNumber(101_000);
            Assert.AreEqual("101K", result);
        }

        [TestMethod]
        public void FormatNumber_999_999()
        {
            var result = _numberFormatter.FormatNumber(999_999);
            Assert.AreEqual("999K", result);
        }

        [TestMethod]
        public void FormatNumber_1_000_000()
        {
            var result = _numberFormatter.FormatNumber(1_000_000);
            Assert.AreEqual("1.00M", result);
        }

        [TestMethod]
        public void FormatNumber_1_010_000()
        {
            var result = _numberFormatter.FormatNumber(1_010_000);
            Assert.AreEqual("1.01M", result);
        }

        [TestMethod]
        public void FormatNumber_1_100_000()
        {
            var result = _numberFormatter.FormatNumber(1_100_000);
            Assert.AreEqual("1.10M", result);
        }

        [TestMethod]
        public void FormatNumber_9_999_999()
        {
            var result = _numberFormatter.FormatNumber(9_999_999);
            Assert.AreEqual("9.99M", result);
        }

        [TestMethod]
        public void FormatNumber_10_000_000()
        {
            var result = _numberFormatter.FormatNumber(10_000_000);
            Assert.AreEqual("10.0M", result);
        }

        [TestMethod]
        public void FormatNumber_99_999_999()
        {
            var result = _numberFormatter.FormatNumber(99_999_999);
            Assert.AreEqual("99.9M", result);
        }

        [TestMethod]
        public void FormatNumber_100_000_000()
        {
            var result = _numberFormatter.FormatNumber(100_000_000);
            Assert.AreEqual("100M", result);
        }

        [TestMethod]
        public void FormatNumber_1_000_000_000()
        {
            var result = _numberFormatter.FormatNumber(1_000_000_000);
            Assert.AreEqual("1.00B", result);
        }

        [TestMethod]
        public void FormatNumber_10_000_000_000()
        {
            var result = _numberFormatter.FormatNumber(10_000_000_000);
            Assert.AreEqual("10.0B", result);
        }

        [TestMethod]
        public void FormatNumber_100_000_000_000()
        {
            var result = _numberFormatter.FormatNumber(100_000_000_000);
            Assert.AreEqual("100B", result);
        }

        [TestMethod]
        public void FormatNumber_999_999_999_999()
        {
            var result = _numberFormatter.FormatNumber(999_999_999_999);
            Assert.AreEqual("999B", result);
        }

        [TestMethod]
        public void FormatNumber_1_000_000_000_000()
        {
            var result = _numberFormatter.FormatNumber(1_000_000_000_000);
            Assert.AreEqual(">1T", result);
        }        
    }
}