using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Demo");
    }
    public void Exit()
    {
        //Application.Quit();
    }
}
