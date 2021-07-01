﻿using System;

namespace ConsoleArenaFighter
{
    public class ArenaFighter
    {
        private static int minStatValue = 2;
        private static int maxStatValue = 10;

        static void Main(string[] args)
        {
            string betweenRoundsMenu = "What do you want to do?\n"
                                     + "H - Hunt for an opponent\n"
                                     + "R - Retire from fightning\n";
            Character player = null;
            bool continueGame = true;

            //Loops until the player has enter a name, accept anything other than empty or a single whitepace
            while (player == null)
            {
                string name = AskPlayerForName("Enter the name of your character.");
                player = CreateACharacter(name);
                Console.Clear();
            }



            //Game Loop
            while (continueGame)
            {
                ShowCharacterInfo(player);
                ConsoleKeyInfo answer = AskPlayerForAction(betweenRoundsMenu);
                Console.Clear();

                if (answer.Key.ToString() == "H")
                {
                    
                }
                else if(answer.Key.ToString() == "R")
                {
                    
                }

                //Console.Clear();
            }

            //EndGame(); //Print
        }

        /////////////////////////////////////////////////////////////////////////Ouputs to players and/or inputs from player
        
        ///
        /// <summary>
        /// The game needs a name and thus can take an entire row
        /// </summary>
        /// <param name="what">What to ask the player</param>
        /// <returns></returns>
        public static string AskPlayerForName(string what)
        {
            Console.WriteLine(what);

            return Console.ReadLine();
        }

        /// <summary>
        /// The game only needs a key and it looks & feels better if game just reacts to what the player pressed instead of writing in and then pressing enter
        /// </summary>
        /// <param name="what">What to ask the player</param>
        /// <returns></returns>
        public static ConsoleKeyInfo AskPlayerForAction(string what)
        {
            Console.WriteLine(what);

            return Console.ReadKey();
        }

        public static void ShowCharacterInfo(Character character)
        {
            Console.WriteLine(character.stats());
        }


        /////////////////////////////////////////////////////////////////////////Character creation methods
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

        public static void GenerateOpponentCharacterName()
        {
            
        } 
        
        public static Character GenerateStats(string name)
        {
            int strength = RandomizeValue();
            int damage = RandomizeValue();
            int health = RandomizeValue();

            Character character = new Character(name, strength, damage, health);

            return character;
        }

        public static int RandomizeValue()
        {
            Random rnd = new Random();

            return rnd.Next(minStatValue, maxStatValue);
        }
    }
}
