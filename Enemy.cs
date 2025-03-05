using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Enemy
    {
        private int Health { get; set; }
        private string Name { get; set; }
        public Enemy(int health, string name)
        {
            this.Health = health;
            this.Name = name;
        }
        public int return_health()
        {
            return this.Health;
        }
        public string damage()
        {
            this.Health = this.Health - 10;
            return $"\nYou hit the dragon with your mace. You dealt 10 damage.\n";
        }

        public string attack(Player player)
        {
            int damage = 10;
            player.take_damage(damage);
            return $"The dragon sprayed you with fire. You recieved {damage} damage.\n";
        }
    }
}
