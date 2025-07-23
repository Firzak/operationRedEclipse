using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject canvasInteraction;       // Le canvas "Appuyez sur E"

    protected void Start()
    {
        if (canvasInteraction != null)
            canvasInteraction.SetActive(false);
    }

    // Méthode appelée lors de l'interaction
    public virtual void OnInteract()
    {
        Debug.Log("Interacted with: " + gameObject.name);
        // Implémentez ici la logique d'interaction spécifique
    }
}
