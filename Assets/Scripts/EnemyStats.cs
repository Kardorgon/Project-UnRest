using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {
    public static int enemyMaxHealth;
    public static int currentEnemyHealth;

    public void Start()
    {
        enemyMaxHealth = maxHealth;
        currentEnemyHealth = currentHealth;
    }

    public override void Die()
    {
        base.Die();

        //Add death animation

        Destroy(gameObject);
    }
}
