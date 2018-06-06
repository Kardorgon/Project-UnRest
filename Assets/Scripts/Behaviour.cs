using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {

    public LayerMask layer;
    //bool clickedX = true;
    BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            boxCollider.enabled = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            float distanceFromClickX = Mathf.Abs(mousePos2D.x - transform.position.x);
            float distanceFromClickY = Mathf.Abs(mousePos2D.y - transform.position.y);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos2D, 1, layer);
            boxCollider.enabled = true;

            if (hit)
            {
                print(hit.collider.gameObject.name);
            }


            /*if(distanceFromClickX > distanceFromClickY)
            {
                clickedX = true;
            }
            else
            {
                clickedX = false;
            }
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(clickedX == true && distanceFromClickX < 2)
                {
                    print("klikanie na osi x");
                    Debug.Log(hit.collider.gameObject.name);
                }else if (clickedX == false && distanceFromClickY < 2)
                {
                    print("klikanie na osi y");
                    Debug.Log(hit.collider.gameObject.name);
                }              
            }*/



        }
    }
}
