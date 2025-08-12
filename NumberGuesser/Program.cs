namespace NumberGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Generate a secret number between 1 and 100.
            int secretNumber = random.Next(1, 101);

            Console.WriteLine("I'm thinking of a number between 1 and 100.");
            Console.WriteLine("Can you guess what it is?");

            while (true)
            {
                Console.Write("Enter your guess: "); // Use Write instead of WriteLine to keep the cursor on the same line.

                string userInput = Console.ReadLine(); 

                int playerGuess = int.Parse(userInput); 

                if(playerGuess > secretNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else if(playerGuess < secretNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine("You got it! The secret number was " + secretNumber);
                    break;
                }
            }
        }
    }
}
