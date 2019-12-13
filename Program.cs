using System;
using System.Collections.Generic;

namespace Unicorns
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN_PLAYERS = 2;
            const int MAX_PLAYERS = 8;
            string userResponse;

            do
            {
                int numPlayers = MethodLibrary.GetUserInt("How many players?", MIN_PLAYERS, MAX_PLAYERS, "You need more friends. Please enter a larger number.", "That's too many friends. Please enter a smaller number.");
                int humanPlayers = MethodLibrary.GetUserInt("And how many of those are human?", MIN_PLAYERS - 1, numPlayers, "You need at least one!", "That's more than the number of players. Please re-enter.");

                InitializeDrawPile();

                List <Player> players = InitializePlayers(numPlayers, humanPlayers);

                // nursery list
                // draw pile -- when empty, reshuffle discard, or end game? 
                // discard pile

                for (int i = 0; i < players.Count; i++)
                {
                    players[i].TakeTurn();
                    bool gameOver = CheckIfWinner(players);
                } // end for

                userResponse = MethodLibrary.GetUserChoice("\nWanna play again?", "y", "n");

            } while (userResponse.ToLower() == "y");
            Console.WriteLine("Goodbye forever.");

        } // end method

        static List<Player> InitializePlayers(int totalPlayers, int humanPlayers)
        {
            List <Player> players = new List<Player>();
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
            for (int i = 0; i < totalPlayers; i++) {
                Console.Write($"Player {i + 1}: ");
                players[i].DisplayPlayer();
            } // end for

            return players;
   
        } // end InitializePlayers method

        static void InitializeDrawPile()
        {

        } // end InitializeDrawPile()

        static List<Card.UnicornCard> InitializeNursery()
        {
            List<Card.UnicornCard> nursery = new List<Card.UnicornCard>();

            // add baby unicorns

            return nursery;

        } // end InitializeNursery()

        static bool CheckIfWinner(List <Player> player)
        {
            bool gameOver = false;
            int unicornsToWin = 7;
            if (player.Count > 5)
                unicornsToWin = 6;

            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].GetNumberOfUnicorns() >= unicornsToWin) {
                    gameOver = true;
                    MethodLibrary.WriteInColour("THIS PLAYER HAS WON!", ConsoleColor.Magenta); // add player name.
                } // end if
            } // end for

            return gameOver; 

        } // end CheckIfWinner()

    } // end Program class

    class Card
    {
        enum CardCategory
        {
            Unicorn,
            Upgrade,
            Downgrade,
            Instant,
            Magic
        }
        private CardCategory CardType;
        private bool PlayDuringTurn;
        private bool PlayAnytime;
        private bool DiscardAfterUse;

        public Card() { } // end constructor

        public class UnicornCard : Card
        {
            enum UnicornCategory
            {
                BabyUnicorn,
                BasicUnicorn,
                MagicUnicorn
            }
            private UnicornCategory UnicornType; 
            public UnicornCard()
            {
                CardType = CardCategory.Unicorn;
            }
        } // end unicorn class

        class UpgradeCard : Card
        {
            public UpgradeCard()
            {
                CardType = CardCategory.Upgrade;
                PlayDuringTurn = true;
            } // end constructor
           
        } // end upgrade class
        
        class DowngradeCard : Card
        {
            public DowngradeCard()
            {
                CardType = CardCategory.Downgrade;
                PlayDuringTurn = true;
            } // end constructor
        } // end downgrade class

        class InstantCard : Card
        {
            public InstantCard()
            {
                CardType = CardCategory.Instant;
                PlayAnytime = true;
                DiscardAfterUse = true;
            } // end constructor

        } // end instant cards

        class MagicCard : Card
        {
            public MagicCard()
            {
                CardType = CardCategory.Magic;
                PlayDuringTurn = true;
                DiscardAfterUse = true;
            } // end constructor
        }
    } // end Card Class


    class Player
    {
        const int STARTING_HAND = 5; // CHECK THIS???
        const int HAND_LIMIT = 7;

        private List<Card> Stable = new List<Card>();
        private List<Card> Hand = new List<Card>();
        private PlayerType Type = PlayerType.Computer;
        private string Name { get; } = MethodLibrary.RandomNameGenerator(); // is this how get works??

        public enum PlayerType
        {
            Human,
            Computer
        } // end PlayerType enum

        public Player()
        {

        } // end default constructor

        public Player(PlayerType type, string name)
        {
            this.Type = type;
            this.Name = name;

            for (int i = 0; i < STARTING_HAND; i++)
            {
                Hand.Add(new Card());
            } // end for
        } // end constructor

        public void DisplayPlayer() {
            MethodLibrary.WriteInColour(this.Name, ConsoleColor.Magenta);
            MethodLibrary.WriteInColour($" is a {Type} player. They have ", ConsoleColor.Yellow);
            MethodLibrary.WriteInColour($"{Hand.Count}", ConsoleColor.Magenta);
            MethodLibrary.WriteInColour(" cards in their hand and ", ConsoleColor.Yellow);
            MethodLibrary.WriteInColour($"{Stable.Count}", ConsoleColor.Magenta);
            MethodLibrary.WriteInColour(" in their stable.", ConsoleColor.Yellow, writeLine: true);
        } // end DisplayPlayer

        public void TakeTurn()
        {

            // each turn:
            // 1. beginning of turn effecs
            // 2. draw 1 card from draw pile
            // 3. action phase: play 1 card or draw 1 more
            // 4. discard down to hand limit

        } // end TakeTurn()


        public int GetNumberOfUnicorns()
        {

            return 0; // change this
        } // end GetNumberOfUnicorns()


    } // end Player class

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

        public static string RandomNameGenerator()
        {
            Random random = new Random();
            List<string> firstHalf = new List<string> { "Sparkly", "Cheerful", "Rainbow", "Happy", "Glitter",
                "Giggly", "Pink", "Fluffy", "Twinkly", "Best"};
            List<string> secondHalf = new List<string> { "Narwhal", "Unicorn", "Rainbow", "Sparkle", "Glitter",
                "Axolotl", "Kitten", "Fluffball", "Pupper", "Panda"};
            return firstHalf[random.Next(firstHalf.Count)] + secondHalf[random.Next(secondHalf.Count)];

        } // end RandomNameGenerator()

    } // end MethodLibrary class

} // end namespace
