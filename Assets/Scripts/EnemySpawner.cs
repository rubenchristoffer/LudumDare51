using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static EnemySpawner Instance { get; private set; }

    public Transform player;
    public GameObject enemyPrefab;

    public float minSpawnRadius = 15f;
    public float maxSpawnRadius = 30f;

    void Awake ()
    {
        Instance = this;
    }

    public void SpawnEnemy ()
    {
        float spawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);

        GameObject enemy = Instantiate<GameObject>(enemyPrefab, player.position + Random.onUnitSphere * spawnRadius, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().target = player;
    }

}