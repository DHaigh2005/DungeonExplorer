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
            return $"You hit the dragon with your mace. It is now on {this.Health} health.";
        }
    }
}
