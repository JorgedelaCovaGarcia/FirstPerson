using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPrimera : MonoBehaviour
{
    [SerializeField] GameObject surikenPrefab; // Prefab del proyectil
    [SerializeField] Transform firePoint; // Punto desde donde se dispara
    [SerializeField] float velocidad = 20f; // Velocidad del proyectil
    [SerializeField] AudioSource sonido; // Sonido del disparo
    [SerializeField] int damage = 1; // Daño que hace el proyectil
    [SerializeField] float tiempoVida = 5f; // Tiempo que dura el proyectil antes de destruirse

    void Update()
    {
        // Detectar disparo
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar el suriken en el punto de disparo
        GameObject bullet = Instantiate(surikenPrefab, firePoint.position, firePoint.rotation);

        // Aplicar velocidad al suriken
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * velocidad;
        }

        // Reproducir sonido si está asignado
        if (sonido != null)
        {
            sonido.Play();
        }

        // Asignar comportamiento del proyectil
        SurikenLogic surikenLogic = bullet.AddComponent<SurikenLogic>();
        surikenLogic.Configure(damage, tiempoVida);
    }
}

// Clase interna para gestionar la lógica del Suriken
public class SurikenLogic : MonoBehaviour
{
    private int damage;
    private float tiempoVida;

    public void Configure(int damage, float tiempoVida)
    {
        this.damage = damage;
        this.tiempoVida = tiempoVida;

        // Destruir el proyectil después de cierto tiempo
        Destroy(gameObject, tiempoVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el proyectil golpea a un enemigo
        EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Asumimos que EnemyAI tiene un método TakeDamage
        }

        // Destruir el proyectil tras el impacto
        Destroy(gameObject);
    }
}
