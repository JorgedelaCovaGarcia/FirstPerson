using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    public float detectionRange = 10f;
    private bool isPlayerInRange = false;

    [SerializeField] private int maxVida = 5;
    private int vidaActual; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<MovimientoConCamara>().transform;
        vidaActual = maxVida; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MovimientoConCamara jugador = collision.collider.GetComponent<MovimientoConCamara>();
            if (jugador != null)
            {
                
                
                SceneManager.LoadScene("GameOverScene");
                
            }
        }
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
