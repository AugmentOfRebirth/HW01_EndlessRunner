using UnityEngine;


public enum PowerupType
{
    SpeedBoost,
    Points,
    Death
}



public class Powerup : MonoBehaviour
{
    public SurfaceEffector2D surfaceEffector;
    private Rigidbody2D rb;
    public PowerupType powerupType;
    public int pointsAmount;
    public int speedAmount;
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
            //ApplyPowerup();

            Destroy(this.gameObject);
        }
    }

    //void ApplyPowerup()
    //{
    //    switch (powerupType)
    //    {
    //        case PowerupType.Points:
    //            GetComponent<PlayerScore>().powerupScore(pointsAmount);
    //            break;
    //        case PowerupType.SpeedBoost:
    //            GetComponent<GameManager>().powerupSpeed(speedAmount);
    //            break;
    //        //case PowerupType.Death:
    //        //    GetComponent<PlayerScore>().ActivateDoublePoints();
    //        //    break;
    //    }
    //}
}
