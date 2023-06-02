using Loop_Hero_GUI.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Hero_GUI.Entity
{
    public abstract class Loot
    {
        private Random? _random;
        public Item? GenerateItem()
        {
            _random = new Random();
            int randomNumber = _random.Next(0, 3);
            Item? item = null;
            switch (randomNumber)
            {
                case 0:
                    item = new Item("Sword");
                    break;
                case 1:
                    item = new Item("Bow");
                    break;
                case 2:
                    item = new Item("Axe");
                    break;
            }
            return item;
        }
        public virtual Item? EntityLoot { get; set; }
    }
}
