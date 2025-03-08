using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        DisplayWelcome();
        
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        
        DisplayResult(userName, squaredNumber);

        // === Full Name Program ===
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine()?.Trim();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("Error: You must enter both a first name and a last name.");
        }
        else
        {
            Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        }

        // === Grade to Letter Conversion Program ===
        Console.WriteLine("\nEnter your percentage grade: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int score) && score >= 0 && score <= 100)
        {
            string letter;
            string sign = "";

            if (score >= 90) letter = "A";
            else if (score >= 80) letter = "B";
            else if (score >= 70) letter = "C";
            else if (score >= 60) letter = "D";
            else letter = "F";

            int lastDigit = score % 10;
            if (letter != "F")
            {
                if (letter != "A" && lastDigit >= 7) sign = "+";
                else if (lastDigit < 3) sign = "-";
            }

            Console.WriteLine($"Your grade is: {letter}{sign}");
            Console.WriteLine(score >= 70 ? "Congratulations, you passed the course!" : "Sorry, you need to try again. Don't give up!");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an integer between 0 and 100.");
        }

        // === Guess My Number Game ===
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = 0, attempts = 0;

            Console.WriteLine("\nWelcome to the 'Guess My Number' game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? (Type 'exit' to stop playing): ");
                string inputGuess = Console.ReadLine();

                if (inputGuess.ToLower() == "exit")
                {
                    Console.WriteLine("You have exited the game.");
                    return;
                }

                if (int.TryParse(inputGuess, out guess))
                {
                    attempts++;
                    if (guess < magicNumber) Console.WriteLine("Higher");
                    else if (guess > magicNumber) Console.WriteLine("Lower");
                    else Console.WriteLine($"You guessed it! It took you {attempts} attempts.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        // === List and Generics Program ===
        List<int> numbers = new List<int>();
        Console.WriteLine("\nEnter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string numInput = Console.ReadLine();

            if (int.TryParse(numInput, out int num))
            {
                if (num == 0) break;
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input, please enter an integer.");
            }
        }

        // Compute sum
        int sum = 0;
        foreach (int number in numbers) sum += number;
        Console.WriteLine($"The sum is: {sum}");

        // Compute average
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number
        int max = numbers.Count > 0 ? numbers[0] : 0;
        foreach (int number in numbers) if (number > max) max = number;
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers) if (number > 0 && number < smallestPositive) smallestPositive = number;
        if (smallestPositive != int.MaxValue) Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch Challenge: Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers) Console.WriteLine(number);

        Console.WriteLine("Thanks for playing!");
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}

