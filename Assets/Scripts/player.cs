using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public int moveSpeed = 5;
    public float jumpForce = 8f;
    private bool isGrounded = true;

    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip jumpSound; // assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Move()
    {
        float horizontal = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (horizontal != 0)
        {
            body.position += Vector2.right * horizontal * moveSpeed * Time.deltaTime;
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            animator.SetBool("jump", true);
            isGrounded = false;

            // Play jump sound
            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("jump", false);
        }

        if (collision.gameObject.CompareTag("end"))
        {
            SceneManager.LoadScene("Level2");
        }
    }

    void Update()
    {
        Move();
        Jump();

        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
