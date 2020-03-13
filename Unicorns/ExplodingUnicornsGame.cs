using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorns
{
    class ExplodingUnicornsGame
    {
        private List<Player> players = new List<Player>();
        private List<Card.UnicornCard> nursery = new List<Card.UnicornCard>();
        private int unicornsToWin = 7;
        private bool gameOver;

        public void PlayGame()
        {
            const int MIN_PLAYERS = 2;
            const int MAX_PLAYERS = 8;

            int numPlayers = MethodLibrary.GetUserInt("How many players?", MIN_PLAYERS, MAX_PLAYERS, "You need more friends. Please enter a larger number.", "That's too many friends. Please enter a smaller number.");
            int humanPlayers = MethodLibrary.GetUserInt("And how many of those are human?", MIN_PLAYERS - 1, numPlayers, "You need at least one!", "That's more than the number of players. Please re-enter.");

            InitializeDrawPile();

            InitializePlayers(numPlayers, humanPlayers);

            // nursery list
            // draw pile -- when empty, reshuffle discard, or end game? 
            // discard pile

            for (int i = 0; i < players.Count; i++)
            {
                players[i].TakeTurn();
                CheckIfWinner(players);
            } // end for
        } // end method

        private void InitializePlayers(int totalPlayers, int humanPlayers)
        {
            Random random = new Random();
            for (int i = 0; i < totalPlayers; i++)
            {
                // add specified number of Human players, in random order:
                if (i < humanPlayers)
                    players.Insert(random.Next(players.Count + 1),
                        new Player(Player.PlayerType.Human, MethodLibrary.GetUserString("Human, what is your name?")));
                // otherwise add Computer players, in random order:
                else
                    players.Insert(random.Next(players.Count + 1), new Player());
            } // end for
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.Write($"Player {i + 1}: ");
                players[i].DisplayPlayer();
            } // end for

        } // end InitializePlayers method

        private void InitializeDrawPile()
        {
            // create all the cards we need

        } // end InitializeDrawPile()

        private void InitializeNursery()
        {
            

            // add baby unicorns

            

        } // end InitializeNursery()

        private void CheckIfWinner(List<Player> player)
        {
            bool gameOver = false;

            if (player.Count > 5)
                unicornsToWin = 6;

            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].GetNumberOfUnicorns() >= unicornsToWin)
                {
                    gameOver = true;
                    MethodLibrary.WriteInColour("THIS PLAYER HAS WON!", ConsoleColor.Magenta); // add player name.
                } // end if
            } // end for


        } // end CheckIfWinner()

        public static string RandomNameGenerator()
        {
            Random random = new Random();
            List<string> firstHalf = new List<string> { "Sparkly", "Cheerful", "Rainbow", "Happy", "Glitter",
                "Giggly", "Pink", "Fluffy", "Twinkly", "Best"};
            List<string> secondHalf = new List<string> { "Narwhal", "Unicorn", "Rainbow", "Sparkle", "Glitter",
                "Axolotl", "Kitten", "Fluffball", "Pupper", "Panda"};
            return firstHalf[random.Next(firstHalf.Count)] + secondHalf[random.Next(secondHalf.Count)];

        } // end RandomNameGenerator()

    } // end class
} // end namespace
