using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public Transform player; // Referencia al jugador
    private NavMeshAgent agent;
    public float detectionRange = 10f; // Rango de detección
    private bool isPlayerInRange = false; // ¿Está el jugador dentro del rango?

    [SerializeField] private int maxVida = 5; // Vida máxima del enemigo
    private int vidaActual; // Vida actual del enemigo

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        vidaActual = maxVida; 
    }

    void Update()
    {
        
        if (isPlayerInRange && player != null)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath();
        }
    }

    public void TakeDamage(int damage)
    {
        vidaActual -= damage;
        if (vidaActual <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
