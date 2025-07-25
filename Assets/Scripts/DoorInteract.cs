using TMPro;
using UnityEngine;

public class DoorInteract : Interactable
{
    [SerializeField] private GameObject CodePanel;
    [SerializeField] private int codeLevel = 1; // Niveau de code requis pour interagir
    [SerializeField] private Transform tpTransform; // Transform pour le téléporteur
    
    public override void OnInteract()
    {
        if (FindFirstObjectByType<ProgressManager>().code >= codeLevel)
        {
            Debug.Log("OnInteract appelé sur le téléporteur !");
            if (tpTransform != null)
            {
                GameObject player = FindFirstObjectByType<MoveScript>().gameObject;
                player.transform.position = tpTransform.position;
                player.transform.rotation = tpTransform.rotation;
                player.transform.localScale = tpTransform.localScale;
            }
            else
            {
                Debug.LogWarning("tpTransform n'est pas assigné dans l'inspecteur !");
            }
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
