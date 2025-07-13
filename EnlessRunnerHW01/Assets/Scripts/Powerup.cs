using UnityEngine;


public class Powerup : MonoBehaviour
{
    public enum PowerupType
    {
        SpeedBoost,
        Points,
        Death
    }

    public SurfaceEffector2D surfaceEffector;
    private Rigidbody2D rb;
    public PowerupType powerupType;
    public int pointsAmount;
    public int speedAmount;
    private PlayerScore playerScore;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScore = gameObject.GetComponent<PlayerScore>();
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
            ApplyPowerup();

            Destroy(this.gameObject);
        }
    }

    void ApplyPowerup()
    {
        if (powerupType == PowerupType.Points)
        {
            playerScore.powerupScore(pointsAmount);
        }
    }
}
