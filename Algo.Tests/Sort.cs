using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algo.Tests
{
    [TestFixture]
    public class Sort
    {
        [Test]
        public void SelectionSort()
        {
            var chars = new char[] { 'd', 'e', 'f', 'r', 'o', 'b' };
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

        private Dictionary<string, long> SortCompare(int testArraySize, Dictionary<string, Sort<double>> sorts)
        {
            var results = new Dictionary<string, long>();
            var sortCount = sorts.Count;
            Random r = new Random();
            var doubles = new double[sortCount][];
            for (var i = 0; i < sortCount; i++)
            {
                doubles[i] = new double[testArraySize];
            }
            for (var j = 0; j < testArraySize; j++)
            {
                var next = r.NextDouble();
                for (var i = 0; i < sortCount; i++)
                {
                    doubles[i][j] = next;
                }
            }

            var testSetIndex = 0;
            var stopwatch = new Stopwatch();
            foreach(var kvp in sorts)
            {
                var sort = kvp.Value;
                stopwatch.Reset();
                stopwatch.Start();
                sort.Go(doubles[testSetIndex]);
                stopwatch.Stop();
                Assert.IsTrue(sort.IsSorted(doubles[testSetIndex]));
                results.Add(kvp.Key, stopwatch.ElapsedMilliseconds);
                testSetIndex++;
            }
            return results;
        }

        [Test]
        public void InsertAndSelectionSortCompare()
        {
            var sorts = new Dictionary<string, Sort<double>>()
            {
                { "Selection", new SelectionSort<double>() },
                { "Insertion", new InsertionSort<double>() }
            };

            var compareResults = SortCompare(1000, sorts);

            Assert.Greater(compareResults["Selection"], compareResults["Insertion"]);
        }

        [Test]
        public void ShellSort()
        {
            var characters = "SHELLSORTEXAMPLE".ToCharArray();
            var shellSort = new ShellSort<char>();
            shellSort.Go(characters);
            Assert.AreEqual("AEEEHLLLMOPRSSTX", new string(characters));
        }

        [Test]
        public void InsertAndSelectionAndShellSortCompare()
        {
            var sorts = new Dictionary<string, Sort<double>>()
            {
                { "Selection", new SelectionSort<double>() },
                { "Insertion", new InsertionSort<double>() },
                { "Shell", new ShellSort<double>() }
            };

            var compareResults = SortCompare(10000, sorts);

            Assert.Greater(compareResults["Selection"], compareResults["Insertion"]);
            Assert.Greater(compareResults["Insertion"], compareResults["Shell"]);


        }
    }
}
