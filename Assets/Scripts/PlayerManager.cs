using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//script created as a singleton to give enemy a reference to a player
//will work only because we do not spawn player
public class PlayerManager : MonoBehaviour {
    public GameObject player;
    public PlayerStats playerStats;
    #region Singleton
    public static PlayerManager instance;
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
        DontDestroyOnLoad(player);

    }
    #endregion

    public void DrinkPotion(int potionHealthModifier, int potionDamageModifier)
    {
        playerStats = player.GetComponent<PlayerStats>();
        if (playerStats.currentHealth + potionHealthModifier > playerStats.maxHealth)
        {
            playerStats.currentHealth = playerStats.maxHealth;
        }
        else
        {
            playerStats.currentHealth += potionHealthModifier;
        }    
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(0);
    }
}
