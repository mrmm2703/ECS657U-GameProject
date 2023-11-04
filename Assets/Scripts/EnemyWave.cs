using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class which holds a wave of EnemySpawner objects which is capable of
// spawning an entire wave automatically
public class EnemyWave : MonoBehaviour
{
    private Queue<EnemySpawner> enemies = new Queue<EnemySpawner>();
    private float timeAfterWave = 1;
    private float totalWaveTime = 1;

    // Setup the time to wait after the wave is complete
    public void Setup(float timeAfterWaveDelay = 1)
    {
        timeAfterWave = timeAfterWaveDelay;
        totalWaveTime = timeAfterWaveDelay;
    }

    // Returns the number of enemies in the wave
    public int GetNumberOfEnemies()
    {
        return enemies.Count;
    }

    // Add a new EnemySpawner to this wave of enemies
    public void AddEnemy(EnemySpawner newEnemy)
    {
        enemies.Enqueue(newEnemy);
        totalWaveTime += newEnemy.GetDelay();
    }

    // Start spawning all of the enemies with respect to the delays
    public void Spawn()
    {
        Debug.Log("Starting new wave");
        StartCoroutine(Spawner());
    }

    // Spawn all enemies in the queue and wait after delay after each balloon
    IEnumerator Spawner()
    {
        while (enemies.Count > 0)
        {
            float waitTime = SpawnOneEnemy();
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Get the total time for how long the wave will take to spawn all enemies
    public float GetTotalWaveTime()
    {
        return totalWaveTime;
    }

    // Spawn the next enemy in the wave
    private float SpawnOneEnemy()
    {
        EnemySpawner toSpawn = enemies.Dequeue();
        return toSpawn.Spawn();
    }
}
