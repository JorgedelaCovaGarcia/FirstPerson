using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] private GameObject panelInteraccion;
    [SerializeField] private TMP_Text dialogoText;
    [SerializeField] private string[] dialogos;

    private int indiceDialogo = 0;
    private bool jugadorCerca = false;

    void Start()
    {
        panelInteraccion.SetActive(false);
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
            dialogoText.text = ""; 
            indiceDialogo = 0; 
            panelInteraccion.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            jugadorCerca = true;
            panelInteraccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            panelInteraccion.SetActive(false); 
            dialogoText.text = ""; 
            indiceDialogo = 0; 
        }
    }
}

