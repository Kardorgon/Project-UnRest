using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
        //everytime this method gets called we add or remove modifiers based on the equipmentchange
        EquipmentManager.instance.onEquipmentChange += OnEquipmentChanged;

    }
    public void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
            health.AddModifier(newItem.healthModifier);
        }
        if(oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            maxHealth -= oldItem.healthModifier;
            health.RemoveModifier(oldItem.healthModifier);
        }
        maxHealth = maxHealthBaseValue;
        HealthChange(health.GetValue());
        

    }

    public void HealthChange(int equipmentHealthModifiers)
    {
        maxHealth += equipmentHealthModifiers;
    }

    public void DrinkPotion(int potionHealthModifier, int potionDamageModifier)
    {
        
    }

    public override void Die()
    {
        base.Die();
        // kill the player in some way
        PlayerManager.instance.KillPlayer();
        
    }
}
