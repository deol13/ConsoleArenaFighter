using System;

namespace ConsoleArenaFighter
{
    public class ArenaFighter
    {
        static void Main(string[] args)
        {
            string betweenRoundsMenu = "What do you want to do?\n"
                                     + "H - Hunt for an opponent\n"
                                     + "R - Retire from fightning\n";
            Character player = null;
            bool continueGame = true;

            while (player == null)
            {
                string name = AskPlayerForName("Enter the name of your character.");
                player = CreatePlayerCharacter(name);
                Console.Clear();
            }

            //Game Loop
            while (continueGame)
            {
                PrintMenuBetweenRounds();

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

        public static Character CreatePlayerCharacter(string name)
        {
            Character player = null;

            if (!(string.IsNullOrWhiteSpace(name)))
            {
                player = new Character();
            }
            else
                return player;

            return player;
        }
        
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

        public static void PrintMenuBetweenRounds()
        {

        }

        public static void GenerateOpponentCharacterName()
        {
            
        }
    }
}
