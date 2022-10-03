using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static EnemySpawner Instance { get; private set; }

    public GameObject enemyPrefab;

    public float minSpawnRadius = 15f;
    public float maxSpawnRadius = 20f;

    private Transform player;
    public float enemiesToSpawn = 1f;

    private const float enemiesToSpawnIncreaseMultiplier = 1.1f;

    void Awake ()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Start ()
    {
        TenSecondCycle.Instance.onCycleTick.AddListener(() => {
            for (int i = 0; i < Mathf.FloorToInt(enemiesToSpawn); i++) {
                SpawnEnemy();
            }

            // Increase enemies that spawn next cycle
            enemiesToSpawn *= enemiesToSpawnIncreaseMultiplier;
        });
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