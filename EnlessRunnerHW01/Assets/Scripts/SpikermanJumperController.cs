using UnityEngine;

public class SpikermanJumperController : MonoBehaviour
{
    private Rigidbody2D spikermanRb;
    public float jumpForce;
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spikermanRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spikermanRb.linearVelocity = new Vector2(-moveSpeed, spikermanRb.linearVelocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump();
        }
    }

    private void jump()
    {
        spikermanRb.linearVelocity = new Vector2(spikermanRb.linearVelocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cleans up the enemies after they leave the camera
        if (collision.gameObject.CompareTag("OB"))
        {
            Destroy(this.gameObject);
        }
    }
}
