using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    PlayerManager playerManager;
    public int xpValue;
    public void Start()
    {
        playerManager = PlayerManager.instance;
    }

    public override void Die()
    {
        base.Die();

        //Add death animation
        //Adds xp value through XP properties set in PlayerManager
        playerManager.XP = xpValue;
        Destroy(gameObject);
    }
}
