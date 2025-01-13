using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoConCamara : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento = 5f; // Velocidad de movimiento
    [SerializeField] private float gravedad = -9.81f; // Gravedad
    [SerializeField] private float alturaSalto = 2f; // Altura del salto
    private CharacterController characterController;
    private Vector3 velocidadVertical; // Para manejar la gravedad y el salto

    private Transform camaraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camaraTransform = Camera.main.transform;
    }

    void Update()
    {
        Mover();  // Movimiento del personaje
        AplicarGravedad();  // Gravedad y salto
    }

    void Mover()
    {
        // Leer las entradas de las teclas de movimiento
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Crear un vector de dirección de movimiento
        Vector3 inputMovimiento = new Vector3(h, 0, v).normalized;

        if (inputMovimiento.magnitude > 0.1f)
        {
            // Calcular la dirección del movimiento en función de la cámara
            Vector3 direccionCamara = camaraTransform.forward;
            direccionCamara.y = 0; // Ignorar la componente Y de la cámara
            Quaternion rotacionCamara = Quaternion.LookRotation(direccionCamara);
            Vector3 direccionMovimiento = rotacionCamara * inputMovimiento;

            // Mover el personaje
            characterController.Move(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            // No hay movimiento, por lo que el personaje se detiene de inmediato.
            characterController.Move(Vector3.zero);
        }
    }

    void AplicarGravedad()
    {
        if (characterController.isGrounded)
        {
            // Asegurarse de que la velocidad vertical es pequeña cuando está en el suelo
            if (velocidadVertical.y < 0)
            {
                velocidadVertical.y = -2f;  // Pequeño valor para mantener al personaje en el suelo
            }

            // Detectar salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadVertical.y = Mathf.Sqrt(alturaSalto * -2f * gravedad); // Calcular salto
            }
        }
        else
        {
            // Si el personaje no está en el suelo, aplicar gravedad
            velocidadVertical.y += gravedad * Time.deltaTime;
        }

        // Aplicar el movimiento vertical (gravedad y salto)
        characterController.Move(velocidadVertical * Time.deltaTime);
    }
}

