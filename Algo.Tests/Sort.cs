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

        private double[] GenerateDoubleTestData(int size)
        {
            Random r = new Random();
            var doubles = new double[size];
            for (var j = 0; j < size; j++)
            {
                doubles[j] = r.NextDouble();
            }
            return doubles;
        }

        private byte[] GenerateByteTestData(int size)
        {
            Random r = new Random();
            var bytes = new byte[size];
            r.NextBytes(bytes);
            return bytes;
        }


        private Dictionary<string, long> SortCompare<T>(T[] testData, Dictionary<string, Sort<T>> sorts) where T : IComparable
        {
            var results = new Dictionary<string, long>();
            var sortCount = sorts.Count;

            var testDataSets = new T[sortCount][];
            for (var i = 0; i < sortCount; i++)
            {
                testDataSets[i] = (T[])testData.Clone();
            }

            var testSetIndex = 0;
            var stopwatch = new Stopwatch();
            foreach(var kvp in sorts)
            {
                var sort = kvp.Value;
                stopwatch.Reset();
                stopwatch.Start();
                sort.Go(testDataSets[testSetIndex]);
                stopwatch.Stop();
                Assert.IsTrue(sort.IsSorted(testDataSets[testSetIndex]));
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

            var doubleTestData = GenerateDoubleTestData(1000);
            var compareResults = SortCompare(doubleTestData, sorts);

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

            var doubleTestData = GenerateDoubleTestData(10000);
            var compareResults = SortCompare(doubleTestData, sorts);

            Assert.Greater(compareResults["Selection"], compareResults["Insertion"]);
            Assert.Greater(compareResults["Insertion"], compareResults["Shell"]);
        }

        [Test] // 2.1.11
        public void ShellSortWithWithArray()
        {
            var buffer = GenerateByteTestData(4194303);
            var shellSort = new ShellSortWithArray<byte>();
            shellSort.Go(buffer);
            Assert.IsTrue(shellSort.IsSorted(buffer));
        }

        [Test]
        public void ShellSortCompare()
        {
            var sorts = new Dictionary<string, Sort<byte>>()
            {
                { "Shell", new ShellSort<byte>() },
                { "ShellWithArray", new ShellSortWithArray<byte>() }
            };

            var byteTestData = GenerateByteTestData(4194303);
            var compareResults = SortCompare(byteTestData, sorts);

            //note: keeping the increments in an array did not increase performance as much as I had expected
            Assert.Greater(compareResults["Shell"], compareResults["ShellWithArray"]);
        }
    }
}
