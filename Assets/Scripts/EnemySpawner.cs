using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static EnemySpawner Instance { get; private set; }

    public GameObject enemyPrefab;

    public float minSpawnRadius = 15f;
    public float maxSpawnRadius = 30f;

    private Transform player;

    void Awake ()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player").transform;
    }

    public void SpawnEnemy ()
    {
        float spawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);

        GameObject enemy = Instantiate<GameObject>(enemyPrefab, player.position + Random.onUnitSphere * spawnRadius, Quaternion.identity);

        // Initialize spawned enemy
        enemy.GetComponent<EnemyMovement>().target = player;
        enemy.GetComponent<EnemyCombat>().playerEntity = player.GetComponent<Entity>();
    }

}