using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkillUI : MonoBehaviour {
    PlayerManager playerManager;
    public Image image;
    float imageAlpha;
    Color imageColor;
    float attackCooldown;
    float attackSpeed;
	// Use this for initialization
	void Start () {
        playerManager = PlayerManager.instance;
        image = GetComponent<Image>();
        imageColor = image.color;
        
    }
	
	// Update is called once per frame
	void Update () {
        attackCooldown = playerManager.player.GetComponent<CharacterCombat>().AttackCoolDown;
        attackSpeed = playerManager.player.GetComponent<CharacterCombat>().AttackSpeed;
        if (attackCooldown <= 0)
        {
            imageColor = Color.red;
            imageColor.a = 1f;
            image.color = imageColor;
            image.fillAmount = 1;
        }
        else
        {
            imageColor = Color.blue;
            imageColor.a = 0.25f;
            image.color = imageColor;
            image.fillAmount -= attackSpeed*Time.deltaTime;
        }
        print("image alpha = " + imageAlpha);
    }
}
