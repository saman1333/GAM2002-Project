using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    float currentHealth;

    public bool drops;
    public GameObject theDrop;

    public GameObject enemeyDeath;
    public Slider enemyHealthBar;

	void Start () {
        currentHealth = enemyMaxHealth;
        enemyHealthBar.maxValue = currentHealth;
        enemyHealthBar.value = currentHealth;
	}
	

	void Update () {
		
	}

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthBar.gameObject.SetActive(true);
        enemyHealthBar.value = currentHealth;
        if (currentHealth<= 0) makeDead();
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemeyDeath, transform.position, transform.rotation);
        //Quaternion FixRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - 89.971f, transform.rotation.w);
        Quaternion bob = new Quaternion(0, 0, 0, 0);
        if (drops) Instantiate(theDrop, transform.position, bob);
    }

}
