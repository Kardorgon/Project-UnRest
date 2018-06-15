using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {
    private int healthValue = 0;

    public int HealthValue
    {
        get { return healthValue; }
        set
        {
            if (healthValue == value)
            {
                return;
            }
            healthValue = value;
            //if (onStatHasChanged != null)
            //    onStatHasChanged(value, armorValue, damageValue);
        }
    }

    private int armorValue = 0;

    private int damageValue = 0;

    public delegate void OnStatChange(int hpValue, int armorValue, int dmgValue);
    public OnStatChange onStatHasChanged;

    // Use this for initialization
    void Start () {
        //everytime this method gets called we add or remove modifiers based on the equipmentchange
        EquipmentManager.instance.onEquipmentChange += OnEquipmentChanged; 
        }
    public void Update()
    {
        HealthValue = currentHealth;
        armorValue = armor.GetValue();
        damageValue = damage.GetValue();
        //print("Health value = " + HealthValue + "armorValue = " + armorValue + "damageValue = " + damageValue);
        if (onStatHasChanged != null)
            onStatHasChanged(HealthValue, armorValue, damageValue);
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

    public override void Die()
    {
        base.Die();
        // kill the player in some way
        PlayerManager.instance.KillPlayer();
        
    }
}
