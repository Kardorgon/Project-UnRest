﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Eventsystem to stop player for moving when inventory open, for example
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour {

    private Attack attack;

    public LayerMask layer;
    public Interactable focus;
    //bool clickedX = true;
    BoxCollider2D boxCollider;
    //interractRadius będzie inny dla knighta, archera, maga itp
    int interractRadius = 1;
    
    // Use this for initialization
    void Start() {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        attack = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update() {

        //if we hover over ui we can't move
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            boxCollider.enabled = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
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
            //mamy hit wszystkich obiektow ktore nie sa na layer w odleglosci 1 kratki
            //distance = tu dystans jaki bedziemy miec do interakcji z przedmiotem. Zamienic z interractRadius
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1, ~layer);

            if (hit)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
                /*print(hit.collider.name);
                if(hit.collider.tag == "DestructableObstacle")
                {
                    attack.AttackDestructableObstacle(hit);
                }
                else if(hit.collider.tag == "Enemy")
                {
                    attack.AttackEnemy(hit);
                }*/
            }
            else
            {
                RemoveFocus();
            }
            boxCollider.enabled = true;
            clickedHorizontal = false;
        }
        }
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus!= null)
                //jesli zaznaczymy inny obiekt to chcemy miec defocus
                focus.OnDefocused();
            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();
        focus = null;
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Interactable>())
        {
            if(collider.tag == "Item")
            {
                Destroy(collider.gameObject);
            }
        }
    }
}