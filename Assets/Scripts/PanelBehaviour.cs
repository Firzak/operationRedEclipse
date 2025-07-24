using UnityEngine;

public class PanelBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField codeInputField;
    
    public void CodeEntered()
    {
        string code = codeInputField.text;
        if (code == "2806")
        {
            FindFirstObjectByType<ProgressManager>().code = true;
            Debug.Log("Code correct !");
            gameObject.SetActive(false); // Ferme le panneau
        }
        else
        {
            Debug.Log("Code incorrect, essayez à nouveau.");
        }
    }
}
