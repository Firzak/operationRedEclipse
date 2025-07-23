using System;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject interactOrigin;

    private Renderer lastRenderer = null;
    private Material lastSecondMaterial = null;
    private Color lastSecondMaterialColor;
    private Interactable lastInteractable = null;

    private void FixedUpdate()
    {
        CheckInteractable();
    }

    private void CheckInteractable()
    {
        RaycastHit hit;
        Vector3 origin = interactOrigin.transform.position;
        Vector3 direction = interactOrigin.transform.forward;

        Debug.DrawRay(origin, direction * interactionDistance, Color.green, 0.1f);

        if (Physics.Raycast(origin, direction, out hit, interactionDistance, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable == null || !interactable.enabled)
            {
                Debug.LogWarning("L'objet touché n'est pas interactif ou désactivé : " + hit.collider.name);
                return;
            }
            lastInteractable = interactable;
            
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null && renderer.materials.Length > 1)
            {
                Material secondMaterial = renderer.materials[1];

                // Si ce n'est pas le même objet qu'avant, reset l'ancien
                if (renderer != lastRenderer && lastSecondMaterial != null)
                {
                    lastSecondMaterial.color = lastSecondMaterialColor;
                }

                if (renderer != lastRenderer)
                {
                    lastSecondMaterialColor = secondMaterial.color;
                }

                secondMaterial.color = Color.green;
                lastRenderer = renderer;
                lastSecondMaterial = secondMaterial;
                
                interactable.canvasInteraction.SetActive(true);
            }
        }
        else
        {
            // Si on ne touche plus rien, reset l'ancien material
            if (lastSecondMaterial != null)
            {
                lastSecondMaterial.color = lastSecondMaterialColor;
                lastSecondMaterial = null;
                lastRenderer = null;
                
                lastInteractable.canvasInteraction.SetActive(false);
            }
        }
    }

    public void Interact()
    {
        RaycastHit hit;
        Vector3 origin = interactOrigin.transform.position;
        Vector3 direction = interactOrigin.transform.forward;

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