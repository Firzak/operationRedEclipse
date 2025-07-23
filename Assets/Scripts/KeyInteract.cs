using TMPro;
using UnityEngine;

public class KeyInteract : Interactable
{
    public override void OnInteract()
    {
        Destroy(gameObject);
    }
}
