using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Algo.Tests
{
    [TestFixture]
    public class Sort
    {
        [Test]
        public void SelectionSort()
        {
            var chars = new char[] { 'd', 'e','f','r','o','b' };
            var sort = new SelectionSort<char>();
            sort.Go(chars);
            Assert.IsTrue(sort.IsSorted(chars));
        }

        [Test]
        public void InsertionSort()
        {
            var chars = new char[] { 'd', 'e', 'f', 'r', 'o', 'b' };
            var sort = new InsertionSort<char>();
            sort.Go(chars);
            Assert.IsTrue(sort.IsSorted(chars));
        }

        [Test]
        public void InsertAndSelectionSortCompare()
        {
            Random r = new Random();
            var doubles1 = new double[1000];
            var doubles2 = new double[1000];
            for (int i = 0; i < 1000; i++)
            {
                var next = r.NextDouble();
                doubles1[i] = next;
                doubles2[i] = next;
            }

            var selSort = new SelectionSort<double>();
            var insSort = new InsertionSort<double>();
            var selSW = Stopwatch.StartNew();
            selSort.Go(doubles1);
            selSW.Stop();
            var insSW = Stopwatch.StartNew();
            insSort.Go(doubles2);
            insSW.Stop();
            Assert.IsTrue(selSort.IsSorted(doubles1));
            Assert.IsTrue(insSort.IsSorted(doubles2));
            Assert.Greater(selSW.ElapsedMilliseconds, insSW.ElapsedMilliseconds);
        }
    }
}
