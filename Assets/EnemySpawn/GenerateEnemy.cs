using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public int enemyCount = 0;
    
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)
        {
            Debug.Log("enemies " + enemyCount);
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 31);
            Instantiate(Enemy, new Vector3(xPos, 17, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
