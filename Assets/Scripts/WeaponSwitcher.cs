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
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            CambiarArma();
        }
    }

    void CambiarArma()
    {
     
        armas[armaActual].SetActive(false);

       
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
