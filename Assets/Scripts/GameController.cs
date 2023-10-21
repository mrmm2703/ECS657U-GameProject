using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemyToSpawn;

    private float spawnX;
    private float spawnZ;

    // Start is called before the first frame update
    void Start()
    {
        spawnX = spawnPoint.transform.position.x;
        spawnZ = spawnPoint.transform.position.z;
        InvokeRepeating("SpawnEnemy", 3f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn an enemy
    void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, new Vector3(spawnX, 0 , spawnZ), Quaternion.identity);
    }
}
