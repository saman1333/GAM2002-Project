using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackforce;

    float nextDamage;

	void Start () {
        nextDamage = 0f;
	}
	
	
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Player" && nextDamage < Time.time)
        {
            playerHealth ph = other.gameObject.GetComponent<playerHealth>();
            ph.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }
        
    void pushBack(Transform pushObject)
    {
        Vector2 pushDir = new Vector2(pushObject.position.x - transform.position.x, 0).normalized;
        pushDir *= pushBackforce;
        Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDir, ForceMode2D.Impulse);
    }

}
