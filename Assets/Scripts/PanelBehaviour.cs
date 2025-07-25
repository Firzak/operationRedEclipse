using UnityEngine;

public class PanelBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField codeInputField;
    [SerializeField] private int correctCode = 2806;
    
    public void CodeEntered()
    {
        string code = codeInputField.text;
        if (code == correctCode.ToString())
        {
            FindFirstObjectByType<ProgressManager>().code++;
            Debug.Log("Code correct !");
        }
        else
        {
            Debug.Log("Code incorrect, essayez à nouveau.");
        }
        gameObject.SetActive(false); // Ferme le panneau
    }
}
