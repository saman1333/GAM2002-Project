using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour {

    public float fullHealth;
    float currentHealth;
    PlayerController controlMov;
    public GameObject bloodSplater;

    public AudioClip playerHurt;
    AudioSource playerAudioS;

    public Slider healthslider;
    public Image damageNotification;
    public Text GameOver;

    

    private bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.6f);
    float smoothColor = 5f;

    void Start() {
        currentHealth = fullHealth;
        controlMov = GetComponent<PlayerController>();

        healthslider.maxValue = fullHealth;
        healthslider.value = fullHealth;

        playerAudioS = GetComponent<AudioSource>();

    }


    void Update() {
        if (damaged)
        {
            damageNotification.color = damagedColor;
        }
        else
        {
            damageNotification.color = Color.Lerp(damageNotification.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        playerAudioS.clip = playerHurt;
        playerAudioS.Play();

        healthslider.value = currentHealth;
        damaged = true;
       

        if (currentHealth <= 0) {
            makeDead();
        }
    }

    public void addHealth(float healthamount)
    {
        currentHealth += healthamount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthslider.value = currentHealth;
        
    }


    public void makeDead()
    {
        Instantiate(bloodSplater, transform.position, transform.rotation);
        Destroy(gameObject);
        FindObjectOfType<Soundeffect>().DeathSound();
       
        Animator GameOverAnimator = GameOver.GetComponent<Animator>();
        GameOverAnimator.SetTrigger("GameOver");

    }
}
    