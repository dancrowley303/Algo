using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class DijkstraExpressionEvaluation
    {
        public static double Evaluate(Algo.Stack<string> ops, Algo.Stack<double> vals, string expression)
        {

            foreach(var token in expression.Split(' '))
            {
                switch (token)
                {
                    case "(":
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "sqrt":
                        ops.Push(token);
                        break;
                    case ")":
                        var op = ops.Pop();
                        var val = vals.Pop();
                        if (op.Equals("+")) val = vals.Pop() + val;
                        if (op.Equals("-")) val = vals.Pop() - val;
                        if (op.Equals("*")) val = vals.Pop() * val;
                        if (op.Equals("/")) val = vals.Pop() / val;
                        if (op.Equals("sqrt")) val = Math.Sqrt(val);
                        vals.Push(val);
                        break;
                    default:
                        vals.Push(double.Parse(token));
                        break;
                }
            }
            return vals.Pop();
        }
    }
}
