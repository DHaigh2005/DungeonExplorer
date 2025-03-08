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
        public int ReturnHealth()
        {
            return this.Health;
        }

        public void TakeDamage(int damage)
        {
            Health = Health - damage;
        }
        public string Regen()
        {
            Console.WriteLine("");
            Console.WriteLine("You find cover from the dragon's attacks and you wait to heal.\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+20 ");
            Console.ResetColor();
            Console.Write("health.\n");
            this.Health = this.Health + 20;
            return "\n";
        }
        public bool ItemInInventory()
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