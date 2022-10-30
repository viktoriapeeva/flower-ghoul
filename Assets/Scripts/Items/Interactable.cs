using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject nearTo;
    public virtual void Interact()
    {

       
        Debug.Log("Interacting with: " + transform.name);
       
       
    }
    private void FixedUpdate()
    {
        if(nearTo!=null && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            Debug.Log("FixedUpdate()--Key is pressed! Wait for Interaction...");
            nearTo = null;
        }
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter()--Key is pressed! Wait for Interaction...");
            nearTo = other.gameObject;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        nearTo = null;
    }
}   
