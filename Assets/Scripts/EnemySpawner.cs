using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // Prefab del enemigo
    [SerializeField] public Transform player; // Referencia al jugador
    [SerializeField] Transform[] spawnPoints; // Puntos donde los enemigos pueden aparecer
    [SerializeField] float spawnTiempo = 5f; // Tiempo entre apariciones
    [SerializeField] private int maxEnemies = 10; // Máximo número de enemigos permitidos.
    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista para rastrear enemigos activos.

    private float timer;

    void Update()
    {
        // Temporizador para el spawn
        timer += Time.deltaTime;
        if (timer >= spawnTiempo)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Verificar si no se ha alcanzado el máximo de enemigos activos.
        if (activeEnemies.Count >= maxEnemies)
            return;

        // Seleccionar un punto de spawn al azar.
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instanciar un nuevo enemigo.
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();

        activeEnemies.Add(enemy);
        if (enemyAI != null)
        {
            enemyAI.player = player; // Aquí se asigna correctamente la referencia al jugador.
        }
    }
}

