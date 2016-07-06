using System;

namespace InventorySystems
{
    [Serializable]
	public class Item
    {
        //makes an ingame index for the item unrelated to the list
        public int itemInGameIndex = 1;
        //allows the name if the item to be set
        public string ItemName;
        //allows the user to select from some predetermined item types
        public ItemType itemType;

        public enum ItemType
        {
            Weapon,
            Consumable
        }
    }
}