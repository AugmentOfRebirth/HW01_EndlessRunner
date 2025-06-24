using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnedEnemy1;
    public GameObject spawnedEnemy2;
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
            spawnEnemy();
            time = 0f;
        }
    }

    void spawnEnemy()
    {
        GameObject enemyToSpawn;
        // Randomly choose 0 or 1
        int spawnNum = Random.Range(0, 2);

        if (spawnNum == 0)
        {
            enemyToSpawn = spawnedEnemy1;
        }
        else
        {
            enemyToSpawn = spawnedEnemy2;
        }

        GameObject spawnLocation = enemyToSpawn;

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        enemyToSpawn.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
    }
    
}
