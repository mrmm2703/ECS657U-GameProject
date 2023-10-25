using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemyToSpawn;

    private float spawnX;
    private float spawnZ;

    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnX = spawnPoint.transform.position.x;
        spawnZ = spawnPoint.transform.position.z;
        InvokeRepeating("SpawnEnemy", 3f, 1f);
        InvokeRepeating("GiveMoney", 30f, 20f);
        StorageController.SetHealthPoints(150);
        StorageController.SetGamePoints(20);
        InvokeRepeating("PrintStats", 0f, 1f);
    }

    void PrintStats()
    {
        Debug.Log("Game Points: " + StorageController.GetGamePoints().ToString());
        Debug.Log("Health Points: " + StorageController.GetHealthPoints().ToString());
    }

    void GiveMoney()
    {
        StorageController.AddGamePoints(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    public void removePoints(int pointsToRemove)
    {
        points -= pointsToRemove;
    }

    // Spawn an enemy
    void SpawnEnemy()
    {
        float speed = Random.Range(2f, 20f);
        GameObject enemy = Instantiate(enemyToSpawn, new Vector3(spawnX, 0 , spawnZ), Quaternion.identity);
        enemy.GetComponent<EnemyController>().speed = speed;
    }
}
