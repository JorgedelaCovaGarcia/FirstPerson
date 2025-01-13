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
            Debug.LogError("No se encontró un componente de texto en el objeto del diálogo.");
        }
    }

    public void UpdateDialogue(string newText)
    {
        if (dialogoText != null)
        {
            dialogoText.text = newText;
        }
    }
}