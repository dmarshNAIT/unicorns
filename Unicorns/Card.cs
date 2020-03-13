using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorns
{
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
        } // end MagicCard
    } // end Card Class
} // end namespace
