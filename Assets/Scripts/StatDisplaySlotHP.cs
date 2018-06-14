using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplaySlotHP : MonoBehaviour {

    public Text text;
    public PlayerManager playerManager;
    public PlayerStats playerStats;

    

	// Use this for initialization
	void Start () {
        playerManager = PlayerManager.instance;
        playerStats = playerManager.player.GetComponent<PlayerStats>();
        text.text = playerStats.currentHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = playerStats.currentHealth.ToString();
    }
    public void HealthHasChanged()
    {
        print("health has changed");
        
    }
}
