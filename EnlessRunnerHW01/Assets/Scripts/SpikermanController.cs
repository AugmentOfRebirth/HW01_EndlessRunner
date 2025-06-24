using UnityEngine;

public class SpikermanController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D spikermanRb;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cleans up the enemies after they leave the camera
        if (collision.gameObject.CompareTag("OB"))
        {
            Destroy(this.gameObject);
        }
    }
}
