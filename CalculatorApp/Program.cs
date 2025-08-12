namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("-----------------");

            Console.Write("Enter the first number: ");
            string input1 = Console.ReadLine();
            double num1 = double.Parse(input1);

            Console.Write("Enter an operator (+, -, *, /): ");
            string op = Console.ReadLine();

            Console.Write("Enter the second number: ");
            string input2 = Console.ReadLine();
            double num2 = double.Parse(input2);

            double result = 0; 

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break; 
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                        return; 
                    }
                    break;
                default:
                   
                    Console.WriteLine("Invalid operator.");
                    return; 
            }

            
            Console.WriteLine("Result: " + result);

        }
    }
}
