using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTrack : MonoBehaviour
{

    public TextMeshProUGUI txtScore;

    public int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger vao: " + other.gameObject.tag);

        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            score++;
            txtScore.SetText(score.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Va cham vao: " + other.gameObject.tag);
        if (other.gameObject.tag == "nendat")
        {
            isGrounded = true;
            animator.SetBool("isGround", true);
            animator.SetBool("isRun", false);
        }
        
    }

    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    int jumpCount = 1;
    float movePrefix = 3;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded)
            {
                rigidbody2d.AddForce(Vector2.up * movePrefix * 2, ForceMode2D.Impulse);
                isGrounded = false;

                animator.SetBool("isGround", false);
                animator.SetBool("isRun", false);
            }


        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            rigidbody2d.AddForce(Vector2.left * movePrefix, ForceMode2D.Impulse);

            animator.SetBool("isRun", true);

            // doi chay het animation run
            //setToIdle();

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            rigidbody2d.AddForce(Vector2.right * movePrefix, ForceMode2D.Impulse);

            animator.SetBool("isRun", true);

            //setToIdle();
        }

    }

    private void setToIdle()
    {
        StartCoroutine(wait(1f));

        animator.SetBool("isRun", false);
        animator.SetBool("isGround", true);
    }

    IEnumerator wait(float timeSeconds)
    {

        yield return new WaitForSeconds(timeSeconds);

    }
}
