using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {
    public int hp = 5;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int timesHit;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
    public void LoseHP(int dmg)
    {
        timesHit += 1;
        if(timesHit >= hp)
        {
            Object.Destroy(gameObject);
        }else
            LoadSprites();
    }
    public void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
