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
                Console.Clear();

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
                    bool playerWon = battle.ABattle();
                    if (!playerWon)
                    {
                       //If the player lost
                       //PrintToUser.PrintHistory(); //Send in battle log as a string array maybe
                       continueGame = false;
                    }

                }
                //Print battle history and end game
                else if(answer.Key.ToString() == "R")
                {
                    //PrintToUser.PrintHistory();
                    continueGame = false;
                }
            }
        }
    }
}
