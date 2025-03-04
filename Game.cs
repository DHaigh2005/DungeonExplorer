using System;
using System.ComponentModel;
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
            current_room = new Room("You are in a dimly lit dungeon. You hear strange noises. There is a weapon mounted on the wall.");
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
                    Console.WriteLine($"Your health is {player.return_health}.");
                    Console.WriteLine($"Dragons health is {current_enemy.return_health}.");
                    string input = this.player_input();
                    if (input == ("attack"))
                    {
                        Console.WriteLine(current_enemy.damage());
                    }
                    else if (input == ("regen"))
                    {
                        Console.WriteLine(player.regen);
                    }
                    else if (input == ("inventory") && player.item_in_inventory() == true)
                    {
                        Console.WriteLine($"You have: {player.InventoryContents()}");
                    }
                    else if (input == ("pick up"))
                    {
                        string warrior_inventory = 
                    }
                }
            }
        }
    }
}