using System;
using System.Text;

namespace CalculatronV2
{
    class Program
    {
        public delegate string CalculateDelegate(int a, int b);

        static void Calculate(CalculateDelegate calculate, string calculation)
        {
            int[] operands = new int[2];
            ShowCalculation(calculation);
            operands = GetInputs();
            Console.WriteLine("\t" + calculate(operands[0], operands[1]));
            Console.Write("\t> ");
            Console.ReadKey();
            DisplayMenu();
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\tCalculatron V2");
            Console.WriteLine("\t--------------");
            Console.WriteLine("\t1. Add");
            Console.WriteLine("\t2. Subtract");
            Console.WriteLine("\t3. Multiply");
            Console.WriteLine("\t4. Divide");
            Console.WriteLine("");
            Console.WriteLine("\t9. Exit");
            Console.Write("\t> ");
        }

        public static string Add(int a, int b)
        {
            return (a + b).ToString();
        }

        public static string Subtract(int a, int b)
        {
            return (a - b).ToString();
        }

        public static string Multiply(int a, int b)
        {
            return (a * b).ToString();
        }

        public static string Divide(int a, int b)
        {
            if (b == 0)
                return "Cannot divide by zero";
            StringBuilder sb = new StringBuilder();
            sb.Append((a / b).ToString());
            sb.Append(" with remainder ");
            sb.Append((a % b).ToString());

            return sb.ToString();
        }

        public static void ShowCalculation(string operation)
        {
            Console.Clear();
            Console.WriteLine("\t" + operation);
            Console.WriteLine("\t--------------");
        }

        public static int[] GetInputs()
        {
            int[] returnvalue = new int[2];
            Console.WriteLine("\tWhat is the first operand?");
            Console.Write("\t> ");
            returnvalue[0] = int.TryParse(Console.ReadLine(), out int inputa) ? inputa : 0;
            Console.WriteLine("\tWhat is the second operand?");
            Console.Write("\t> ");
            returnvalue[1] = int.TryParse(Console.ReadLine(), out int inputb) ? inputb : 0;
            return returnvalue;
        }

        static void Main(string[] args)
        {
            int function;

            do
            {
                DisplayMenu();
                //Read input from user
                function = int.TryParse(Console.ReadLine(), out function) ? function : 0;
                switch (function)
                {
                    case 1:
                        Calculate(Add, "Addition");
                        break;
                    case 2:
                        Calculate(Subtract, "Subtraction");
                        break;
                    case 3:
                        Calculate(Multiply, "Multiplication");
                        break;
                    case 4:
                        Calculate(Divide, "Division");
                        break;
                    default:
                        break;
                }
            } while (function != 9);
        }
    }
}
