using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplaySlot : MonoBehaviour {
    PlayerStats playerStats;
    public Text hpText;
    public Text dmgText;
    public Text armorText;
	// Use this for initialization
	void Start () {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        playerStats.onStatHasChanged += DisplayText;
        hpText.text = playerStats.HealthValue.ToString();
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void DisplayText(int hp, int dmg, int arm)
    {
        hpText.text = hp.ToString();
        dmgText.text = dmg.ToString();
        armorText.text = arm.ToString();
    }
}
