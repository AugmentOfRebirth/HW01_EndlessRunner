using UnityEngine;

public class SpikermanController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
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
