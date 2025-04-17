using System;

namespace SimpleMastermind
{
    class Program
    {
        static void Main()
        {
            const int codeLength = 4;
            const int minDigit = 1;
            const int maxDigit = 6;
            const int maxAttempts = 10;

            var random = new Random();
            int[] secretCode = new int[codeLength];

            // Generate random 4-digit code using numbers 1–6
            for (int i = 0; i < codeLength; i++)
            {
                secretCode[i] = random.Next(minDigit, maxDigit + 1);
            }

            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Guess the 4-digit code. Each digit is between 1 and 6.");
            Console.WriteLine("You will receive '+' for correct digits in the correct position,");
            Console.WriteLine("and '-' for correct digits in the wrong position.");
            Console.WriteLine();

            int attempts = 0;
            bool guessedCorrectly = false;

            while (attempts < maxAttempts && !guessedCorrectly)
            {
                Console.Write($"Attempt {attempts + 1}/{maxAttempts} - Enter your guess: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Length != codeLength || !IsValidInput(input, minDigit, maxDigit))
                {
                    Console.WriteLine($"Invalid input. Please enter exactly {codeLength} digits between {minDigit} and {maxDigit}.");
                    continue;
                }

                int[] guess = new int[codeLength];
                for (int i = 0; i < codeLength; i++)
                {
                    guess[i] = int.Parse(input[i].ToString());
                }

                string feedback = GetFeedback(secretCode, guess);
                Console.WriteLine(feedback);
                Console.WriteLine();

                if (feedback == "++++")
                {
                    guessedCorrectly = true;
                    Console.WriteLine("Congratulations! You guessed the code!");
                }

                attempts++;
            }

            if (!guessedCorrectly)
            {
                Console.Write("Sorry, you're out of attempts. The correct code was: ");
                Console.WriteLine(string.Join("", secretCode));
            }
        }

        static bool IsValidInput(string input, int min, int max)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c) || c < (char)(min + '0') || c > (char)(max + '0'))
                    return false;
            }
            return true;
        }

        static string GetFeedback(int[] secret, int[] guess)
        {
            bool[] secretUsed = new bool[secret.Length];
            bool[] guessUsed = new bool[guess.Length];
            int plus = 0;
            int minus = 0;

            // First pass: check for correct position
            for (int i = 0; i < secret.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    plus++;
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }

            // Second pass: check for correct digit, wrong position
            for (int i = 0; i < guess.Length; i++)
            {
                if (guessUsed[i]) continue;

                for (int j = 0; j < secret.Length; j++)
                {
                    if (!secretUsed[j] && guess[i] == secret[j])
                    {
                        minus++;
                        secretUsed[j] = true;
                        break;
                    }
                }
            }

            return new string('+', plus) + new string('-', minus);
        }
    }
}
