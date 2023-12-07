using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject spawnPoint;
    private Vector3 spawnVector;
    public GameObject enemyToSpawn;

    public int initialHealthPoints = 150;
    public int initialGamePoints = 20;

    private int roundNumber = 1;

    // Calculate the number of waves for the current round
    private int CalculateWaves()
    {
        return (int)(2.5f * Mathf.Sqrt(roundNumber));
    }

    // Calculate maximum layers for the current round
    private int CalculateMaxLayers()
    {
        return (int)(2f * Mathf.Sqrt(roundNumber));
    }

    // Calculate minimum number of layers based on maximum 
    private int CalculateMinLayers(int maxLayers)
    {
        return Mathf.Max((int)(maxLayers * 0.75f), 1);
    }

    // Calculate number of enemies for a given round of waves
    private int CalculateEnemiesInWave(int waveNumber)
    {
        return 5;
        //return (int)(0.001f * Mathf.Pow(waveNumber+25, 2f));
    }

    // Calculate time delay between enemies spawning based on round and wave
    private float CalculateTimeBetweenEnemies(int waveNumber)
    {
        float x = (-0.15f * (0.25f * roundNumber) * waveNumber) + 1.25f;
        if (x < 0.2) x = 0.2f;
        return x;
    }

    // Calculate the speed of enemies for the current round
    private float CalculateEnemySpeed()
    {
        return (int)(3f * Mathf.Sqrt(roundNumber+0.8f));
    }

    private void NewRound()
    {    
        Queue<EnemyWave> waves = new Queue<EnemyWave>();

        // Use graph functions to calculate max layers and no. of waves
        int maxLayers = CalculateMaxLayers();
        int minLayers = CalculateMinLayers(maxLayers);
        int numWaves = CalculateWaves();
        float enemySpeed = CalculateEnemySpeed();
        Debug.Log("Round " + roundNumber + ", min,max layers " + minLayers + "," + maxLayers + " numWaves " + numWaves);

        // Create all the waves
        for (int w = 1; w <= numWaves; w++)
        {
            EnemyWave curWave = gameObject.AddComponent<EnemyWave>();
            float enemyDelay = CalculateTimeBetweenEnemies(w);
            int numEnemies = CalculateEnemiesInWave(w);
            curWave.Setup(enemyDelay * 1.3f);
            int layersEnemies = Random.Range(minLayers, maxLayers);
            Debug.Log("Wave " + w +", delay " + enemyDelay + " numEnemies " + numEnemies + " layers " + layersEnemies);
            // Creates all the enemies wihtin the wave
            for (int e = 0; e < numEnemies; e++)
            {
                EnemySpawner newEnemySpawner = gameObject.AddComponent<EnemySpawner>();
                newEnemySpawner.Setup(layersEnemies, enemyDelay, spawnVector, enemyToSpawn, enemySpeed);
                curWave.AddEnemy(newEnemySpawner);
            }
            waves.Enqueue(curWave);
            Debug.Log("Added wave with " + curWave.GetNumberOfEnemies() + " enemies");
        }

        StartCoroutine(StartRound());

        // Start all the waves in the round, then run another new round
        IEnumerator StartRound()
        {
            while (waves.Count > 0)
            {
                EnemyWave curWave = waves.Dequeue();
                float waitTime = curWave.GetTotalWaveTime();
                curWave.Spawn();
                yield return new WaitForSeconds(waitTime);
            }
            NewRound();
        }

        roundNumber++;
        StorageController.SetGameRound(roundNumber-1);
    }

    // Start is called before the first frame update
    void Start()
    {
        float spawnX = spawnPoint.transform.position.x;
        float spawnZ = spawnPoint.transform.position.z;
        spawnVector = new Vector3(spawnX, 0, spawnZ);
        InvokeRepeating("GiveMoney", 30f, 20f);
        Invoke("NewRound", 1f);
        StorageController.SetHealthPoints(initialHealthPoints);
        StorageController.SetGamePoints(initialGamePoints);
        StorageController.SetGameRound(roundNumber);
    }

    // Give money to the player
    void GiveMoney()
    {
        StorageController.AddGamePoints(10);
    }
}
