using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {
    int hp = 5;
	// Use this for initialization
	void Start () {
		
	}
	
    public void LoseHP(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Object.Destroy(gameObject);
        }
    }
}
