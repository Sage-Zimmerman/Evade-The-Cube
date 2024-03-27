using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject catchPrefab;
    public Vector2 spawnXrange;

    // Start is called before the first frame update
    void Start()
    {
        
        // Repat SpawnEnemy() every 2 seconds starting at second 0
        InvokeRepeating(nameof(SpawnEvader), 0, 2.0f);
        InvokeRepeating(nameof(SpawnCatchEnemy), 1f, 2.0f);
    }

    public void SpawnEvader()
    {
        SpawnEnemy(EnemyType.Evader);
    }

    public void SpawnCatchEnemy()
    {
        SpawnEnemy(EnemyType.Catcher);
    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(spawnXrange[0], spawnXrange[1]), 
        enemyPrefab.transform.position.y, 
        enemyPrefab.transform.position.z);

        if (enemyType == EnemyType.Evader)
        {
            Instantiate(enemyPrefab, 
                spawnPosition, 
                enemyPrefab.transform.rotation);
        } else
        {
            Instantiate(catchPrefab, 
                spawnPosition, 
                enemyPrefab.transform.rotation);
        }
    }

}
