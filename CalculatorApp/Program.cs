namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("-----------------");

            double num1;
            try {
                Console.Write("Enter the first number: ");
                string input1 = Console.ReadLine();
                num1 = double.Parse(input1);
            }catch(FormatException)
            {
                Console.WriteLine("That is not a valid number. Please restart the calculator.");
            }
            

            Console.Write("Enter an operator (+, -, *, /): ");
            string op = Console.ReadLine();

            double num2;
            try
            {
                Console.Write("Enter the second number: ");
                string input2 = Console.ReadLine();
                double num2 = double.Parse(input2);
            }catch(Exception ex)
            {
                Console.WriteLine("That is not a valid number. Please restart the calculator.");
            }

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
