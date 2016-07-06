using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace InventorySystems
{
	public class SpawnSlots : MonoBehaviour
    {
        //the slot gameobject
        public GameObject slot;
        //how many slots are wanted
        [Tooltip("Recomended to go in multiples of 4 and no higher then 16")]
        public int numberOfSlots;

		void Start ()
		{
            MakeSlots();
		}
	
		void MakeSlots()
        {
            //makes 16 inventory slots
            for (int i = 0; i < numberOfSlots; i++)
            {
                GameObject _slot = Instantiate(slot);
                //sets the parent to the correct gameobejct and alows the newly mad eobject to be influenced by the parent
                _slot.transform.SetParent(transform, false);
                _slot.GetComponent<SlotData>().slotIndex = i;
            }
        }
	}
}