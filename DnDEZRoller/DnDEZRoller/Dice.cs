﻿using System;

namespace DnDEZRoller
{
    class Dice
    {
        int DiceSize = 0;

        public Dice(int DiceSize)
        {
            this.DiceSize = DiceSize;
        }
        public int RollDice()
        {
            var random = new Random(); return random.Next(1, DiceSize + 1);
        }
    }
}
