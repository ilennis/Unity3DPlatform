using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "Custom/itemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _itemId;
    [SerializeField] private string _description;

    public string GetName()
    {
        return _name;
    }
    public string GetId()
    {
        return _itemId;
    }
    public string GetDescription()
    {
        return _description;
    }
}
