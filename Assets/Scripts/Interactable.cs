
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    private bool isFocus = false;
    private bool hasInteracted = false;
    private Transform player;


    //all object will derive from Interactable class but different objects (chects, coins, enemies) will have different interaction thats why we use virtual to override it.
    public virtual void Interact()
    {
        //this method is meant to be overwriten
        Debug.Log("interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && hasInteracted == false)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if(distance < radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
