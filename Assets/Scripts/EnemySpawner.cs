using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] public Transform player;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnTiempo = 5f;
    [SerializeField] private int maxEnemies = 10;
    
    private List<GameObject> activeEnemies = new List<GameObject>();

    [SerializeField] private float timer;

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= spawnTiempo)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        //si se han creado más enemigos de la cuenta, sale del método
        if (activeEnemies.Count >= maxEnemies)
        {
            return; 
        }   
        
        //para randomizar los puntos de spawn
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        //manejar oleadas (genera un nuevo enemigo en la posición y rotación del punto de aparición)

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();

        activeEnemies.Add(enemy);

    }
}

