using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class Attack
    {
        static Dice D20Dice = new Dice(20);
        Dice damageDice;
        int modifier;
        bool isAtAdvantage = false;
        public Attack(int DiceSize, int Modifier)
        {
            damageDice = new Dice(DiceSize);
            modifier = Modifier;
        }
        public int rollforAttack()
        {
            var bestRoll = D20Dice.RollDice() + modifier;
            if (isAtAdvantage)
            {
                var secondRoll = D20Dice.RollDice() + modifier;
                if (secondRoll > bestRoll)
                { bestRoll = secondRoll; }
            }
            return bestRoll;
        }

        public int rollforDamage()
        {
            return damageDice.RollDice()+modifier;
        }
    }
}
