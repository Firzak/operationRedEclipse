using TMPro;
using UnityEngine;

public class DoorInteract : Interactable
{
    [SerializeField] private GameObject CodePanel;
    
    public override void OnInteract()
    {
        if (FindFirstObjectByType<ProgressManager>().code)
        {
            Debug.Log("tp");
        }
        else
        {
            Debug.Log("OnInteract appelé sur la porte !");
            if (CodePanel != null)
            {
                CodePanel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("CodePanel n'est pas assigné dans l'inspecteur !");
            }
        }
    }
}
