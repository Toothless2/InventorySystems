using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InventorySystems
{
	public class FloatingItem : MonoBehaviour
    {
        //item that is being moved between slots
        public List<Item> floatingItem = new List<Item>();
        //where the item came from
        public int prevSlotIndex = -1;
	}
}