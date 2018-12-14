using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour {

    public float healthamount;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>();
            theHealth.addHealth(healthamount);
            Destroy(gameObject);
        }
    }

}
