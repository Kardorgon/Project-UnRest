using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Potion")]
public class Potions : Item
{
    public int healthModifier;
    public int damageModifier;


    public override void Use()
    {
        base.Use();
        //Use the potion
        PlayerManager.instance.DrinkPotion(healthModifier, damageModifier);
        RemoveFromInventory();

    }
}
