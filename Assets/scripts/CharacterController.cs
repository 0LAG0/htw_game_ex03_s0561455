using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float topSpeed = 10f;
    bool facingRight = true;

    //not grounded
    bool grounded = false;

    //transform at robots feet to look for "is grounded ?"
    public Transform groundCheck;

    float groundRadius = 0.2f;
    public float jumpForce = 700f;

    public LayerMask whatIsGround;

    bool doubleJump = false;

    //reference animator
    Animator anim;

    public Transform muzzle;
    public GameObject bullet;

    //teleport
    public GameObject target;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //is grounded ?
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //tell animator we are grounded
        anim.SetBool("ground", grounded);

        //reset double jump
        if (grounded)
        {
            doubleJump = false;
        }

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        //get move direction
        float move = Input.GetAxis("Horizontal");

        //add velocity to rigid body
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);
        anim.SetFloat("speed", Mathf.Abs(move));

        //if moving in other direction, flip
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        //fire bullet
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject mBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
            mBullet.transform.parent = GameObject.Find("GameManager").transform;
            mBullet.GetComponent<Renderer>().sortingLayerName = "Player";

            anim.SetBool("isShooting", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isShooting", false);
            anim.SetBool("runningShoot", false);
        }

        if (Input.GetButtonDown("Fire1") && GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            anim.SetBool("runningShoot", true);
        }

    }
    private void Update()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            //not on the ground
            anim.SetBool("ground", false);
            //add jumpforce to rigigd body
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
            {
                doubleJump = true;
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        //get local scale
        Vector3 theScale = transform.localScale;
        //flip on x axis
        theScale.x *= -1;
        //apply to local scale
        transform.localScale = theScale;
    }

    public void Teleport()
    {
        transform.position = target.transform.position;
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(2);
    }
}
