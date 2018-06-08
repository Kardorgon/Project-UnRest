using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    //since we have singleton we create component for performance only
    Inventory inventory;

    public Transform itemsParent;
    public GameObject inventoryUI;
    InventorySlot[] slots;
	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }
}
