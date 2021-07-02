using System;
using System.Collections.Generic;
using System.Text;
using ConsoleArenaFighter.Printer;

namespace ConsoleArenaFighter
{
    public class PrintToUser
    {
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
        /// The game only needs a key and it looks & feels better if game just reacts to what the player pressed instead of writing in and then pressing enter.
        /// Also used to show a round and wait for key input to start next round
        /// </summary>
        /// <param name="what">What to ask the player</param>
        /// <returns></returns>
        public static ConsoleKeyInfo AskPlayerForAction(string what)
        {
            Console.WriteLine(what);

            return Console.ReadKey();
        }

        /// <summary>
        /// Prints a characters details by calling the character's stats method and outputting that string
        /// </summary>
        /// <param name="character">Which character</param>
        public static void ShowCharacterInfo(Character character)
        {
            Console.WriteLine(character.Stats());
        }

        public static void PrintHistory(string output)
        {

        }

        public static void PrintRound()
        {
            string playerName = PrintInfoContainer.playerName;
            string opponentName = PrintInfoContainer.opponentName;
            int playerRoll = PrintInfoContainer.playerRoll;
            int opponentRoll = PrintInfoContainer.opponentRoll;
            int playerStrength = PrintInfoContainer.playerStrength;
            int opponentStrength = PrintInfoContainer.opponentStrength;
            int playerHealth = PrintInfoContainer.playerHealth;
            int opponentHealth = PrintInfoContainer.opponentHealth;
            int winnersDamage = PrintInfoContainer.winnersDamage;

            Console.WriteLine("---------------");

            Console.WriteLine($"Rolls: {playerName} {playerRoll + playerStrength} ({playerRoll}+{playerStrength}) " +
                $" vs {opponentName} {opponentRoll + opponentStrength} ({opponentRoll}+{opponentStrength})");
            
            if(PrintInfoContainer.even)
            {
                Console.WriteLine("Evenly matched, the combatants circle each other.");
            }
            else if (PrintInfoContainer.playerWon)
            {
                ChangeTextColor(2); //Green for player win
                Console.WriteLine($"{playerName} attacks {opponentName}! {opponentName} takes {winnersDamage} damage.");
            }
            else
            {
                ChangeTextColor(1); //Red for opponent win
                Console.WriteLine($"{opponentName} attacks {playerName}! {playerName} takes {winnersDamage} damage.");
            }
            ChangeTextColor(3); //Change it back to default

            Console.WriteLine($"Remaining Health: {playerName} ({playerHealth}) {opponentName} ({opponentHealth})\n");

            Console.ReadKey();
        }

        /// <summary>
        /// 1 = Red, 2 = Green, 3 = Default color(Gray)
        /// </summary>
        /// <param name="color">Switch choice</param>
        public static void ChangeTextColor(int color)
        {
            switch(color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;    
            }
        }
    }
}
