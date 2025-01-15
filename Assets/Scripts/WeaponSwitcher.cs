using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    private int armaActual = 0;

    void Start()
    {
        ActivarArma(armaActual);
    }

    void Update()
    {
        //cambia de arma al darle a la F
        if (Input.GetKeyDown(KeyCode.F))
        {
            CambiarArma();
        }
    }

    void CambiarArma()
    {
     
        armas[armaActual].SetActive(false);

        //para poder cambiar de arma (calcula el índice del arma)
        armaActual = (armaActual + 1) % armas.Length;

   
        armas[armaActual].SetActive(true);
    }

    void ActivarArma(int indice)
    {
      
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(i == indice);
        }
    }
}
