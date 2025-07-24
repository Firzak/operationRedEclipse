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
            
        }
    }
}
