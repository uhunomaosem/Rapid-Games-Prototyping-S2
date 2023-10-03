using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemy;

    //The delay to spawn: 0.25 seconds
    public float delay = 0.25f;
    //The counter, starting at 0
    private float counter = 0;
    private float timetaken = 0;

    public void SpawnEnemy(GameObject player, GameObject prefab)
    {
        //The radius to spawn enemies around thse player
        float enemySpawnRadius = 5.0f;

        //The player's position
        Vector3 playerPos = player.transform.position;

        //The spawn position: player pos + random point * radius
        Vector3 spawnPos = playerPos + (Vector3)Random.insideUnitCircle.normalized * enemySpawnRadius;

        Instantiate(prefab, spawnPos, Quaternion.identity);

    }

    private void FixedUpdate()
    {
        int rand = Random.Range(0, enemy.Length);
        GameObject enemyToSpawn = enemy[rand];
        //Increase counter
        counter += Time.deltaTime;
        timetaken += Time.deltaTime;
        if (counter >= delay)
        {
            //Has it reached the delay? If so, set counter to 0
            counter = 0;
            //And spawn an enemy
            SpawnEnemy(player, enemyToSpawn);
        }

        if (timetaken >= 20)
        {
            delay = 1;

        }


    }

}
