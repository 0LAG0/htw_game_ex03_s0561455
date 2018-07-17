using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
    public float Health = 100;
    public Transform target;
    public float engageRange = 10f;
    public float attackRange = 3f;
    public float moveSpeed = 5f;
    private bool facingLeft = true;
    Animator anim;

    public CharacterController characterController;
    public float attackDamage = 2f;

    public SpriteRenderer healthBar;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", false);


        if (Vector3.Distance(target.position, this.transform.position) < engageRange)
        {
            anim.SetBool("isIdle", false);

            Vector3 direction = target.position - this.transform.position;
            if(Mathf.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }else if(Mathf.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }

            if(direction.magnitude >= attackRange)
            {
                anim.SetBool("isWalking", true);
                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
                }
            }
            if (direction.magnitude < attackRange)
            {
                anim.SetBool("isAttacking", true);
                characterController.GetComponentInChildren<PlayerHealth>().currentHealth -= attackDamage;
                characterController.GetComponentInChildren<PlayerHealth>().healthBar.value = characterController.GetComponentInChildren<PlayerHealth>().currentHealth;
            }
        }
        else if(Vector3.Distance(target.position, this.transform.position) > engageRange)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        //get local scale
        Vector3 theScale = transform.localScale;
        //flip on x axis
        theScale.x *= -1;
        //apply to local scale
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {

            Health -= 10;
            healthBar.GetComponent<Transform>().localScale -= new Vector3(.1f, 0, 0);
            if(Health <= 0)
            {

                anim.SetBool("isDead", true);
                Destroy(gameObject, 2);
                Destroy(healthBar, 0);
                GetComponent<ZombieController>().enabled = false;
            }
            
        }
    }
}
