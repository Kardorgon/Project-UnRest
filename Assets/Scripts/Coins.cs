using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    public int coinValue = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            //PlayerPersistingInstance.AddCoin();
        }
    }
}
