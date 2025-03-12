﻿using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> inventory = new List<string>();
        public Room(string description)
        {
            this.description = description;
            this.inventory.Add("Mace");
        }
        //displays room description
        public string GetDescription()
        {
            return description;
        }
        //displays the room's inventory
        public string RoomInventory()
        {
            string item = inventory[0];
            return (item);
        }

    }
}