/*

Create a console application that will compile all our activities from Activity 1 - 5.

Activity 1 - PH Money Denomination
Activity 2 - Number Divisibility by 3 and 5
Activity 3 - Input Message
Activity 4 - Build Pyramid
Activity 5 - Sum vs. Append

Allow user input to required variables in each activity.

User will be prompted to enter activity number, which loads the corresponding activity.
If activity does not exists, prompt "Activity does not exits." and prompt the user to enter correct value.

If user input invalid value, prompt "Invalid input," and prompt the user to enter correct value.

*/ 

using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("PCCO104 Activity Compilation");
        Console.WriteLine(" ");

        while (true)
        {
            Console.Write("Enter activity number (1-5) or 'exit' to quit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            if (!int.TryParse(input, out int activityNumber) || activityNumber < 1 || activityNumber > 5)
            {
                Console.WriteLine("Activity does not exist.");
                continue;
            }

            switch (activityNumber)
            {
                case 1:
                    MoneyDenomination();
                    break;
                case 2:
                    NumberDivisibility();
                    break;
                case 3:
                    InputMessage();
                    break;
                case 4:
                    BuildPyramid();
                    break;
                case 5:
                    SumAppend();
                    break;
            }
        }
    }

    static void MoneyDenomination()
    {
        Console.Write("Enter denomination: ");
        double denomination = Convert.ToDouble(Console.ReadLine());
        string personality = getPersonality(denomination);
        Console.WriteLine($"Personality found on the {denomination} bank note: {personality}");
    }

    static void NumberDivisibility()
    {
        Console.Write("Input a number: ");
        int numdiv = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= numdiv; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine($"{i} - FooBar");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine($"{i} - Foo");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine($"{i} - Bar");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    static void InputMessage()
    {
        string output = "";
        string input = "";
        do
        {
            Console.Write("Enter Input: ");
            input = Console.ReadLine();
            if (input != "exit")
            {
                output += input + " ";
                Console.WriteLine("Output: " + output.Trim());
            }
            else
            {
                Console.WriteLine("Output: exit");
                break;
            }
        } while (true);
        Console.WriteLine("Exiting Program...");
    }

    static void BuildPyramid()
    {
        int inputValue;
        do
        {
            Console.Write("Enter a non-negative number (0 to exit): ");
            if (!int.TryParse(Console.ReadLine(), out inputValue))
            {
                Console.WriteLine("Invalid input. Please enter a valid non-negative number.");
                continue;
            }

            if (inputValue == 0)
            {
                Console.WriteLine("Exiting program...");
                return;
            }

            if (inputValue < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
                continue;
            }

            for (int i = 1; i <= inputValue; i++)
            {
                for (int j = 1; j <= inputValue - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        } while (true);
    }

    static void SumAppend()
    {
        int sum = 0;
        string message = "";

        while (true)
        {
            Console.Write("Enter something: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Closing program...");
                break;
            }

            int number;
            bool isNumeric = int.TryParse(input, out number);

            if (isNumeric)
            {
                sum += number;
                Console.WriteLine($"Adding {number} to {sum - number} = {sum}");
            }
            else
            {
                message += input;
                Console.WriteLine($"Current message is: {message}");
            }
        }
    }

    static string getPersonality(double denomination)
    {
        switch (denomination)
        {
            case 0.01:
            case 0.05:
            case 0.25:
                return "No Person is found";
            case 1:
                return "Jose Rizal";
            case 5:
                return "Emilio Aguinaldo";
            case 10:
                return "Andres Bonifacio & Apolinario Mabini";
            case 20:
                return "Manuel L. Quezon";
            case 50:
                return "Sergio Osmena";
            case 100:
                return "Manuel Roxas";
            case 200:
                return "Diosdado Macapagal";
            case 500:
                return "Benigno Sr. & Corazon Aquino";
            case 1000:
                return "Jose Abad Santos, Vicente Lim & Josefa Llanes Escoda";
            default:
                return $"Invalid Denomination: {denomination}";
        }
    }
}