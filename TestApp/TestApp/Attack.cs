namespace DnDEZRoller
{
    public class Attack
    {
        static Dice D20Dice = new Dice(20);
        Dice damageDice;
        int modifier,proficiency;
        bool isAtAdvantage = false;
        public Attack(int DiceSize, int Modifier, int Proficiency)
        {
            damageDice = new Dice(DiceSize);
            modifier = Modifier;
            proficiency = Proficiency;
        }
        public int rollforAttack()
        {
            var bestRoll = D20Dice.RollDice() + modifier +proficiency;
            if (isAtAdvantage)
            {
                var secondRoll = D20Dice.RollDice() + modifier+proficiency;
                if (secondRoll > bestRoll)
                { bestRoll = secondRoll; }
            }
            return bestRoll;
        }

        public int RollforDamage()
        {
            return damageDice.RollDice() + modifier;
        }
    }
}
