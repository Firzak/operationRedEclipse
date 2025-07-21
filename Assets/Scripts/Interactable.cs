using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Méthode appelée lors de l'interaction
    public virtual void OnInteract()
    {
        Debug.Log("Interacted with: " + gameObject.name);
        // Implémentez ici la logique d'interaction spécifique
    }
}
