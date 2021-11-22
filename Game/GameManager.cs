using System;
using System.Collections.Generic;
using System.Linq;
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

            //Start the player off with a shortsword to calculate damage.
            player.Equip(new Weapon("shortsword", 6));


            //The current room is generated for the player to go throgh, create a new one when the player leaves.
            Room currentRoom;

            while (true)
            {   

                currentRoom = new Room(_potentialEnemies, random.Next(1, 4));

                Console.WriteLine("There is a door in front of you, press enter if you wish to open it.");
                userInput = Console.ReadLine();


                if (userInput.Equals("enter"))
                {

                    Console.WriteLine("You entered the room.");
                    //Present the user with a description of the enemies.
                    currentRoom.Introduction();
                    //Play out combat within the room until all enemies are dead or the player is dead.
                    CombatLoop(currentRoom.CurrentEnemies);

                }

                Console.WriteLine("There is an exit in front of you, if you wish to leave type leave.");
                userInput = Console.ReadLine();

                if (userInput.Equals("leave"))
                {

                    Console.WriteLine("You have left.");

                }

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
                    //The first enemy is the one that is attacked by the player.
                    currentEnemies[0].Health -= player.Attack();

                    for (int i = 0; i < currentEnemies.Count; i++)
                    {

                        //Remove enemies that have no health from the list, calculate attacks if they are still alive.
                        if (currentEnemies[i].Health <= 0)
                        {
                            Console.WriteLine("The {0} has died.", currentEnemies[i].Name);
                            currentEnemies.Remove(currentEnemies[i]);
                            //re-adjust the for loop as to account for the smaller currentEnemies.Count
                            i--;
                        }
                        else
                        {
                            //Attack the player.
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
