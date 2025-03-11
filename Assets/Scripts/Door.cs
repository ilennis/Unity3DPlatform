using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject closeDoor;
    public GameObject openDoor;
    public GameObject closeText;
    public GameObject openText;
    private bool isClosed;
    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isClosed)
                closeText.SetActive(true);
            else
                openText.SetActive(true);
            
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            closeText.SetActive(false);
            openText.SetActive(false);
        }
              
    }

    public void Interact()
    {
        if (isClosed)
        {
            closeDoor.SetActive(true);
            openDoor.SetActive(false);
            isClosed = false;
            closeText.SetActive(false);
            openText.SetActive(true);
        }
        else
        {            
            closeDoor.SetActive(false);
            openDoor.SetActive(true);
            isClosed = true;
            closeText.SetActive(true);
            openText.SetActive(false);
        }
    }


}
