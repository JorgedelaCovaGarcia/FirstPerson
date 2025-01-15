using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPrimera : MonoBehaviour
{
    [SerializeField] GameObject surikenPrefab;
    [SerializeField] Transform firePoint; 
    [SerializeField] float velocidad = 20f; 
    [SerializeField] AudioSource sonido; 
    [SerializeField] int damage = 1; 
    [SerializeField] float tiempoVida = 5f; 

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(surikenPrefab, firePoint.position, firePoint.rotation);

        // Aplicar velocidad al suriken
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * velocidad;
        }

        
        if (sonido != null)
        {
            sonido.Play();
        }

      
        SurikenFuncionamiento surikenLogic = bullet.AddComponent<SurikenFuncionamiento>();
        surikenLogic.Configure(damage, tiempoVida);
    }
}

public class SurikenFuncionamiento : MonoBehaviour
{
    private int damage;
    private float tiempoVida;

    public void Configure(int damage, float tiempoVida)
    {
        this.damage = damage;
        this.tiempoVida = tiempoVida;

        
        Destroy(gameObject, tiempoVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el proyectil golpea a un enemigo
        EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        
        Destroy(gameObject);
    }
}
