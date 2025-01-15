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
            //como tenía errores, puse esto para ver si detectaba el texto de diálogo o no
            Debug.Log("No se encontró un componente de texto en el objeto del diálogo.");
        }
    }

    public void UpdateDialogue(string newText)
    {
        //para ir actualizando el diálogo
        if (dialogoText != null)
        {
            dialogoText.text = newText;
        }
    }
}