using System;
using System.Collections.Generic;

namespace DnDEZRoller
{
    public class Character
    {
        private int Strength;
        private int Constitution;
        private int Dexterity;
        private int Wisdom;
        private int Charisma;
        private int Intelligence;

        public Dictionary<string, int> modifiers = new Dictionary<string, int>()
        {
            { "Strength" , 0 },
            {"Constitution",0 },
            { "Dexterity",0 },
            { "Wisdom",0 },
            { "Charisma",0 },
            {"Intelligence",0 }
        };
        public int level, proficiencyBonus;
        public string characterName;
        public Character(string CharacterName, int Strength, int Constitution, int Dexterity, int Wisdom, int Charisma, int Intelligence, int Level)
        {
            characterName = CharacterName;
            level = Level;

            this.Strength = Strength;
            this.Constitution = Constitution;
            this.Dexterity = Dexterity;
            this.Wisdom = Wisdom;
            this.Charisma = Charisma;
            this.Intelligence = Intelligence;

            double proficiencyRawModifier = ((double)level / 4) + 1;
            proficiencyBonus = (int)Math.Ceiling(proficiencyRawModifier);


            modifiers["Strength"] = (Strength - 10) / 2;
            modifiers["Constitution"] = (Constitution - 10) / 2;
            modifiers["Dexterity"] = (Dexterity - 10) / 2;
            modifiers["Wisdom"] = (Wisdom - 10) / 2;
            modifiers["Charisma"] = (Charisma - 10) / 2;
            modifiers["Intelligence"] = (Intelligence - 10) / 2;
        }
    }
}