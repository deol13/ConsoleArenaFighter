using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleArenaFighter
{
    public class Character
    {
        readonly string name;
        readonly int strength;
        readonly int damage;
        public int health;

        public string Name { get { return name;  } }
        public int Strength { get { return strength; } }
        public int Damage { get { return damage;  } }

        public Character(string name, int strength, int damage, int health)
        {
            this.name = name;
            this.strength = strength;
            this.damage = damage;
            this.health = health;
        }

        public string Stats()
        {
            if(health <= 0)
                return $"Name: {name}\nStrength: {strength}\nDamage: {damage}\nHealth: Dead\n";
            return $"Name: {name}\nStrength: {strength}\nDamage: {damage}\nHealth: {health}\n";
        }
    }
}
