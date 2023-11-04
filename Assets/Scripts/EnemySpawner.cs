using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class which holds a Spawner for an enemy object containing the enemy
// object to spawn, its number of layers and will initialse the enemy when
// the Spawn method is called
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int layers;
    private Vector3 spawnLocation;
    private float delayAfter;
    private float enemySpeed;

    // Setup the EnemySpawner with attributes
    public void Setup(int layers, float delayAfter, Vector3 spawnLocation, GameObject enemyObject, float enemySpeed)
    {
        this.layers = layers;
        this.spawnLocation = spawnLocation;
        this.delayAfter = delayAfter;
        this.enemy = enemyObject;
        this.enemySpeed = enemySpeed;
    }

    // Spawn the enemy at the given location with given layers and speed, returns
    // the delay to wait after this enemy is spawned
    public float Spawn()
    {
        GameObject enemyObject = Instantiate(enemy, spawnLocation, Quaternion.identity);
        enemyObject.SetActive(false);
        enemyObject.GetComponent<EnemyController>().Setup(enemySpeed, layers);
        enemyObject.GetComponent<EnemyController>().Activate();
        return delayAfter;
    }

    // Get the delay to wait after this enemy is spawned
    public float GetDelay()
    {
        return delayAfter;
    }
}
