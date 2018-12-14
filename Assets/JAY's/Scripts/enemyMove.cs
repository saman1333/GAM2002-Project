using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour {

    public float enemySpeed;
    Animator enemyAnimator;

    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingright = false;
    float fliptime = 5f;
    float nextFlip = 0f;

    public float chargeTime;
    float startCharge;
    bool charging;
    Rigidbody2D enemyRB;

	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
	}


	void Update () {
        if (Time.time > nextFlip) ;
        if (Random.Range(0, 1) >= 5) flipFacing();
        nextFlip = Time.time + fliptime;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (facingright && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }   else if (!facingright && other.transform.position.x> transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startCharge = Time.time + chargeTime;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(startCharge < Time.time)
            {
                if (!facingright) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", charging);
        }
    }
   


    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingright = !facingright;


    }


}
