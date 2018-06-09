using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    public static EquipmentManager instance;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChange;
    Equipment[] currentEquipment;

    Inventory inventory;

    #region Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    void Start()
    {
        inventory = Inventory.instance;
        //handy command to get string of elements in an enum but we use length to get length :P
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        //dzięki number of slots mozemy zainicjowac currentEquipment array o odpowiedniej dlugosci
        currentEquipment = new Equipment[numberOfSlots];
    }

    public void Eqip (Equipment newItem)
    {
        //taking int value of Enum from Equipment script
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;
        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        //so if we have any methods to notify about the change of equipment
        if(onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            //so if we have any methods to notify about the change of equipment (null because we dont have newItem
            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }
            currentEquipment[slotIndex] = null;
        }
    }
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
