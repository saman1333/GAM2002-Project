using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public GameObject key;
   public Key currentkeyscript = null;
    public Inventory inventory;

    private void Update()
    {
        if (Input.GetButtonDown("interact") && key)
        {
            if (currentkeyscript.inventory)
            {
                inventory.AddItem(key);
              }

            if (currentkeyscript.openable)
            {
                if (currentkeyscript.locked)
                {
                    if (inventory.FindItem (currentkeyscript.itemtounlock))
                    {
                        currentkeyscript.locked = false;
                        Debug.Log(key.name + "was unlocked");
                    }else
                    {
                        Debug.Log(key.name + "was not unlocked");
                    }
                }else
                {
                    Debug.Log(key.name + "is unlocked");
                    currentkeyscript.Open ();
                }
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("interactable"))
        {
            Debug.Log(other.name);
            key = other.gameObject;
            currentkeyscript = key.GetComponent<Key>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            if (other.gameObject == key)
            {
                key = null;
            }
        }

    }
}
	