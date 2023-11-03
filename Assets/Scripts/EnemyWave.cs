using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    private Queue<EnemySpawner> enemies = new Queue<EnemySpawner>();
    private float timeAfterWave = 1;
    private float totalWaveTime = 1;

    public void Setup(float timeAfterWaveDelay = 1)
    {
        timeAfterWave = timeAfterWaveDelay;
        totalWaveTime = timeAfterWaveDelay;
    }

    public int GetNumberOfEnemies()
    {
        return enemies.Count;
    }

    public void AddEnemy(EnemySpawner newEnemy)
    {
        enemies.Enqueue(newEnemy);
        totalWaveTime += newEnemy.GetDelay();
    }

    public void Spawn()
    {
        Debug.Log("Starting new wave");
        StartCoroutine(Spawner());
    }

    public float GetTotalWaveTime()
    {
        return totalWaveTime;
    }

    IEnumerator Spawner()
    {
        while (enemies.Count > 0)
        {
            float waitTime = SpawnOneEnemy();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private float SpawnOneEnemy()
    {
        EnemySpawner toSpawn = enemies.Dequeue();
        return toSpawn.Spawn();
    }
}
