﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;
    public int healthModifier;

    public override void Use()
    {
        base.Use();
        //Equip the item
        EquipmentManager.instance.Eqip(this);
        RemoveFromInventory();

    }
}


public enum EquipmentSlot {  Head, Chest, Legs, Weapon, Shield, Feet}
