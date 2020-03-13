using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorns
{
    class Player
    {
        const int STARTING_HAND = 5; // CHECK THIS???
        const int HAND_LIMIT = 7;

        private List<Card> Stable = new List<Card>();
        private List<Card> Hand = new List<Card>();
        private PlayerType Type = PlayerType.Computer;
        private string Name { get; } = ExplodingUnicornsGame.RandomNameGenerator(); // is this how get works??

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

        public void DisplayPlayer()
        {
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
} // end namespace
