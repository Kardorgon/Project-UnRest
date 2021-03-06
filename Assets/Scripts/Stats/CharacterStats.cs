﻿using UnityEngine;

public class CharacterStats : MonoBehaviour {
    //public int maxHealth = 100;
    //this means any other class will be able to get this value but not set it
    //public int currentHealth { get; set; }
    public Stat damage;
    public Stat armor;
    public Stat health;

    public int currentHealth;
    public int maxHealth = 100;
    public int maxHealthBaseValue;
    public int hitRollMin = 4;

    public void Awake()
    {
        currentHealth = maxHealth;
        maxHealthBaseValue = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();

        //jesli postac bedzie miala wlasciwosc leczenie zachowanego damage to umozliwic damage wartosci ujemne
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    //virtual ponieważ jesli zginie player to game over a jesli przeciwnik to chcemy zeby zrzucil loot itp
    public virtual void Die()
    {
        //Die in some way
        //this mewthod is meanth to be overwritten
        Debug.Log(transform.name + " died");
    }
}
