using NUnit.Framework;
using System;
using System.Linq;

namespace Algo.Tests
{
    [TestFixture]
    public class Search
    {
        private static readonly String tinyTale = "it was the best of times it was the worst of times it was the age of wisdom it was the age of foolishness it was the epoch of belief it was the epoch of incredulity it was the season of light it was the season of darkness it was the spring of hope it was the winter of despair";

        private static (string maxWord, int maxCount) FrequencyCounter(int minLength, SymbolTable<string, int> st)
        {
            foreach(var word in tinyTale.Split(' '))
            {
                if (word.Length < minLength) continue;
                //don't have to check for null beause key not found will default to 0 for int value type
                st.Put(word, st.Get(word) + 1);
            }
            var max = "";
            foreach (var word in st.Keys())
            {
                //not sure if ordered and unordered underlying linked list should return the same values
                if (st.Get(word) > st.Get(max))
                    max = word;
            }
            return (maxWord: max, maxCount: st.Get(max));
        }

        [Test]
        public void SequentialSearchStFrequency()
        {
            var st = new SequentialSearchST<string, int>();
            var result = FrequencyCounter(1, st);
            Assert.AreEqual("of", result.maxWord);
            Assert.AreEqual(10, result.maxCount);
        }

        [Test]
        public void BinarySearchSTFrequency()
        {
            var st = new BinarySearchST<string, int>(128);
            var result = FrequencyCounter(1, st);
            Assert.AreEqual("it", result.maxWord);
            Assert.AreEqual(10, result.maxCount);
        }

        private SymbolTable<int, int> BuildBinarySearchTree()
        {
            var input = new int[] { 50, 25, 75, 15, 40, 60, 90, 10, 20, 35, 45, 55, 65, 85, 95 };
            var bst = new BinarySearchTree<int, int>();
            foreach (var i in input)
            {
                bst.Put(i, i);
            }
            return bst;
        }

        [Test]
        public void BSTFloorAndCeiling()
        {
            var bst = BuildBinarySearchTree();
            Assert.AreEqual(15, bst.Floor(18));
            Assert.AreEqual(55, bst.Ceiling(55));
        }

        [Test]
        public void BSTSelectAndRank()
        {
            var bst = BuildBinarySearchTree();
            Assert.AreEqual(50, bst.Select(7));
            Assert.AreEqual(85, bst.Select(12));

            Assert.AreEqual(7, bst.Rank(50));
            Assert.AreEqual(12, bst.Rank(85));
        }

        [Test]
        public void BSTDeleteMin()
        {
            var bst = BuildBinarySearchTree();
            Assert.AreEqual(10, bst.Min());
            bst.DeleteMin();
            Assert.AreEqual(15, bst.Min());
            bst.DeleteMin();
            Assert.AreEqual(20, bst.Min());
        }

        [Test]
        public void BSTDeleteMax()
        {
            var bst = BuildBinarySearchTree();
            Assert.AreEqual(95, bst.Max());
            bst.DeleteMax();
            Assert.AreEqual(90, bst.Max());
            bst.DeleteMax();
            Assert.AreEqual(85, bst.Max());
        }

        [Test]
        public void BSTDelete()
        {
            var bst = BuildBinarySearchTree();
            Assert.AreEqual(60, bst.Select(9));
            bst.Delete(60);
            Assert.AreEqual(65, bst.Select(9));
        }

        [Test]
        public void BSTKeys()
        {
            var bst = BuildBinarySearchTree();
            var keySet = bst.Keys(35, 55);
            Assert.AreEqual(new int[] { 35, 40, 45, 50, 55 }, keySet.ToArray());
        }

    }
}
