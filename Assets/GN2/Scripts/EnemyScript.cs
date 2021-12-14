using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

   
    public GameObject enemyPrefab;
    private float spawnRange = 16.0f;
    public int enemyCount;
    public int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        //calls spawn wave on start witht the wavenumber
        SpawnEnemyWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {

        enemyCount = FindObjectsOfType<Enemy>().Length;
        // if  enemies are dead it adds one more wave to the wavenumber and then again starts enemywave
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //how much enemies to spawn in this case always 1+
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //instaniates zombie spawn and their spawnPos
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


    private Vector3 GenerateSpawnPosition()
    {
        //spawnposX and Z set within random range of spawnRange
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        
        Vector3 randomPos = new Vector3(spawnPosX, -1, 7);
        //makes the random pos spawn enemies at randomPos
        return randomPos;
    }
}

