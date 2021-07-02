using System;
using ConsoleArenaFighter.Printer;


namespace ConsoleArenaFighter
{
    public class ArenaFighter
    {
        static void Main(string[] args)
        {
            string mainMenu = "What do you want to do?\n"
                            + "H - Hunt for an opponent\n"
                            + "R - Retire from fightning\n";
            Character player = null;
            Battle battle = new Battle();
            bool continueGame = true;
            bool playerAlive = true;

            //Loops until the player has enter a name, accept anything other than empty or a single whitepace
            while (player == null)
            {
                string name = PrintToUser.AskPlayerForName("Enter the name of your character.");
                player = CreateCharacter.CreateACharacter(name);

                Console.Clear();
            }
            PrintInfoContainer.playerName = player.Name;
            PrintInfoContainer.playerStrength = player.Strength;

            //Game Loop
            while (continueGame)
            {
                Console.Clear();

                //Main menu, show character info and options
                PrintToUser.ShowCharacterInfo(player);
                ConsoleKeyInfo answer = PrintToUser.AskPlayerForAction(mainMenu);

                //H is for Fightnig and R is for retiring

                //Start a battle
                if (answer.Key.ToString() == "H")
                {
                    //Show both characters info
                    Console.Clear();
                    PrintToUser.ShowCharacterInfo(player);
                    //Create an opponent and send back its info so it can be printed
                    PrintToUser.ShowCharacterInfo(battle.InitiateBattle(player));

                    Console.ReadKey();

                    //Call the battle loop
                    playerAlive = battle.ABattle();
                    continueGame = playerAlive;
                }
                //Print battle history and end game
                else if(answer.Key.ToString() == "R")
                {
                    continueGame = false;

                    PrintToUser.AskPlayerForAction("You have ended the violence by not fightning.");
                }
            }

            Console.Clear();
            Console.WriteLine("Final Statistics:\n");
            PrintToUser.ShowCharacterInfo(player);
            string history = CalcPlayerPoints(battle, player.Name, playerAlive);
            PrintToUser.AskPlayerForAction(history);
        }

        /// <summary>
        /// You get 5p for each kill and 2p if you died in battle.
        /// </summary>
        /// <param name="battle">Object holding the battles</param>
        /// <param name="died">If the player died this methods needs to know</param>
        /// <returns></returns>
        public static string CalcPlayerPoints(Battle battle, string playerName, bool playerAlive)
        {
            Character[] list = battle.ListOfOpponents;
            string history = "";
            int score = 0;

            for (int i = 0; i < list.Length-1; i++)
            {
                score += 5;
                history += $"{playerName} fought and killed {list[i].Name}.\n";
            }

            if (!playerAlive)
            {
                score += 2;
                history += $"{playerName} was killed by {list[list.Length-1].Name}.\n";
            }
            else if(list.Length > 0)
            {
                score += 5;
                history += $"{playerName} fought and killed {list[list.Length - 1].Name}.\n";
            }
            history += $"{playerName} total score is {score}.";

            return history;
        }

    }
}
