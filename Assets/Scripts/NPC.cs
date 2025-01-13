using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] private GameObject panelInteraccion; // UI que muestra "Presiona E para hablar"
    [SerializeField] private TMP_Text dialogoText; // Referencia al componente Text del di�logo
    [SerializeField] private string[] dialogos;

    private int indiceDialogo = 0;
    private bool jugadorCerca = false;

    void Start()
    {
        panelInteraccion.SetActive(false); // Oculta el panel al inicio
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            MostrarDialogo();
        }
    }

    private void MostrarDialogo()
    {
        if (indiceDialogo < dialogos.Length)
        {
            dialogoText.text = dialogos[indiceDialogo];
            Debug.Log("texto mostrando" + dialogos[indiceDialogo]);
            indiceDialogo++;
        }
        else
        {
            Debug.Log("Dialogo finalizado");
            dialogoText.text = ""; // Vac�a el texto al terminar el di�logo
            indiceDialogo = 0; // Reinicia el di�logo para la pr�xima interacci�n
            panelInteraccion.SetActive(false); // Oculta el panel al terminar
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador entra en el �rea
        {
            jugadorCerca = true;
            panelInteraccion.SetActive(true); // Muestra el panel
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador sale del �rea
        {
            jugadorCerca = false;
            panelInteraccion.SetActive(false); // Oculta el panel
            dialogoText.text = ""; // Resetea el di�logo
            indiceDialogo = 0; // Reinicia el �ndice
        }
    }
}

