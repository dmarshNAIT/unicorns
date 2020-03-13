using System;
using System.Collections.Generic;

namespace Unicorns
{
    class Program
    {
        static void Main(string[] args)
        {
            string userResponse;

            do
            {
                ExplodingUnicornsGame game = new ExplodingUnicornsGame();
                game.PlayGame();

                userResponse = MethodLibrary.GetUserChoice("\nWanna play again?", "y", "n");

            } while (userResponse.ToLower() == "y");
            Console.WriteLine("Goodbye forever.");

        } // end method

    } // end Program class

} // end namespace
