using UnityEngine;

public class InteractTest : Interactable
{
    public override void OnInteract()
    {
        // Logique spécifique pour l'interaction de test
        Debug.Log("Interacted with InteractTest: " + gameObject.name);
        
        // Vous pouvez ajouter ici des effets visuels, sonores, ou d'autres actions
        // Par exemple, changer la couleur de l'objet
        GetComponent<Renderer>().material.color = Color.green;
        
        // Ou jouer un son
        // AudioSource.PlayClipAtPoint(interactionSound, transform.position);
    }
}
