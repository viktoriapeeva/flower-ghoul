using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Animator playerAnimator;
    public Item item;
    public void Awake()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }
  
    public override void Interact()
    {
        base.Interact();
        playerAnimator.SetBool("isPicking", true);
        StartCoroutine(WaitForAnimationToFinish());
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    void PickUp()
    {

       Debug.Log("Item " + item.name +" has been picked up");
       bool wasPickedUp= Inventory.instance.Add(item);
        if (wasPickedUp) {
            Destroy(gameObject);
        }   
    }
    IEnumerator WaitForAnimationToFinish()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length + playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        playerAnimator.SetBool("isPicking", false);
        PickUp();
    }

}
