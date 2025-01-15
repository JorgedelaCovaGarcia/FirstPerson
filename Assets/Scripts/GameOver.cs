using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Demo");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
