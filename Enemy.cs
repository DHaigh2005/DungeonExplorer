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
        public int ReturnHealth()
        {
            return this.Health;
        }
        public string Damage()
        {
            this.Health = this.Health - 10;
            return $"\nYou hit the dragon with your mace. You dealt 10 damage.\n";
        }

        public string Attack(Player player)
        {
            int damage = 10;
            player.TakeDamage(damage);
            return $"The dragon sprayed you with fire. You received {damage} damage.\n";
        }
    }
}
