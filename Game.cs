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
        private Room current_room;
        private Enemy current_enemy;

        public Game()
        {
            // Initialize the game with one room and one player
            current_room = new Room("You are in a dimly lit dungeon. You hear strange noises. There is a weapon mounted on the wall. As you move closer, your torch reveals a dragon guarding a door.\n");
            player = new Player("Warrior", 50);
            current_enemy = new Enemy(50, "Dragon");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine(current_room.GetDescription());
            while (playing == true)
            {
                // Code your playing logic here
                while (current_enemy.return_health() > 0)
                {
                    Console.WriteLine($"Your health is {player.return_health()}.");
                    Console.WriteLine($"Dragons health is {current_enemy.return_health()}.");
                    string input = this.player_input();
                    if (input == ("attack") && player.item_in_inventory() == true)
                    {
                        Console.WriteLine(current_enemy.damage());
                    }
                    else if (input == ("regen"))
                    {
                        Console.WriteLine(player.regen());
                    }
                    else if (input == ("inventory") && player.item_in_inventory() == true)
                    {
                        Console.WriteLine($"You have: {player.InventoryContents()}");
                    }
                    else if (input == ("pick up") && player.item_in_inventory() == false)
                    {
                        string warrior_inventory = current_room.room_inventory();
                        player.PickUpItem(warrior_inventory);
                        Console.WriteLine("");
                        Console.WriteLine($"You picked up the {warrior_inventory} mounted on the wall.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Not a valid response. Please choose one of the prompted choices.");
                    }
                    playing = false;
                }
                Console.WriteLine("With one final blow, you have successfully defeated the dragon.");
            }
        }
        private string player_input()
        {
            Console.WriteLine("");
            Console.WriteLine("Pick an option:");
            Console.WriteLine("Enter 'regen' to increase your health.");
            if (player.item_in_inventory() == true)
            {
                Console.WriteLine("Enter 'attack' to hit the dragon.");
            }
            if (player.item_in_inventory() == false)
            {
                Console.WriteLine("Enter 'pick up' to grab the weapon.");
            }
            if (player.item_in_inventory() == true)
            {
                Console.WriteLine("Enter 'inventory' to view your items.");
            }
            string input = Console.ReadLine();
            return input;
        }
    }
}