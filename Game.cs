using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Enemy currentEnemy;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("You are in a dimly lit dungeon. You hear strange noises. There is a weapon mounted on the wall. As you move closer, your torch reveals a dragon guarding a door.\n");
            player = new Player("Warrior", 50);
            currentEnemy = new Enemy(50, "Dragon");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine(currentRoom.GetDescription());
            while (playing == true)
            {
                // Code your playing logic here
                while (currentEnemy.ReturnHealth() > 0 && player.ReturnHealth() > 0)
                {   
                    if (player.ReturnHealth() > 30 )
                    {
                        Console.Write("Your health is ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{player.ReturnHealth()}\n");
                        Console.ResetColor();
                    }
                    else if (player.ReturnHealth() > 10)
                    {
                        Console.Write("Your health is ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"{player.ReturnHealth()}\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Your health is ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player.ReturnHealth()}\n");
                        Console.ResetColor();
                    }

                    if (currentEnemy.ReturnHealth() > 30)
                    {
                        Console.Write("Dragons health is ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{currentEnemy.ReturnHealth()}\n");
                        Console.ResetColor();
                    }
                    else if (currentEnemy.ReturnHealth() > 10)
                    {
                        Console.Write("Dragons health is ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"{currentEnemy.ReturnHealth()}\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Dragons health is ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{currentEnemy.ReturnHealth()}\n");
                        Console.ResetColor();
                    }

                    
                    string input = this.PlayerInput();
                    if (input == ("attack") && player.ItemInInventory() == true)
                    {
                        Console.WriteLine(currentEnemy.Damage());
                    }
                    else if (input == ("regen"))
                    {
                        Console.WriteLine(player.Regen());
                    }
                    else if (input == ("inventory") && player.ItemInInventory() == true)
                    {
                        Console.WriteLine($"\nYou have: {player.InventoryContents()}\n");
                    }
                    else if (input == ("pick up") && player.ItemInInventory() == false)
                    {
                        string warrior_inventory = currentRoom.RoomInventory();
                        player.PickUpItem(warrior_inventory);
                        Console.WriteLine("");
                        Console.WriteLine($"You picked up the {warrior_inventory} mounted on the wall.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("\nNot a valid response. Please choose one of the prompted choices.\n");
                    }

                    if (currentEnemy.ReturnHealth() > 0)
                    {
                        Console.WriteLine(currentEnemy.Attack(player));
                    }

                    if (player.ReturnHealth() <= 0)
                    {
                        Console.WriteLine("You have been defeated by the dragon.");
                        playing = false;
                    }

                    playing = false;
                }
                if (currentEnemy.ReturnHealth() <= 0)
                {
                    Console.WriteLine("With one final blow, you have successfully defeated the dragon.");
                    playing = false;
                }
              
            }
        }
        private string PlayerInput()
        {
            Console.WriteLine("");
            Console.WriteLine("Pick an option:");
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'regen' ");
            Console.ResetColor();
            Console.Write("to increase your health.\n");
            if (player.ItemInInventory() == true)
            {
                Console.Write("Enter ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("'attack' ");
                Console.ResetColor();
                Console.Write("to hit the dragon.\n");
            }
            if (player.ItemInInventory() == false)
            {
                Console.Write("Enter ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("'pick up' ");
                Console.ResetColor();
                Console.Write("to grab the weapon.\n");
            }
            if (player.ItemInInventory() == true)
            {
                Console.Write("Enter ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("'inventory' ");
                Console.ResetColor();
                Console.Write("to view your items.\n");
            }
            Console.WriteLine();
            string input = Console.ReadLine();
            return input;
        }
    }
}