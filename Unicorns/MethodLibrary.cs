using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorns
{
    class MethodLibrary
    {
        public static int GetUserInt(string prompt, int minNum, int maxNum, string tooLowMessage, string tooHighMessage)
        {
            int response = 0;
            bool isValid = false;
            Console.WriteLine(prompt);
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    response = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    if (response < minNum)
                        MethodLibrary.WriteInColour(tooLowMessage, ConsoleColor.Red, writeLine: true);
                    else if (response > maxNum)
                        MethodLibrary.WriteInColour(tooHighMessage, ConsoleColor.Red, writeLine: true);
                    else
                        isValid = true;
                } // end try
                catch (Exception)
                {
                    MethodLibrary.WriteInColour("That's not a number. Please re-enter.", ConsoleColor.Red, writeLine: true);

                } // end catch
            } while (!isValid);

            return response;

        } // end method

        public static string GetUserChoice(string prompt, string firstChoice, string secondChoice)
        {
            Console.WriteLine(prompt + $" ({firstChoice}/{secondChoice})");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string userResponse = Console.ReadLine();
            Console.ResetColor();

            while (userResponse.ToLower() != firstChoice && userResponse.ToLower() != secondChoice)
            {
                MethodLibrary.WriteInColour("That wasn't a valid choice. Please re-enter.", ConsoleColor.Red, writeLine: true);
                Console.ForegroundColor = ConsoleColor.Cyan;
                userResponse = Console.ReadLine();
                Console.ResetColor();
            } // end while invalid entry

            return userResponse;
        } // end GetUserChoice method

        public static string GetUserString(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string userResponse = Console.ReadLine();
            Console.ResetColor();

            return userResponse;
        } // end GetUserString method

        public static void WriteInColour(string message, ConsoleColor colour, bool writeLine = false)
        {
            Console.ForegroundColor = colour;
            Console.Write(message);
            if (writeLine)
                Console.WriteLine();
            Console.ResetColor();
        } // end DisplayInColour method



    } // end MethodLibrary class
} // end namespace
