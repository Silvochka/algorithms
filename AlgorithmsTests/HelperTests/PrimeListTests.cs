using Algorithms.Helpers;
using NUnit.Framework;

namespace AlgorithmsTests.HelperTests
{
    class PrimeListTests
    {
        [Test]
        public void PrimeListTest()
        {
            Assert.AreEqual(2, PrimeList.GetNextPrime(0), "Next prime after 0 is 2");
            Assert.AreEqual(2, PrimeList.GetNextPrime(1), "Next prime after 1 is 2");
            Assert.AreEqual(3, PrimeList.GetNextPrime(2), "Next prime after 2 is 3");
            Assert.AreEqual(5, PrimeList.GetNextPrime(3), "Next prime after 3 is 5");
        }
    }
}
