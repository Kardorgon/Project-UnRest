using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Potion")]
public class Potions : Item
{
    public int healthModifier;
    public int damageModifier;
    public int healthOverTime;
    public int healthOverTimeDelay;

    public PotionType potionType;

    public override void Use()
    {
        base.Use();
        //Use the potion
        
        PlayerManager.instance.Drink(this);
        RemoveFromInventory();

    }

    public enum PotionType { heal, damage, healthOverTime }
}


