using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Game
{
    class GameManager
    {

        //Create a player instance for the whole game.
        private Player player = new Player(10);

        //When a room instance is created, enemies within the room will be taken from this list.
        private List<Enemy> _potentialEnemies = new List<Enemy> { new Enemy("Skeleton", 5, 4), 
                                                                  new Enemy("Giant Rat", 2, 2),
                                                                  new Enemy("Giant Spider", 3, 3) };

        private string userInput;


        public void Startup()
        {

            Random random = new Random();

            player.Equip(new Weapon("shortsword", 6));

            Room exampleRoom = new Room(_potentialEnemies, random.Next(1, 3));

            Console.WriteLine("There is a door in front of you, press enter if you wish to open it.");
            userInput = Console.ReadLine();

            if(userInput.Equals("enter"))
            {

                Console.WriteLine("You entered the room.");
                exampleRoom.Introduction();
                CombatLoop(exampleRoom.CurrentEnemies);

            }

            Console.WriteLine("There is an exit in front of you, if you wish to leave type leave.");
            userInput = Console.ReadLine();

            if (userInput.Equals("leave"))
            {

                Console.WriteLine("You have left.");

            }

        }

        private void CombatLoop(List<Enemy> currentEnemies)
        {

            while (currentEnemies.Count > 0)
            {
                Console.WriteLine("If you wish to strike press attack.");
                userInput = Console.ReadLine();

                if (userInput.Equals("attack"))
                {

                    Console.WriteLine("You attacked the {0}.", currentEnemies[0].Name);
                    currentEnemies[0].Health -= player.Attack();

                    for (int i = 0; i < currentEnemies.Count; i++)
                    {

                        if (currentEnemies[i].Health <= 0)
                        {
                            Console.WriteLine("The {0} has died.", currentEnemies[i].Name);
                            currentEnemies.Remove(currentEnemies[i]);
                        }
                        else
                        {
                            player.Health -= currentEnemies[i].Attack();
                            Console.WriteLine("The {0} has attacked you.", currentEnemies[i].Name);
                        }

                    }

                    Console.WriteLine("Your health is now {0}.", player.Health);

                }
                else
                {
                    Console.WriteLine("That is not an attack.");
                }
                
            }

            Console.WriteLine("You have defeated all the current enemies.");

        }

    }
}
