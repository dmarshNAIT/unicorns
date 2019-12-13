using System;

namespace Unicorns
{
    class Program {
        static void Main(string[] args) {
            const int HAND_LIMIT = 7;
            const int MIN_PLAYERS = 2;
            const int MAX_PLAYERS = 8;
            string userResponse;

            do
            {
                int numPlayers = GetUserInt("How many players?", MIN_PLAYERS, MAX_PLAYERS);
                int humanPlayers = GetUserInt("And how many of those are human?", MIN_PLAYERS - 1, numPlayers);

                // nursery list
                // draw pile -- when empty, reshuffle discard, or end game? 
                // discard pile

                // each turn:
                // 1. beginning of turn effecs
                // 2. draw 1 card from draw pile
                // 3. action phase: play 1 card or draw 1 more
                // 4. discard down to hand limit

                // how to win:
                // 2-5 players need 7 unicorns
                // 6-8 need 6

                userResponse = GetUserString("Wanna play again?", "y", "n");


            } while (userResponse.ToLower() == "y");
            Console.WriteLine("Goodbye forever.");

        } // end method

        static void DisplayInColour(string message, ConsoleColor colour) {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ResetColor();
        } // end DisplayInColour method

        static int GetUserInt(string prompt, int minNum, int maxNum)
        {
            int response = 0;
            bool isValid = false;
            Console.WriteLine(prompt);
            do {
                try {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    response = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    if (response < minNum)
                        DisplayInColour("You need more friends. Please enter a larger number.", ConsoleColor.Red);
                    else if (response > maxNum)
                        DisplayInColour("That's too many friends. Please enter a smaller number.", ConsoleColor.Red);
                    else
                        isValid = true;
                } // end try
                catch (Exception) {
                    DisplayInColour("That's not a number. Please re-enter.", ConsoleColor.Red);

                } // end catch
            } while (!isValid);

            return response;
        
        } // end method

        static string GetUserString(string prompt, string firstChoice, string secondChoice)
        {
            Console.WriteLine(prompt + $" ({firstChoice}/{secondChoice})");
            Console.ForegroundColor = ConsoleColor.Cyan;

            string userResponse = Console.ReadLine();
            Console.ResetColor();

            while (userResponse.ToLower() != firstChoice && userResponse.ToLower() != secondChoice)
            {
                DisplayInColour("That wasn't a valid choice. Please re-enter.", ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Cyan;
                userResponse = Console.ReadLine();
                Console.ResetColor();
            } // end while invalid entry

            return userResponse;
        } // end GetUserString method

    } // end Program class


    class Unicorn {
        // property: baby or basic or magic
    } // end unicorn class

    class UpgradeCard {
        // can be played during a turn
    } // end upgrade class


    class DowngradeCard {
        // can be played during a turn
    } // end downgrade class

    class InstantCard {
        // can be played anytime
        // send to discard after use
    } // end instant cards

    class MagicCard {
        // can be played during turn
        // then sent to Discard
    }

    class Player {
        // stable list
        // their hand

    } // end Player class


} // end namespace
