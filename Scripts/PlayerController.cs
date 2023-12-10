using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFascingRight = true;
    private bool isFire = false;
    public static Vector3 position;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(IntroTextController.isIntroEnd)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (transform.position.y <= -6)
                Die();

            if (Input.GetKey(KeyCode.F) && !isFire)
            {
                Fire();
                isFire = true;
            }

            else if (!Input.GetKey(KeyCode.F))
                isFire = false;

            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Flip()
    {
        if (isFascingRight && horizontal < 0f || !isFascingRight && horizontal > 0f)
        {
            isFascingRight = !isFascingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }

    private void Fire()
    {
        if (bullet != null)
        {
            Vector2 spawnPosition;
            if (transform.localScale.x > 0)
                spawnPosition = new Vector2(transform.position.x + 1 , transform.position.y);
            else
                spawnPosition = new Vector2(transform.position.x - 1, transform.position.y);
            
            GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                if(transform.localScale.x > 0)
                    bulletRb.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                else
                    bulletRb.AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);
            }

            Destroy(newBullet, 2);
        }
    }

}
