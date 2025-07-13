using UnityEngine;


public class Powerup : MonoBehaviour
{
    public enum PowerupType
    {
        Normal,
        Death
    }

    //public SurfaceEffector2D surfaceEffector;
    private Rigidbody2D rb;
    private float speed = 1f;
    public PowerupType powerupType;
    //public int pointsAmount;
    //public int speedAmount;
    //private PlayerScore playerScore;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerScore = gameObject.GetComponent<PlayerScore>();

        if (powerupType == PowerupType.Normal)
        {
            rb.linearVelocity = Vector2.left * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.down * speed;
        }
        
    }
    private void FixedUpdate()
    {
        //the x is positive because the speed value is already negative
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        //ApplyPowerup();

    //        Destroy(this.gameObject);
    //    }
    //}

    //void ApplyPowerup()
    //{
    //    if (powerupType == PowerupType.Points)
    //    {
    //        playerScore.powerupScore(pointsAmount);
    //    }
    //}
}
