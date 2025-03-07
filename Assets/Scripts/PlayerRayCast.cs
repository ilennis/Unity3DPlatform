using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public float raycastDistance = 5f;
    public LayerMask itemLayer;
    public ItemUI itemUI;
  

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, itemLayer))
        {
            Jumper item = hit.collider.GetComponent<Jumper>();
            if (item != null && item.itemData != null)
            {
                itemUI.ShowItem(item.itemData.GetName());
                return; 
            }
        }
        itemUI.HideItem();
    }
}
