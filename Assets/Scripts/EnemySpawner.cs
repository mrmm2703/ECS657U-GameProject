using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int layers;
    private Vector3 spawnLocation;
    private float delayAfter;
    private float enemySpeed;

    public void Setup(int layers, float delayAfter, Vector3 spawnLocation, GameObject enemyObject, float enemySpeed)
    {
        this.layers = layers;
        this.spawnLocation = spawnLocation;
        this.delayAfter = delayAfter;
        this.enemy = enemyObject;
        this.enemySpeed = enemySpeed;
    }

    public float Spawn()
    {
        GameObject enemyObject = Instantiate(enemy, spawnLocation, Quaternion.identity);
        enemyObject.SetActive(false);
        enemyObject.GetComponent<EnemyController>().Setup(enemySpeed, layers);
        enemyObject.GetComponent<EnemyController>().Activate();
        return delayAfter;
    }

    public float GetDelay()
    {
        return delayAfter;
    }
}
