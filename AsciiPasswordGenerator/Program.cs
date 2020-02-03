using System;

namespace AsciiPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var passModeStrings = new string[]
            {
                "All letters and special symbols",
                "All letters and digits",
                "Uppercase and lowercase letters",
                "Only uppercase letters",
                "Only lowercase letters",
                "Only digits",
                "Only special symbols"
            };

            Console.WriteLine("This is a console application that generates random passwords.");

            while (true)
            {
                Console.WriteLine("Please enter an integer to specify the type of password characters:" +
                                  $"\n-{passModeStrings[0]} => 1" +
                                  $"\n-{passModeStrings[1]}          => 2" +
                                  $"\n-{passModeStrings[2]} => 3" +
                                  $"\n-{passModeStrings[3]}          => 4" +
                                  $"\n-{passModeStrings[4]}          => 5" +
                                  $"\n-{passModeStrings[5]}                     => 6" +
                                  $"\n-{passModeStrings[6]}            => 7");

                var inputPassType = Console.ReadLine();
                if (int.TryParse(inputPassType, out int passwordType))
                {
                    link:
                    Console.WriteLine("Please enter an integer to specify the password length: ");
                    var inputPassLength = Console.ReadLine();
                    if (int.TryParse(inputPassLength, out int passwordLength))
                    {
                        Console.WriteLine("\nPassword: " + $"{PasswordGenerator.GeneratePassword(passwordLength, passwordType)}\r\n");
                    }
                    else
                    {
                        Console.WriteLine("Password length must be over 2 characters.\r\n");
                        goto link;
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct password type.\r\n");
                }
            }
        }
    }
}
