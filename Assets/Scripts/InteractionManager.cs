using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject interactOrigin;

    public void Interact()
    {
        RaycastHit hit;
        Vector3 origin = interactOrigin.transform.position;
        Vector3 direction = interactOrigin.transform.forward;

        // Affiche le rayon dans la scène (visible en mode éditeur)
        Debug.DrawRay(origin, direction * interactionDistance, Color.red, 10f);

        if (Physics.Raycast(origin, direction, out hit, interactionDistance, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
            else
            {
                Debug.LogWarning("L'objet touché n'est pas interactif : " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("Aucun objet interactif à portée.");
        }
    }
}