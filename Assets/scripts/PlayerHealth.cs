using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    public Slider healthBar;
    [SerializeField]
    Text healthText;
    [SerializeField]
    GameObject DeathUI;

    public float maxHealth = 100;
    public float currentHealth;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        healthBar.value = maxHealth;
        currentHealth = healthBar.value;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            healthBar.value -= 1.5f;
            currentHealth = healthBar.value;
        }
        if (collision.gameObject.tag == "Acid")
        {
            healthBar.value -= 0.1f;
            currentHealth = healthBar.value;
        }
    }

    void Update()
    {
        healthText.text = currentHealth.ToString("n0") + "%";
        if(currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            GetComponent<CharacterController>().enabled = false;
            DeathUI.gameObject.SetActive(true);
        }
    }
}
