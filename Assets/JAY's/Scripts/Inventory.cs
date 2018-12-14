using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public GameObject[] inventory = new GameObject[10];


    public void AddItem(GameObject key)
    {
        bool itemAdded = false;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = key;
                Debug.Log(key.name = "was added");
                itemAdded = true;
                key.SendMessage("DoInteraction");
                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log("inventory Full");
        }

    }


    public bool FindItem(GameObject key)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == key)
            {
                return true;
            }
        }
        return false;
    }



}