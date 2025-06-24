using UnityEngine;

public class Powerup : MonoBehaviour
{
    public SurfaceEffector2D surfaceEffector;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //the x is positive because the speed value is already negative
        rb.linearVelocity = new Vector2(surfaceEffector.speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
