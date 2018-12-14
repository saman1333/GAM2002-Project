using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

    public GameObject turretBullet;
    public float shootTime;
    public Transform ShootFrom;

    float nextShoot;
    Animator turretAnimation;

	void Start () {
        turretAnimation = GetComponentInChildren<Animator>();
        nextShoot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag =="Player" && nextShoot < Time.time)
        {
            nextShoot = Time.time + shootTime;
            Instantiate(turretBullet, ShootFrom.position, Quaternion.identity);
            turretAnimation.SetTrigger("turretShoot");
        }
    }

}
