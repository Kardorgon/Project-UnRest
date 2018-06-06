using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {

    private Attack attack;

    public LayerMask layer;
    //bool clickedX = true;
    BoxCollider2D boxCollider;

    // Use this for initialization
    void Start() {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        attack = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            boxCollider.enabled = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Vector2 mousePos2DAbs = new Vector2(Mathf.Abs(mousePos2D.x), Mathf.Abs(mousePos2D.y));
            float distanceFromClickX = (mousePos2D.x - transform.position.x);
            float distanceFromClickY = (mousePos2D.y - transform.position.y);
            float distanceFromClickXAbs = Mathf.Abs(distanceFromClickX);
            float distanceFromClickYAbs = Mathf.Abs(distanceFromClickY);
            Vector2 direction = Vector2.zero;
            bool clickedHorizontal = false;
            if(distanceFromClickXAbs > distanceFromClickYAbs)
            {
                clickedHorizontal = true;
            }
            else
            {
                clickedHorizontal = false;
            }

            if (clickedHorizontal)
            {
                if(distanceFromClickX > 0)
                {
                    direction = Vector2.right;
                } else
                {
                    direction = Vector2.left;
                }
            }else if (!clickedHorizontal)
            {
                if(distanceFromClickY > 0)
                {
                    direction = Vector2.up;
                }
                else
                {
                    direction = Vector2.down;
                }
            }
            Debug.DrawRay(transform.position, direction, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1, layer);
            boxCollider.enabled = true;

            if (hit)
            {
                if(hit.collider.tag == "DestructableObstacle")
                {
                    attack.AttackDestructableObstacle(hit);
                    //print(hit.collider.gameObject.name);
                }else if(hit.collider.tag == "Enemy")
                {
                    attack.AttackEnemy(hit);
                }
            }
            clickedHorizontal = false;
        }


        }
}
