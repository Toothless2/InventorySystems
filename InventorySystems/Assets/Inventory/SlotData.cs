using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace InventorySystems
{
	public class SlotData : MonoBehaviour
    {
        //each slot has an index sot it can be easily accesed
        public int slotIndex;
        //item in the slot
        public List<Item> myItem = new List<Item>();
        //reference to the floatingItem holder to reduce lag
        private FloatingItem floatingItemHolder;

        private bool justMovedItem;

		void Start ()
		{
            SetInitialRefernces();
		}

		void SetInitialRefernces()
		{
            floatingItemHolder = gameObject.transform.root.GetComponent<FloatingItem>();
		}

        public void MoveItem()
        {
            //if the slot has it item it can move something
            if(myItem.Count > 0)
            {
                //if the floatingItem does not have an item it can move something
                if(floatingItemHolder.floatingItem.Count < 1)
                {
                    //adds the item in the slot to the floating item list and gives the floating item this slots index
                    floatingItemHolder.floatingItem.Add(myItem[0]);
                    floatingItemHolder.prevSlotIndex = slotIndex;
                    //removes the item from the slot
                    ClearSlot();
                    //fixes the problem that meant when you tryed to remove an item it would just out it back into the same slot
                    justMovedItem = true;
                }
            }
        }

        public void AcceptItem()
        {
            if (!justMovedItem)
            {
                //if the slot dosen't have anythign in and the player is moving an item add it to the slot
                if (myItem.Count < 1 && floatingItemHolder.floatingItem.Count > 0)
                {
                    AddItemToSlot();
                }
                //if the slot is full and the player is trying to move an item into it
                else if(myItem.Count > 0 && floatingItemHolder.floatingItem.Count > 0)
                {
                    //find all of the slots in the inventory
                    SlotData[] slots = transform.parent.GetComponentsInChildren<SlotData>();
                    //loop through each slot
                    foreach (SlotData slot in slots)
                    {
                        //if the slto that is currently being looped has in index the same as the prevoius slot
                        if(slot.slotIndex == floatingItemHolder.prevSlotIndex)
                        {
                            //add this slots item to it
                            slot.myItem.Add(myItem[0]);
                            //change the text of the slot to the items name
                            slot.GetComponentInChildren<Text>().text = myItem[0].ItemName;
                            //clear this slot
                            ClearSlot();
                            //break out of the loop as it is no longer needed
                            break;
                        }
                    }
                    //add the item that is being moved to this slot
                    AddItemToSlot();
                }
            }
            else
            {
                justMovedItem = false;
            }
        }

        void AddItemToSlot()
        {
            //adds the item that is being moved to the slot
            myItem.Add(floatingItemHolder.floatingItem[0]);
            //sets the button test to the items name
            gameObject.GetComponentInChildren<Text>().text = myItem[0].ItemName;
            //clears the floatingItem item list and the previous slots index
            floatingItemHolder.floatingItem.Clear();
            floatingItemHolder.prevSlotIndex = -1;
        }

        void ClearSlot()
        {
            //clears the slot
            myItem.Clear();
            //resets the button text
            gameObject.GetComponentInChildren<Text>().text = "Button";
        }
	}
}