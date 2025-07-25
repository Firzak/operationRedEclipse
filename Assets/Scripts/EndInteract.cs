using UnityEngine;
using UnityEngine.SceneManagement;

public class EndInteract : Interactable
{
    public override void OnInteract()
    {
        SceneManager.LoadScene("Credits");
    }
}
