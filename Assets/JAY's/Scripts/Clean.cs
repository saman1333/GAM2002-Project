using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLayer")
        {
            playerHealth playerfell = other.GetComponent<playerHealth>();
            playerfell.makeDead();
        }
        else Destroy(other.gameObject);
    }

}
