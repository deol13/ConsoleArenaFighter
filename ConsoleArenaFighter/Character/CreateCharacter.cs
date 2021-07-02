using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace ConsoleArenaFighter
{
    public class CreateCharacter
    {
        static InfoGenerator generator = new InfoGenerator();
        static readonly int minHealthValue = 4;
        static readonly int maxHealthValue = 7;
        
        static readonly int minStrengthValue = 4;
        static readonly int maxStrengthValue = 8;
        
        static readonly int minDamageValue = 2;
        static readonly int maxDamageValue = 5;

        public static Character CreateACharacter(string name)
        {
            Character player = null;

            if (!(string.IsNullOrWhiteSpace(name)))
            {
                player = GenerateStats(name);
            }
            else
                return player;

            return player;
        }

        private static Character GenerateStats(string name)
        {
            int health = generator.Next(minHealthValue, maxHealthValue);
            int strength = generator.Next(minStrengthValue, maxStrengthValue);
            int damage = generator.Next(minDamageValue, maxDamageValue);

            Character character = new Character(name, strength, damage, health);

            return character;
        }
    }
}
