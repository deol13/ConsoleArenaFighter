using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;
using ConsoleArenaFighter.Printer;

namespace ConsoleArenaFighter
{
    public class Battle
    {
        //The default is private
        static InfoGenerator generator = new InfoGenerator();
        static Character[] listOfOpponents = new Character[0];

        Character player;
        Character opponent;

        public Character Player { get { return player; } }
        public Character Opponent { get { return opponent; } }

        public Character InitiateBattle(Character player)
        {
            this.player = player;
            opponent = CreateOpponent();
            return opponent;
        }

        private Character CreateOpponent()
        {
            Character character = CreateCharacter.CreateACharacter(generator.NextUserName());
            PrintInfoContainer.opponentName = character.Name;
            PrintInfoContainer.opponentStrength = character.Strength;

            return character;
        }

        private bool ARoundOfFightning(ref bool playerWon)
        {
            bool continueFighting = true;
            PrintInfoContainer.playerWon = false;
            PrintInfoContainer.even = false;

            //Call round class
            Round round = new Round();
            playerWon = round.ARound(generator, player, opponent);

            if (player.health <= 0 || opponent.health <= 0)
                continueFighting = false;

            return continueFighting;
        }

        public bool ABattle()
        {
            bool playerWon = false;
            bool continueFightning = true;

            while (continueFightning)
            {
                continueFightning = ARoundOfFightning(ref playerWon);
                PrintToUser.PrintRound();
            }

            if (playerWon)
            {
                PrintToUser.AskPlayerForAction($"---------------\n{player.Name} is victorious!");
            }
            else
            {
                PrintToUser.AskPlayerForAction($"---------------\n{opponent.Name} is victorious!");
            }

            return playerWon;
        }





        private void CollectBattleLog()
        {
            Array.Resize(ref listOfOpponents, listOfOpponents.Length + 1);
            listOfOpponents[listOfOpponents.Length - 1] = opponent;
            opponent = null;
        }
        //public string BattleLog(int index)
        //{
        //    string name = "";
        //
        //    if(index > -1 && index < listOfOpponents.Length)
        //    {
        //        name = listOfOpponents[index].Name;
        //    }
        //
        //    return name;
        //}
    }
}
