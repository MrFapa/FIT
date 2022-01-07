using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnAreaFactor;

    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private int enemyPerSpawn;

    private float timeUntilNextSpawn = 0;

    private int basicSpawnOffset = 10;

    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextSpawn < Time.time)
        {
            timeUntilNextSpawn = Time.time + spawnTime;

            for (int i = 0; i < enemyPerSpawn; i++)
            {
                float sW = Screen.width;
                float sH = Screen.height;

                float spawnX = (Random.Range(0, 2) == 0) ? Random.Range(-(sW * spawnAreaFactor), -basicSpawnOffset) : Random.Range(sW + basicSpawnOffset, sW + sW * spawnAreaFactor);
                float spawnY = (Random.Range(0, 2) == 0) ? Random.Range(-(sH * spawnAreaFactor), -basicSpawnOffset) : Random.Range(sH + basicSpawnOffset, sH + sH * spawnAreaFactor);

                Vector3 spawn = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, spawnY, 0));
                Instantiate(enemyPrefab, spawn, Quaternion.identity);
            }

        }
    }
}
