using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;
    public int enemyCount;
    public GameObject powerupPrefab;
    public int waveNumber = 1;

    public GameObject enemyPrefab;
    //writing above line makes whatever GameObject put onto that as prefab.
    //like in scene we will drag and drop enemy gameobject into this 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        spawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        //here we are not checking that the position of player and spawining are different so sometimes it can happen that enemy respawn on top of player

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }


        // above line will instansiate new GameObject and that vector3 position and with default rotation

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
}
