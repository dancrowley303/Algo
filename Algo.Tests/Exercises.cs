using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests
{
    [TestFixture]
    public class Exercises
    {
        [Test]
        public void Go()
        {
            var arr = new int[] { 5, 8, 3, 4, 9, 4, 3, 7, 8, 4, 3, 7, 5 };
            //Sort.LomutoQuickSort(arr, 0, arr.Length - 1);
            Sort.DanQuickSort(arr, 0, arr.Length - 1);
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

            var newMatrix = Sort.RotateMatrix(matrix);
            Console.WriteLine();
        }

        [Test]
        public void SortThreeNumbers()
        {
            var result = Sort.SortThreeNumbers(15, 10, 5);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = Sort.SortThreeNumbers(15, 5, 10);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = Sort.SortThreeNumbers(10, 5, 15);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = Sort.SortThreeNumbers(10, 15, 5);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = Sort.SortThreeNumbers(5, 10, 15);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(15, result[2]);

            result = Sort.SortThreeNumbers(5, 15, 10);
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

        [Test]
        public void Parentheses()
        {            
            Assert.IsTrue(MatchParens("[()]{}{[()()]()}"));
            Assert.IsFalse(MatchParens("[(])"));
            Assert.IsTrue(MatchParens("(((((((((({{{{{{{{{{[[[[[[[[[[]]]]]]]]]]{}{}{}{}{}()()()()(){()[][]}}}}}}}}}}}))))))))))"));
        }

        [Test]
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

        [Test]
        public void InfixToPostfix()
        {
            var input = "3+4*2/(1-5)";
            var output = ShuntingYard(input);
            Assert.AreEqual("342*15-/+", output);
        }

        [Test]
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

        [Test]
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

        [Test]
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


        [Test]
        public void RemoveLastNode()
        {
            var first = new LinkedListNode<string>() { Item = "First" };
            var second = new LinkedListNode<string>() { Item = "Second" };
            var third = new LinkedListNode<string>() { Item = "Third" };
            var fourth = new LinkedListNode<string>() { Item = "Fourth" };
            var fifth = new LinkedListNode<string>() { Item = "Fifth" };

            first.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            RemoveLastNode<string>(first);

            Assert.IsNull(fourth.Next);
        }

    }
}
