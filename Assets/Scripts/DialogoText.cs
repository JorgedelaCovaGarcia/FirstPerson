using UnityEngine;
using UnityEngine.UI;

public class DialogoText : MonoBehaviour
{
    private Text dialogoText;

    void Start()
    {
        dialogoText = GetComponent<Text>();
        if (dialogoText == null)
        {
            //como ten�a errores, puse esto para ver si detectaba el texto de di�logo o no
            Debug.Log("No se encontr� un componente de texto en el objeto del di�logo.");
        }
    }

    public void UpdateDialogue(string newText)
    {
        //para ir actualizando el di�logo
        if (dialogoText != null)
        {
            dialogoText.text = newText;
        }
    }
}