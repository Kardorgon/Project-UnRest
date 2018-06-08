
using UnityEngine;

public class ItemPickUp : Interactable {

    public Item item;

    public override void Interact()
    {
        //this statement goes back to the base class, in this case Interactable.Interact and does what Interact() method. We can place additional lines here before or after and we don't have to use this line at all.
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        
        Debug.Log("Picking up " + item.name);
        //Add to inventory        
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp == true)
            Destroy(gameObject);
    }
}
