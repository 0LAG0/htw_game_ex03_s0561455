using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float BulletSpeed;
    public CharacterController player;
    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Destroy(gameObject, 3f);
    }
    private void Start()
    {
        player = FindObjectOfType<CharacterController>();
        if(player.transform.localScale.x < 0)
        {
            BulletSpeed = -BulletSpeed;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0.1f);
    }
}
