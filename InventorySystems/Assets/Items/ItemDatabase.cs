using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InventorySystems
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<Item> items = new List<Item>();
        
        void Start()
        {
            items.TrimExcess();
        }
    }
}