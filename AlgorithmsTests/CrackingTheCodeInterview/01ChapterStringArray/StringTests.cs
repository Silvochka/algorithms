using Algorithms.Interview.Chapter1;
using NUnit.Framework;

namespace AlgorithmsTests.Interview.Chapter1
{
    class StringTests
    {
        [Test]
        public void TestUniqueStrings()
        {
            Assert.IsTrue("".IsUniqueChars(), "empty string has all unique chars");
            Assert.IsTrue("abcde".IsUniqueChars(), "abcde has all unique chars");
            Assert.IsFalse("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa".IsUniqueChars(), "string too long to be unique");
            Assert.IsFalse("abcdee".IsUniqueChars(), "abcde has all unique chars");
        }

        [Test]
        public void TestReverse()
        {
            Assert.AreEqual("", "".Reverse(), "empty string has empty reverse");
            Assert.AreEqual("1", "1".Reverse(), "Reverse string with 1 char works");
            Assert.AreEqual("12", "21".Reverse(), "Reverse string with 2 chars works");
            Assert.AreEqual("121", "121".Reverse(), "Reverse string with 3 chars works");
            Assert.AreEqual("abcde", "edcba".Reverse(), "Reverse string with 5 chars works");
        }

        [Test]
        public void TestPermutation()
        {
            Assert.IsFalse("".IsPermutationOf(""), "empty cannot be permutation");
            Assert.IsTrue("1".IsPermutationOf("1"), "check permutation of string");
            Assert.IsTrue("12".IsPermutationOf("21"), "check permutation of string");
            Assert.IsTrue("1233".IsPermutationOf("3321"), "check permutation of string");
            Assert.IsTrue("12 33".IsPermutationOf("332 1"), "check permutation of string");
            Assert.IsFalse("12 33".IsPermutationOf("33  1"), "check permutation of string");
            Assert.IsFalse("12 33".IsPermutationOf("abc"), "check permutation of string");
        }

        [Test]
        public void TestReplacingSpace()
        {
            Assert.AreEqual("", "".ReplaceSpace(), "empty string has 0 replacement");
            Assert.AreEqual("1", "1".ReplaceSpace(), "string without spaces has 0 replacement");
            Assert.AreEqual("%20", " ".ReplaceSpace(), "string with 1 spaces has 1 replacement");
            Assert.AreEqual("%201", " 1".ReplaceSpace(), "string with 1 spaces has 1 replacement");
            Assert.AreEqual("%201%20", " 1 ".ReplaceSpace(), "string with 2 spaces has 2 replacements");
        }

        [Test]
        public void TestIsPermutationOfPalindrome()
        {
            Assert.IsFalse("".IsPermutationOfPalindrome(), "empty cannot be permutation of palindrome");
            Assert.IsTrue(" ".IsPermutationOfPalindrome(), "Space is permutation of palindrome");
            Assert.IsTrue(" 11 ".IsPermutationOfPalindrome(), "Test is permutation of palindrome");
            Assert.IsTrue(" 121 ".IsPermutationOfPalindrome(), "Test is permutation of palindrome");
            Assert.IsTrue("1 1211 ".IsPermutationOfPalindrome(), "Test is permutation of palindrome");
            Assert.IsFalse("1 1333211 ".IsPermutationOfPalindrome(), "Test is permutation of palindrome");
            Assert.IsFalse("1  133211 ".IsPermutationOfPalindrome(), "Test is permutation of palindrome");
        }

        [Test]
        public void TestSimilar()
        {
            Assert.IsFalse("".IsSimilarLike(""), "empty cannot be similar");
            Assert.IsTrue("1".IsSimilarLike("12"), "test on adding");
            Assert.IsTrue("123".IsSimilarLike("12"), "test on removing");
            Assert.IsTrue("123".IsSimilarLike("124"), "test on editing");
            Assert.IsFalse("12345".IsSimilarLike("12444"), "test on failure edit");
            Assert.IsFalse("12345".IsSimilarLike("124"), "test on failure removal");
            Assert.IsFalse("12345".IsSimilarLike("1225"), "test on failure removal");
            Assert.IsFalse("12 45".IsSimilarLike("124"), "test on failure removal");
        }

        [Test]
        public void TestAcrhiving()
        {
            Assert.AreEqual("", "".Archive(), "empty string has empty archive");
            Assert.AreEqual("a", "a".Archive(), "single string has same archive");
            Assert.AreEqual("a2", "aa".Archive(), "simple archiving");
            Assert.AreEqual("a3", "aaa".Archive(), "string should be archived");
            Assert.AreEqual("abc", "abc".Archive(), "string should be not archived");
            Assert.AreEqual("a11b2c1", "aaaaaaaaaaabbc".Archive(), "string should be archived");
        }

        [Test]
        public void TestIsCycleShift()
        {
            Assert.IsFalse("".IsCycleShift(""), "empty cannot be cycle shift");
            Assert.IsTrue("1".IsCycleShift("1"), "test on cycle shift single char");
            Assert.IsTrue("12".IsCycleShift("21"), "test on cycle shift string");
            Assert.IsTrue("abcde".IsCycleShift("deabc"), "test on cycle shift string");
            Assert.IsFalse("12345".IsCycleShift("12444"), "test on failure cycle shifting");
            Assert.IsFalse("12345".IsCycleShift("144"), "test on failure cycle shifting");
        }
    }
}
