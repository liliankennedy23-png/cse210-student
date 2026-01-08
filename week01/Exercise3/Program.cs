using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            // Create random number generator
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            // Game loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Display number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask to play again
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();

        } while (playAgain == "yes");

    }
}
