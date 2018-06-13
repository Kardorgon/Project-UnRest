using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script created as a singleton to give enemy a reference to a player
//will work only because we do not spawn player
public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerStats;
    #region Singleton
    public static PlayerManager instance;

    public int currentPotion;
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

    public void Drink(Potions potion)
    {
        int potionIndex = (int)potion.potionType;
        print(potionIndex);
        switch (potionIndex)
        {
            case 0:
                print("Case 0");
                DrinkHealthPotion(potion.healthModifier);
                break;
            case 1:
                print("Case 1");
                //DrinkDamagePotion(int potionDamageModifier);
                break;
            case 2:
                print("Case 2");
                break;
            default:
                print("potion outside range");
                break;
        }
    }
    public void DrinkHealthPotion(int potionHealthModifier)
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
    //public void DrinkDamagePotion(int potionDamageModifier)
    //{
    //    playerStats = player.GetComponent<PlayerStats>();
    //    if (playerStats.currentHealth + potionHealthModifier > playerStats.maxHealth)
    //    {
    //        playerStats.currentHealth = playerStats.maxHealth;
    //    }
    //    else
    //    {
    //        playerStats.currentHealth += potionHealthModifier;
    //    }
    //}

    public void KillPlayer()
    {
        SceneManager.LoadScene(0);
    }
}
