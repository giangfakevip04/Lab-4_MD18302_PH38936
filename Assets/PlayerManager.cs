using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    Transform transform;
    SpriteRenderer spriteRenderer;
    bool isGrounded = false;

    private void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        transform = this.gameObject.GetComponent<Transform>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    float movePrefix = 6;

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rigidbody2D.AddForce(Vector2.up * movePrefix, ForceMode2D.Impulse);
                isGrounded = false;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            spriteRenderer.flipX = true;


            //transform.Translate(- Time.deltaTime * 100, 0, 0);

            //Vector2 scale = transform.localScale;
            //scale.x *= scale.x > 0 ? -1 : 1;
            //// neu scale >0 thi scale lon hon 0 else
            //transform.localScale = scale;

            rigidbody2D.AddForce(Vector2.left * movePrefix, ForceMode2D.Impulse);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            rigidbody2D.AddForce(Vector2.right * movePrefix, ForceMode2D.Impulse);
            
        }
    }

    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Va cham voi: " + other.gameObject.tag);
        if (other.gameObject.tag == "nendat")
        {
            isGrounded = true;
        }
    }

    
}
