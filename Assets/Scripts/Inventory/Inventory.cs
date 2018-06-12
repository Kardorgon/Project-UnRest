using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    #region Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    public List<Item> items = new List<Item>();
    //max inventory slots
    public int space = 20;
    //delegate is an event you can subrscribe different methods to
    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallBack;


    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room in the inventory");
                return false;
            }
            items.Add(item);
            //if to make sure we have some method subsribed, if not, we would get error without if statement
            if(onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
