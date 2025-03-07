using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemUI : MonoBehaviour
{
    public Text itemText;
    
    public void ShowItem(string itemName)
    {
        itemText.text = itemName;
        itemText.gameObject.SetActive(true);
    }
    public void HideItem()
    {
        itemText.gameObject.SetActive(false);
    }
}
