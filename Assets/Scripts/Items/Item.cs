
using UnityEngine;

//to tell unity how we want to create new items we will use attribute
//because of that we can right click in the project -> create -> inventory
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
//blueprint for all of our scriptable objects
public class Item : ScriptableObject {

    //new ponieważ ScriptableObject already has definition of name
    //so we are overwriting the name
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

}
