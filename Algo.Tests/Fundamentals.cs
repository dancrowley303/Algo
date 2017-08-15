using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests
{
    [TestFixture]
    public class Fundamentals
    {
        [Test]
        public void Go()
        {
            var arr = new int[] { 5, 8, 3, 4, 9, 4, 3, 7, 8, 4, 3, 7, 5 };
            //Sort.LomutoQuickSort(arr, 0, arr.Length - 1);
            SortExperiments.DanQuickSort(arr, 0, arr.Length - 1);
            //Sort.QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(arr);
        }

        [Test]
        public void RotateMatrix()
        {
            var matrix = new int[4][];
            matrix[0] = new int[] { 1, 2, 3, 4 };
            matrix[1] = new int[] { 5, 6, 7, 8 };
            matrix[2] = new int[] { 9, 10, 11, 12 };
            matrix[3] = new int[] { 13, 14, 15, 16 };

            var newMatrix = SortExperiments.RotateMatrix(matrix);
            Console.WriteLine();
        }

        [Test]
        public void SortThreeNumbers()
        {
            var result = SortExperiments.SortThreeNumbers(15, 10, 5);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = SortExperiments.SortThreeNumbers(15, 5, 10);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = SortExperiments.SortThreeNumbers(10, 5, 15);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = SortExperiments.SortThreeNumbers(10, 15, 5);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = SortExperiments.SortThreeNumbers(5, 10, 15);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = SortExperiments.SortThreeNumbers(5, 15, 10);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);
        }

        //[Test]
        //public void Binomial()
        //{
        //    Console.WriteLine(Sort.Binomial(100, 50, 0.25));
        //}

        [Test]
        public void Strings()
        {
            String s1 = "hello";
            String s2 = s1;
            s1 = "world";
            Assert.AreEqual("world", s1);
            Assert.AreEqual("hello", s2);
        }

        [Test]
        public void FindClosestPairOfPoints()
        {
            //use static seed so the test can always assert on the known closest distance
            var random = new Random(777);
            var n = random.Next() % 24;
            var points = new Point2D[n];
            for (var i = 0; i < n; i++)
            {
                points[i] = new Point2D(random.NextDouble() * 10, random.NextDouble() * 10);
            }

            Point2D closestLeft;
            Point2D closestRight;

            double closestDistance = double.MaxValue;
            double distance;

            for (var i = 0; i < n; i++)
            {
                for (var j = i+1; j < n; j++)
                {
                    distance = points[i].DistanceTo(points[j]);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestLeft = points[i];
                        closestRight = points[j];
                    }
                }
            }

            Assert.AreEqual(0.96934116120230318, closestDistance);
        }

        [Test]
        public void FindIntersecting()
        {
            var intervals = new Interval1D[5];
            intervals[0] = new Interval1D(0.2, 1.2);
            intervals[1] = new Interval1D(2.2, 4.2);
            intervals[2] = new Interval1D(3.4, 3.9);
            intervals[3] = new Interval1D(5.2, 7.6);
            intervals[4] = new Interval1D(8.4, 10.2);

            var sb = new StringBuilder();

            for (var i = 0; i < 5; i++)
            {
                for (var j = i+1; j < 5; j++)
                {
                    var left = intervals[i];
                    var right = intervals[j];
                    if (left.Intersects(right))
                    {
                        sb.AppendLine(string.Format("left [{0}], right [{1}]", left, right));
                    }
                }
            }

            Assert.AreEqual("left [min:2.2, max:4.2], right [min:3.4, max:3.9]\r\n", sb.ToString());
        }

        [Test]
        public void FindCircularShift()
        {
            var circularSearch = "CATDOGFISH";
            var validComparison = "DOGFISHCAT";
            var foundCircular = Search.IsInCircularShift(circularSearch, validComparison);
            Assert.IsTrue(foundCircular);

            var invalidComparison = "DOGFISHMONKEY";
            var notFoundCircular = Search.IsInCircularShift(circularSearch, invalidComparison);
            Assert.IsFalse(notFoundCircular);
        }
        
        [Test]
        public void ReverseString()
        {
            var original = "abcdefghijk";
            var reversed = Search.ReverseString(original);
            Assert.AreEqual("kjihgfedcba", reversed);
        }

        [Test]
        public void BinarySearchCounter()
        {
            int searchCount;
            var searchArray = new int[] { 4, 6, 7, 8, 12, 18, 24, 45, 66, 78, 193, 205, 318, 500, 1024, 888923 };
            var index = Search.IndexOf(searchArray, 6, out searchCount);
            Assert.AreEqual(1, index);
            Assert.AreEqual(3, searchCount);
        }

        [Test]
        public void DijkstraEval()
        {
            string expression = "( ( 5 + 10 ) - ( ( 4 / 2 ) * 4 ) )";
            var ops = new ResizingArrayStack<string>(1);
            var vals = new ResizingArrayStack<double>(1);

            var result = DijkstraExpressionEvaluation.Evaluate(ops, vals, expression);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void EnumeratingOnFixedStack()
        {
            var stack = new ResizingArrayStack<int>(1);
            stack.Push(10);
            stack.Push(15);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);

            var arr = stack.ToArray(); // because this uses the Enumerator

            Assert.AreEqual(new int[] { 40, 30, 20, 15, 10 }, arr);

        }

        [Test]
        public void LinkedLinkStack()
        {
            var stack = new LinkedListStack<string>();
            stack.Push("turtles");
            stack.Push("all");
            stack.Push("the");
            stack.Push("way");
            stack.Push("down");

            Assert.AreEqual("down", stack.Pop());
            Assert.AreEqual("way", stack.Pop());
            Assert.AreEqual("the", stack.Pop());
            Assert.AreEqual("all", stack.Pop());
            Assert.AreEqual("turtles", stack.Pop());
        }

        [Test]
        public void LinkedListQueue()
        {
            var queue = new LinkedListQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual(true, queue.IsEmpty());
        }

        [Test]
        public void LinkedListBag()
        {
            var bag = new LinkedListBag<int>();
            bag.Add(5);
            bag.Add(10);
            bag.Add(15);

            var arr = new int[3];
            int i = 0;
            foreach(var item in bag)
            {
                arr[i++] = item;
            }
            Assert.Contains(5, arr);
            Assert.Contains(10, arr);
            Assert.Contains(15, arr);
        }

        private bool MatchParens(string input)
        {
            var parens = new ResizingArrayStack<char>(1);
            foreach (var i in input)
            {
                switch (i)
                {
                    case '[':
                    case '(':
                    case '{':
                        parens.Push(i);
                        break;
                    case ']':
                        if (parens.IsEmpty() || parens.Pop() != '[') return false;
                        break;
                    case ')':
                        if (parens.IsEmpty() || parens.Pop() != '(') return false;
                        break;
                    case '}':
                        if (parens.IsEmpty() || parens.Pop() != '{') return false;
                        break;
                    default:
                        break;
                }
            }
            return true;

        }

        [Test] // 1.3.4
        public void Parentheses()
        {            
            Assert.IsTrue(MatchParens("[()]{}{[()()]()}"));
            Assert.IsFalse(MatchParens("[(])"));
            Assert.IsTrue(MatchParens("(((((((((({{{{{{{{{{[[[[[[[[[[]]]]]]]]]]{}{}{}{}{}()()()()(){()[][]}}}}}}}}}}}))))))))))"));
        }

        [Test] // 1.3.9
        public void InsertLeftParens()
        {
            var inserted = InsertParens("1+2)*3-4)*5-6)))");
            Assert.AreEqual("((1+2)*((3-4)*(5-6)))", inserted);

        }

        private string InsertParens(string input)
        {
            LinkedListStack<string> stack = new LinkedListStack<string>();

            foreach (var i in input)
            {
                if (i.Equals(')'))
                {
                    string expression = ")";
                    for (var j = 0; j < 3; j++)
                    {
                        expression = stack.Pop() + expression;
                    }
                    expression = "(" + expression;
                    stack.Push(expression);
                }
                else
                {
                    stack.Push(i.ToString());
                }
            }

            return stack.First();
        }

        private int OperatorPrecedence(char c)
        {
            switch (c)
            {
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;
                default:
                    return 0;
            }
        }

        private bool IsOperator(char c)
        {
            return OperatorPrecedence(c) > 0;
        }

        private string ShuntingYard(string input)
        {
            LinkedListStack<char> operators = new LinkedListStack<char>();
            Queue<char> output = new LinkedListQueue<char>();

            foreach(var i in input)
            {
                if (Char.IsNumber(i)) output.Enqueue(i);
                if (IsOperator(i))
                {
                    while (!operators.IsEmpty() && OperatorPrecedence(operators.Peek()) >= OperatorPrecedence(i))
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Push(i);
                }
                if (i == '(') operators.Push(i);
                if (i == ')')
                {
                    while (operators.Peek() != '(')
                        output.Enqueue(operators.Pop());
                    operators.Pop();
                }
            }
            while (!operators.IsEmpty())
            {
                output.Enqueue(operators.Pop());
            }

            return new string(output.ToArray());
        }

        public decimal EvaluatePostfix(string input)
        {
            LinkedListStack<decimal> stack = new LinkedListStack<decimal>();
            
            foreach (var i in input)
            {
                if (IsOperator(i))
                {
                    decimal result;
                    var right = decimal.Parse(stack.Pop().ToString());
                    var left = decimal.Parse(stack.Pop().ToString());
                    switch (i)
                    {
                        case '+':
                            result = left + right;
                            break;
                        case '-':
                            result = left - right;
                            break;
                        case '*':
                            result = left * right;
                            break;
                        case '/':
                            result = left / right;
                            break;
                        default:
                            result = 0;
                            break;
                    }
                    stack.Push(result);
                }
                else
                {
                    stack.Push(decimal.Parse(i.ToString()));
                }
            }
            return stack.First();
        }

        [Test] // 1.3.10
        public void InfixToPostfix()
        {
            var input = "3+4*2/(1-5)";
            var output = ShuntingYard(input);
            Assert.AreEqual("342*15-/+", output);
        }

        [Test] // 1.3.11
        public void EvaluatePostfix()
        {
            var input = "342*15-/+";
            Assert.AreEqual(1, EvaluatePostfix(input));
        }

        private Stack<string> CopyStack(Stack<string> source)
        {
            var reverse = new LinkedListStack<string>();
            var output = new LinkedListStack<string>();
            foreach(var item in source)
            {
                reverse.Push(item);
            }

            foreach(var item in reverse)
            {
                output.Push(item);
            }
            return output;
        }

        [Test] // 1.3.12
        public void CopyStack()
        {
            var input = new LinkedListStack<string>();
            input.Push("three");
            input.Push("two");
            input.Push("one");
            Assert.AreEqual(new string[]{ "one", "two", "three"}, input.ToArray());

            var output = CopyStack(input);
            Assert.AreEqual(output.ToArray(), input.ToArray());
        }

        [Test] // 1.3.14
        public void ResizeQueue()
        {
            var queue = new ResizingArrayQueue<string>(2);
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            Assert.AreEqual("a", queue.Dequeue());
            queue.Enqueue("d");
            queue.Enqueue("e");
            Assert.AreEqual("b", queue.Dequeue());
            queue.Enqueue("f");
            queue.Enqueue("g");
            Assert.AreEqual("c", queue.Dequeue());
            queue.Enqueue("h");
            queue.Enqueue("i");
            queue.Enqueue("j");
            Assert.AreEqual("d", queue.Dequeue());

            Assert.AreEqual("e", queue.Dequeue());
            Assert.AreEqual("f", queue.Dequeue());
            Assert.AreEqual("g", queue.Dequeue());
            Assert.AreEqual("h", queue.Dequeue());
            Assert.AreEqual("i", queue.Dequeue());
            Assert.AreEqual("j", queue.Dequeue());

            for (int i = 0; i < 32; i ++)
            {
                queue.Enqueue("1");
                Assert.AreEqual("1", queue.Dequeue());
            }

            for (int i = 0; i < 32; i++)
            {
                queue.Enqueue("2");
            }

            for (int i = 0; i < 32; i++)
            {
                queue.Enqueue("3");
                Assert.AreEqual("2", queue.Dequeue());
            }

            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual("3", queue.Dequeue());
            }

        }

        private void RemoveLastNode<T>(LinkedListNode<T> first)
        {
            var current = first;
            //var current = first;
            //var next = current.Next;
            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        private LinkedListNode<string>[] BuildFiveLinkedStringNodes()
        {
            var nodes = new LinkedListNode<string>[5];


            nodes[0] = new LinkedListNode<string>() { Item = "First" };
            nodes[1] = new LinkedListNode<string>() { Item = "Second" };
            nodes[2] = new LinkedListNode<string>() { Item = "Third" };
            nodes[3] = new LinkedListNode<string>() { Item = "Fourth" };
            nodes[4] = new LinkedListNode<string>() { Item = "Fifth" };

            nodes[0].Next = nodes[1];
            nodes[1].Next = nodes[2];
            nodes[2].Next = nodes[3];
            nodes[3].Next = nodes[4];

            return nodes;
        }


        [Test]
        public void RemoveLastNode()
        {
            var nodes = BuildFiveLinkedStringNodes();
            RemoveLastNode<string>(nodes[0]);
            Assert.IsNull(nodes[3].Next);
        }

        private void DeleteNodeInLinkedList<T>(LinkedListNode<T> first, int k)
        {
            var current = first;
            for (var i = 1; i < k - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next?.Next;
        }

        [Test] // 1.3.20
        public void Delete()
        {
            var nodes = BuildFiveLinkedStringNodes();
            DeleteNodeInLinkedList<string>(nodes[0], 5);
            Assert.AreEqual(nodes[1].Next, nodes[3]);
        }

        private bool FindInLinkedList<T>(LinkedListNode<T> first, T searchItem)
        {
            var current = first;
            do
            {
                if (current.Item.Equals(searchItem)) return true;
                current = current.Next;
            } while (current != null);

            return false;
        }

        [Test] // 1.3.21
        public void FindInLinkedList()
        {
            var nodes = BuildFiveLinkedStringNodes();
            Assert.IsTrue(FindInLinkedList(nodes[0], "Fifth"));
        }

        private void RemoveAfter<T>(LinkedListNode<T> current)
        {
            if (current == null) return;
            current.Next = current?.Next?.Next;
        }

        [Test] // 1.3.24
        public void RemoveAfter()
        {
            var nodes = BuildFiveLinkedStringNodes();
            RemoveAfter(nodes[2]);
            Assert.AreEqual(nodes[4], nodes[2].Next);
            RemoveAfter(nodes[4]);
            Assert.AreEqual(null, nodes[4].Next);
        }

        private void InsertAfter<T>(LinkedListNode<T> current, LinkedListNode<T> insert)
        {
            insert.Next = current.Next;
            current.Next = insert;
        }

        [Test] // 1.3.25
        public void InsertAfter()
        {
            var nodes = BuildFiveLinkedStringNodes();
            var newNode = new LinkedListNode<string>() { Item = "Insert" };
            InsertAfter(nodes[3], newNode);
            Assert.AreEqual(newNode, nodes[3].Next);
            Assert.AreEqual(nodes[4], newNode.Next);
        }

        private void Remove<T>(LinkedListNode<T> first, T key)
        {
            var previous = first;
            var current = previous;
            while (current != null)
            {
                if (current.Item.Equals(key))
                {
                    previous.Next = current.Next;
                }
                previous = current;
                current = current.Next;
            }             
        }

        [Test] // 1.3.26
        public void Remove()
        {
            var nodes = BuildFiveLinkedStringNodes();
            var otherFirst = new LinkedListNode<string>() { Item = "Second" };
            InsertAfter(nodes[3], otherFirst);
            var anotherFirst = new LinkedListNode<string>() { Item = "Second" };
            InsertAfter(nodes[4], anotherFirst);

            Remove(nodes[0], "Second");

            Assert.AreEqual(nodes[2], nodes[0].Next);
            Assert.AreEqual(nodes[4], nodes[3].Next);
            Assert.IsNull(nodes[4].Next);
        }

        private int LinkedListMax(LinkedListNode<int> first)
        {
            var current = first;
            int max = 0;
            while (current != null)
            {
                if (current.Item > max) max = current.Item;
                current = current.Next;
            }
            return max;
        }

        private LinkedListNode<int>[] BuildFiveLinkedIntNodes()
        {
            var nodes = new LinkedListNode<int>[5];

            nodes[0] = new LinkedListNode<int> { Item = 1 };
            nodes[1] = new LinkedListNode<int> { Item = 2 };
            nodes[2] = new LinkedListNode<int> { Item = 3 };
            nodes[3] = new LinkedListNode<int> { Item = 4 };
            nodes[4] = new LinkedListNode<int> { Item = 5 };

            nodes[0].Next = nodes[1];
            nodes[1].Next = nodes[2];
            nodes[2].Next = nodes[3];
            nodes[3].Next = nodes[4];

            return nodes;
        }

        [Test] // 1.3.27
        public void LinkedListMax()
        {
            var items = BuildFiveLinkedIntNodes();
            Assert.AreEqual(5, LinkedListMax(items[0]));
        }

        private int LinkedListMaxRecursive(LinkedListNode<int> current, int max = 0)
        {
            if (current == null) return max;
            if (current.Item > max)
            {
                return LinkedListMaxRecursive(current.Next, current.Item);
            } else
            {
                return LinkedListMaxRecursive(current.Next, max);
            }
        }

        [Test] // 1.3.28
        public void LinkedListMaxRecursive()
        {
            var items = BuildFiveLinkedIntNodes();
            items[3].Item = 300;
            Assert.AreEqual(300, LinkedListMaxRecursive(items[0]));
        }

        [Test] // 1.3.29
        public void CircularQueue()
        {
            var cq = new CircularQueue<int>();
            cq.Enqueue(5);
            Assert.AreEqual(5, cq.Dequeue());
            cq.Enqueue(10);
            cq.Enqueue(15);
            cq.Enqueue(20);
            Assert.AreEqual(10, cq.Dequeue());
            Assert.AreEqual(15, cq.Dequeue());
            Assert.AreEqual(20, cq.Dequeue());
        }

        private DoubleNode<int> BuildFiveDoubleIntNodesAscending()
        {
            DoubleNode<int> previous = null;
            DoubleNode<int> newNode = null;
            for (var i = 0; i < 5; i++)
            {
                newNode = new DoubleNode<int> { Item = i };
                DoubleNode<int>.InsertAtBeginning(previous, newNode);
                previous = newNode;

            }
            return newNode;
        }

        [Test] // 1.3.31
        public void DoubleNode()
        {
            var firstNode = BuildFiveDoubleIntNodesAscending();
            var topNode = new DoubleNode<int> { Item = 999 };
            DoubleNode<int>.InsertAtBeginning(firstNode, topNode);
            Assert.AreEqual(999, DoubleNode<int>.First(firstNode).Item);

            var newLastNode = new DoubleNode<int> { Item = 100 };
            DoubleNode<int>.InsertAtEnd(firstNode, newLastNode);
            Assert.AreEqual(100, DoubleNode<int>.Last(topNode).Item);

            var lastNode = newLastNode.Previous;

            Assert.AreEqual(999, DoubleNode<int>.First(newLastNode).Item);
            DoubleNode<int>.RemoveFromBeginning(newLastNode);
            Assert.AreEqual(4, DoubleNode<int>.First(newLastNode).Item);

            Assert.AreEqual(100, DoubleNode<int>.Last(firstNode).Item);
            DoubleNode<int>.RemoveFromEnd(firstNode);
            Assert.AreEqual(0, DoubleNode<int>.Last(firstNode).Item);

            Assert.AreEqual(4, DoubleNode<int>.First(lastNode).Item);
            DoubleNode<int>.InsertBefore(firstNode, new DoubleNode<int> { Item = 555 });
            Assert.AreEqual(555, firstNode.Previous.Item);

            Assert.AreEqual(4, firstNode.Item);
            Assert.AreEqual(3, firstNode.Next.Item);
            var new222 = new DoubleNode<int> { Item = 222 };
            DoubleNode<int>.InsertAfter(firstNode, new222);
            Assert.AreEqual(222, firstNode.Next.Item);
            Assert.AreEqual(3, firstNode.Next.Next.Item);

            Assert.AreEqual(222, firstNode.Next.Item);
            DoubleNode<int>.RemoveNode(firstNode, new222);
            Assert.AreEqual(3, firstNode.Next.Item);
            Assert.AreEqual(4, firstNode.Next.Previous.Item);
        }

    }
}
