using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//fields in this class will show up in the inspector
[System.Serializable]
public class Stat  {
    [SerializeField]
    private int baseValue;
    private List<int> modifiers = new List<int>();
    public int GetValue()
    {
        //we need to get the armor and damage and other modifiers values and foreach add or remove the value
        int finalValue = baseValue;
        //foreach element in out modifier list, given element x
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }
    public void AddModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
