using UnityEngine;

public class PowerupSpawning : MonoBehaviour
{
    public GameObject spawnedPowerup1;
    public GameObject spawnedPowerup2;
    public GameObject spawnedPowerup3;
    private float time;
    private float delay = 0f;
    //these are the min and max amount of seconds that the next enemy will spawn
    public int minSeconds;
    public int maxSeconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        delay = Random.Range(minSeconds, maxSeconds);

        if (time >= delay)
        {
            spawnPowerup();
            time = 0f;
        }
    }

    private void spawnPowerup()
    {
        GameObject powerupToSpawn;
        // Randomly choose 0 or 1
        int spawnNum = Random.Range(0, 3);

        if (spawnNum == 0)
        {
            powerupToSpawn = spawnedPowerup1;
        }
        else if (spawnNum == 1)
        {
            powerupToSpawn = spawnedPowerup2;
        }
        else
        {
            powerupToSpawn = spawnedPowerup3;
        }

        GameObject spawnLocation = powerupToSpawn;

        Instantiate(powerupToSpawn, transform.position, Quaternion.identity);
        powerupToSpawn.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
    }
}
