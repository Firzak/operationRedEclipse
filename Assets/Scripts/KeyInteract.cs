using TMPro;
using UnityEngine;

public class KeyInteract : Interactable
{
    public override void OnInteract()
    {
        FindFirstObjectByType<ProgressManager>().key = true;
        Destroy(gameObject);
    }
}
