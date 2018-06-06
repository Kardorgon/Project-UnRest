using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public DestructableObject destructableObject;
    public int destructableObjectDamage = 1;
	// Use this for initialization
	void Start () {
        //destructableObject = gameObject.GetComponent<DestructableObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AttackDestructableObstacle(RaycastHit2D hit)
    {
        if (hit.collider.GetComponent<DestructableObject>())
        {
            destructableObject = hit.transform.GetComponent<DestructableObject>();
            destructableObject.LoseHP(destructableObjectDamage);
        }
    }
    public void AttackEnemy(RaycastHit2D hit)
    {
        if (hit.collider.tag == "Enemy")
        {
            destructableObject = hit.transform.GetComponent<DestructableObject>();
            destructableObject.LoseHP(destructableObjectDamage);
        }
    }
}
