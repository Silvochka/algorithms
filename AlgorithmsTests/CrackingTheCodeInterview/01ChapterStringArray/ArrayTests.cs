using Algorithms.Interview.Chapter1;
using NUnit.Framework;

namespace AlgorithmsTests.CrackingTheCodeInterview._01ChapterStringArray
{
    class ArrayTests
    {
        [Test]
        public void TestRotateArray()
        {
            var testArray = new int[10, 5];
            Assert.DoesNotThrow(() => testArray.Rotate(), "not square array should just exit");
            testArray = null;
            Assert.DoesNotThrow(() => testArray.Rotate(), "null array should just exit");

            var array = new int[5, 5];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = (i + 1) * (j + 2);
                }
            }

            array.Rotate();

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Assert.AreEqual((i + 2) * (array.GetLength(1) - j), array[i, j]);
                }
            }
        }

        [Test]
        public void TestZerofyArray()
        {
            int[,] testArray = null;
            Assert.DoesNotThrow(() => testArray.Zerofy(), "null array should just exit");

            var array = new int[6, 5];
            int zeroColumn = 1;
            int zeroRow = 4;
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (i == zeroRow && j == zeroColumn)
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        array[i, j] = 1;

                    }
                }
            }

            array.Zerofy();

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (i == zeroRow || j == zeroColumn)
                    {
                        Assert.AreEqual(0, array[i, j]);
                    }
                    else
                    {
                        Assert.AreEqual(1, array[i, j]);
                    }
                }
            }
        }
    }
}
