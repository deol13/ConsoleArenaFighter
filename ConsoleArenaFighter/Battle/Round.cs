using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;
using ConsoleArenaFighter.Printer;

namespace ConsoleArenaFighter
{
    public class Round
    {
        static int minRoll = 1;
        static int maxRoll = 7;

        private int playerRolled = 0;
        private int opponentRolled = 0; 
        
        private int playerTotalRoll = 0;
        private int opponentTotalRoll = 0;
    

        public bool ARound(InfoGenerator generator, Character player, Character opponent)
        {
            bool playerWon = false;
            string[] output = new string[3];

            IntitateRound(generator, player, opponent);

            if ((playerTotalRoll) > (opponentTotalRoll))
            {
                opponent.health -= player.Damage;
                
                PrintInfoContainer.playerWon = true;
                PrintInfoContainer.winnersDamage = player.Damage;

                playerWon = true;
            }
            else if((playerTotalRoll) < (opponentTotalRoll))
            {
                player.health -= opponent.Damage;

                PrintInfoContainer.playerWon = false;
                PrintInfoContainer.winnersDamage = opponent.Damage;

                playerWon = false;
            }
            else
            {
                PrintInfoContainer.even = true;
            }

            PrintInfoContainer.opponentHealth = opponent.health;
            PrintInfoContainer.playerHealth = player.health;

            PrintInfoContainer.playerRoll = playerRolled;
            PrintInfoContainer.opponentRoll = opponentRolled;

            return playerWon;
        }

        private void IntitateRound(InfoGenerator generator, Character player, Character opponent)
        {
            playerRolled = Roll(generator);
            opponentRolled = Roll(generator);

            playerTotalRoll = playerRolled + player.Strength;
            opponentTotalRoll = opponentRolled + opponent.Strength;
        }

        private int Roll(InfoGenerator generator)
        {
            return generator.Next(minRoll, maxRoll);
        }
    }
}
