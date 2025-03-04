using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
        public int return_health()
        {
            return this.Health;
        }
        public string regen()
        {
            Console.WriteLine("You find cover from the dragon's attacks and you wait to heal");
            Console.WriteLine("+20 health.");
            this.Health = this.Health + 20;
            return $"You are now on {this.Health} health.";
        }
        public bool item_in_inventory()
        {
            if (inventory.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}